#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class SaveSubjectPreValidator : AbstractValidator<SaveSubjectRequest>
{
    public SaveSubjectPreValidator(
        IRepository<Subject, string> subjectRepository)
    {
        RuleFor(x => x.Subject.Name).NotEmpty().WithMessage("Name is required")
            .WithErrorCode("NOTIFICATIONS_SUBJECT_SAVE_NAME_REQUIRED");
        RuleFor(x => x.Subject.Template).NotNull().WithMessage("Template is required")
            .WithErrorCode("NOTIFICATIONS_SUBJECT_SAVE_TEMPLATE_REQUIRED");
        RuleFor(x => x.Subject.Scopes).NotEmpty().WithMessage("Scopes is required")
            .WithErrorCode("NOTIFICATIONS_SUBJECT_SAVE_SCOPES_REQUIRED");
        RuleFor(x => x).Must(request =>
        {
            var subject = subjectRepository
                .Queryable
                .FirstOrDefault(c => c.Name == request.Subject.Name);

            return subject == null;
        }).WithMessage("Subject name already exists").WithErrorCode("NOTIFICATIONS_SUBJECT_SAVE_NAME_ALREADY_EXISTS");
    }
}