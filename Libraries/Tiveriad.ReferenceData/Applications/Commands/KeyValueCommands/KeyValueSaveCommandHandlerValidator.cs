
using FluentValidation;
using MediatR;
using Tiveriad.ReferenceData.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;

public class KeyValueSaveCommandHandlerValidator : AbstractValidator<KeyValueSaveCommandHandlerRequest>
{
    private IRepository<KeyValue, string> _repository;
    public KeyValueSaveCommandHandlerValidator(IRepository<KeyValue, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.OrganizationId).NotNull().WithErrorCode(ErrorCodes.KeyValueSaveCommandHandler_OrganizationId_XNotNullRule);
        RuleFor(x => x.KeyValue).NotNull().WithErrorCode(ErrorCodes.KeyValueSaveCommandHandler_KeyValue_XNotNullRule);
        RuleFor(x => x.KeyValue.Key).MaximumLength(12).WithErrorCode(ErrorCodes.KeyValue_Key_XMaxLengthRule_Max_12);
        RuleFor(x => x.KeyValue.Key).NotEmpty().WithErrorCode(ErrorCodes.KeyValue_Key_XNotEmptyRule);
        RuleFor(x => x.KeyValue.Entity).MaximumLength(50).WithErrorCode(ErrorCodes.KeyValue_Entity_XMaxLengthRule_Max_50);
        RuleFor(x => x.KeyValue.Entity).NotEmpty().WithErrorCode(ErrorCodes.KeyValue_Entity_XNotEmptyRule);
        RuleFor(x => x.KeyValue.OrganizationId).NotEmpty().WithErrorCode(ErrorCodes.KeyValue_OrganizationId_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.OrganizationId == request.KeyValue.OrganizationId);
                    query = query.Where(x => x.Key == request.KeyValue.Key);
                    query = query.Where(x => x.Entity == request.KeyValue.Entity);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.KeyValue_XBusinessKeyRule);
        RuleFor(x => x.KeyValue.InternationalizedValues)
            .Must(x => x.Count != 0).WithErrorCode(ErrorCodes.KeyValue_InternationalizedValues_MustHaveOneValue);
        RuleFor(x => x.KeyValue.InternationalizedValues)
            .Must(x => !x.Any(v=>string.IsNullOrEmpty(v.Language))).WithErrorCode(ErrorCodes.KeyValue_InternationalizedValues_Language_XNotEmptyRule);
        RuleFor(x => x.KeyValue.InternationalizedValues)
            .Must(x => !x.Any(v=>string.IsNullOrEmpty(v.Value))).WithErrorCode(ErrorCodes.KeyValue_InternationalizedValues_Value_XNotEmptyRule);
    }


}

