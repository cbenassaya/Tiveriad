#region

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Registrations.Core.DomainEvents;
using Tiveriad.Registrations.Core.Entities;
using ICurrentUserService = Tiveriad.Integration.Core.Services.ICurrentUserService;

#endregion

namespace Tiveriad.Integration.Filters;

public class TransactionActionFilter : IAsyncActionFilter
{
    private readonly DbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<TransactionActionFilter> _logger;
    private readonly IDomainEventStore _store;

    public TransactionActionFilter(DbContext context, ICurrentUserService currentUserService,
        ILogger<TransactionActionFilter> logger, IDomainEventStore store)
    {
        _context = context;
        _currentUserService = currentUserService;
        _logger = logger;
        _store = store;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //await using var tx = await _context.Database.BeginTransactionAsync();
        var result = await next();
        if (result.Exception == null || result.ExceptionHandled)
        {
            foreach (var entry in _context.ChangeTracker.Entries<IEntity<string>>())
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        break;
                    case EntityState.Added:
                        if (entry.Entity is Registration registration)
                            _store.Add<OnSaveRegistrationDomainEvent,string>(new OnSaveRegistrationDomainEvent() { Entity = registration, OccurredOn = new DateTimeOffset(DateTime.Now), Id = registration.Id});
                        break;
                    case EntityState.Modified:
                        break;
                }

            foreach (var entry in _context.ChangeTracker.Entries<IAuditable<string>>())
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.GetUserId();
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.GetUserId();
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }

            try
            {
                await _context.SaveChangesAsync();
                _store.Commit();
            }
            catch (Exception e)
            {
                _logger.LogError("Try to save changes", e);
                throw;
            }
        }
    }
}