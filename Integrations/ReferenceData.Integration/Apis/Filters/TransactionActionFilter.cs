#region

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;

#endregion

namespace ReferenceData.Integration.Apis.Filters;

public class TransactionActionFilter : IAsyncActionFilter
{
    private readonly DbContext _context;
    private readonly ILogger<TransactionActionFilter> _logger;
    private readonly ICurrentUserService<string> _currentUserService;

    public TransactionActionFilter(DbContext context, ILogger<TransactionActionFilter> logger, ICurrentUserService<string> currentUserService)
    {
        _context = context;
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await next();
        if (result.Exception == null || result.ExceptionHandled)
        {
            foreach (var entry in _context.ChangeTracker.Entries<IAuditable<string>>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _currentUserService.GetUserId();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = _currentUserService.GetUserId();
                        break;
                }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }
    }
}