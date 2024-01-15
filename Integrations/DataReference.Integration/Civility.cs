using FluentValidation;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tiveriad.DataReferences.Apis.Services;
using Tiveriad.Repositories;

namespace DataReference.Integration;

[DataReferenceRoute("api/civilities")]
public class Civility: IDataReference<ObjectId>
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string DocumentDescriptionId { get; set; }
    public InternationalizedString Label { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public Visibility Visibility { get; set; }
    public ObjectId OrganizationId { get; set; }
}

public class KeyParser : IKeyParser<ObjectId>
{
    public ObjectId Parse(string? key)
    {
        return ObjectId.Parse(key);
    }
}

public class TenantService : ITenantService<ObjectId>
{
    private static ObjectId _objectId = ObjectId.GenerateNewId();
    public ObjectId GetOrganizationId()
    {
        return _objectId;
    }
}

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v =>
                v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Any())
            throw new ValidationException(failures);
        return await next();
    }
}