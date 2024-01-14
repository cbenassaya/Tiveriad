﻿#region

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
        RuleFor(x => x.Entity).NotNull();
        RuleFor(x => x.Entity).MustAsync(async (entity, cancellationToken) =>
        {
            return !await _repository.AnyAsync(x => x.Id.Equals(entity.Id), cancellationToken);
        }).WithMessage($"{typeof(TEntity).Name} already exists");
        RuleFor(x => x.Entity.Label).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Entity.Code).NotEmpty().WithMessage("Code is required");
        RuleFor(x => x.Entity).MustAsync(async (entity, cancellationToken) =>
        {
            return !await _repository.AnyAsync(x => x.Label == entity.Label ,
                cancellationToken);
        }).WithMessage("Question already exists");
    }
}