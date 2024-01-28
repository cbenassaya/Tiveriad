#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class DeleteSubjectByIdPreValidator : AbstractValidator<DeleteSubjectByIdRequest>
{
    public DeleteSubjectByIdPreValidator(IRepository<Subject, string> subjectRepository)
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithErrorCode("Tiveriad.Notifications.Subject.DeleteCommand:IdRequired");
        RuleFor(x => x).Must(request =>
            {
                var subject = subjectRepository
                    .Queryable
                    .FirstOrDefault(c => c.Id == request.Id);

                return subject != null;
            })
            .WithErrorCode("Tiveriad.Notifications.Subject.DeleteCommand:NotFound");
    }
}