#region

using FluentValidation;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Apis.Commands;

public class SaveEntityPreValidator<TEntity, TKey> : AbstractValidator<SaveRequest<TEntity, TKey>>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IRepository<TEntity, TKey> _repository;

    public SaveEntityPreValidator(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
        RuleFor(x => x.Entity).NotNull().WithErrorCode(typeof(TEntity).Name + "_NOT_FOUND");
        RuleFor(x => x.Entity).MustAsync(async (entity, cancellationToken) =>
        {
            return !await _repository.AnyAsync(x => x.Id.Equals(entity.Id), cancellationToken);
        }).WithMessage($"{typeof(TEntity).Name} already exists").WithErrorCode(typeof(TEntity).Name + "_ALREADY_EXISTS");
        RuleFor(x => x.Entity.Label).NotEmpty().WithMessage("Name is required").WithErrorCode(typeof(TEntity).Name + "_NAME_IS_REQUIRED");
        
        RuleFor(x => x.Entity.Code).NotEmpty().WithMessage("Code is required").WithErrorCode(typeof(TEntity).Name + "_CODE_IS_REQUIRED");
        RuleFor(x => x.Entity).MustAsync(async (entity, cancellationToken) =>
        {
            return !await _repository.AnyAsync(x => x.Label == entity.Label ,
                cancellationToken);
        }).WithMessage($"{typeof(TEntity).Name} already exists").WithErrorCode(typeof(TEntity).Name + "_ALREADY_EXISTS");;
    }
}