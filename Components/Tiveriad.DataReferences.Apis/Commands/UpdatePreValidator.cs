#region

using FluentValidation;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Apis.Commands;

public class UpdatePreValidator<TEntity, TKey> : AbstractValidator<SaveRequest<TEntity, TKey>>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IRepository<TEntity, TKey> _repository;

    public UpdatePreValidator(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
        RuleFor(x => x.Entity).NotNull();
        RuleFor(x => x.Entity).MustAsync(async (entity, cancellationToken) =>
        {
            return await _repository.AnyAsync(x => x.Id.Equals(entity.Id), cancellationToken);
        }).WithMessage($"{typeof(TEntity).Name} doesn't exist");
        RuleFor(x => x.Entity.Label).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Entity.Code).NotEmpty().WithMessage("Code is required");
        RuleFor(x => x.Entity.Label).NotEmpty().WithMessage("Locale is required");
        RuleFor(x => x.Entity).MustAsync(async (entity, cancellationToken) =>
        {
            return !await _repository.AnyAsync(
                x => x.Label == entity.Label && !x.Id.Equals(entity.Id),
                cancellationToken);
        }).WithMessage("Question already exists");
    }
}