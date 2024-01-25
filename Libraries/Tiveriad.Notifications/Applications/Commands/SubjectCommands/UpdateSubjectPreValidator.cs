#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class UpdateSubjectPreValidator : AbstractValidator<UpdateSubjectRequest>
{
    public UpdateSubjectPreValidator(IRepository<Subject, string> subjectRepository)
    {
        RuleFor(x => x.Subject).NotNull().WithMessage("Subject is required")
            .WithErrorCode("NOTIFICATIONS_SUBJECT_UPDATE_SUBJECT_REQUIRED");
        RuleFor(x => x.Subject.Name).NotEmpty().WithMessage("Name is required")
            .WithErrorCode("NOTIFICATIONS_SUBJECT_UPDATE_NAME_REQUIRED");
        RuleFor(x => x.Subject.Id).NotEmpty().WithMessage("Id is required")
            .WithErrorCode("NOTIFICATIONS_SUBJECT_UPDATE_ID_REQUIRED");
        RuleFor(x => x).Must(request =>
        {
            var subject = subjectRepository
                .Queryable
                .FirstOrDefault(c => c.Id == request.Subject.Id);

            return subject != null;
        }).WithMessage("Subject not found").WithErrorCode("NOTIFICATIONS_SUBJECT_UPDATE_NOT_FOUND");
        RuleFor(x => x).Must(request =>
        {
            var subject = subjectRepository
                .Queryable
                .FirstOrDefault(c => c.Name == request.Subject.Name && c.Id != request.Subject.Id);

            return subject == null;
        }).WithMessage("Subject name already exists").WithErrorCode("NOTIFICATIONS_SUBJECT_UPDATE_NAME_ALREADY_EXISTS");
    }
}