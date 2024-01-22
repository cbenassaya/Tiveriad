#region

using FluentValidation;
using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.IdGenerators;

#endregion

namespace DataReference.Integration;

[DataReferenceRoute("api/civilities")]
public class Civility : IDataReference<string>
{
    public string? Id { get; set; }

    public string? DocumentDescriptionId { get; set; }
    public InternationalizedString Label { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; }
    public Visibility Visibility { get; set; }
    public string OrganizationId { get; set; }
}

public class KeyParser : IKeyParser<string>
{
    public string Parse(string? key)
    {
        return key ?? string.Empty;
    }
}

public class TenantService : ITenantService<string>
{
    private static readonly string _objectId = KeyGenerator.NewId<string>();

    public string GetOrganizationId()
    {
        return _objectId;
    }
}

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
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