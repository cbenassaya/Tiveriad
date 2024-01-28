#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public class DeleteDocumentDescriptionByIdRequestHandler : IRequestHandler<DeleteDocumentDescriptionByIdRequest, bool>
{
    private readonly IRepository<DocumentDescription, string> _documentDescriptionRepository;
    private IRepository<DocumentCategory, string> _documentCategoryRepository;

    public DeleteDocumentDescriptionByIdRequestHandler(
        IRepository<DocumentDescription, string> documentDescriptionRepository,
        IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentDescriptionRepository = documentDescriptionRepository;
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<bool> Handle(DeleteDocumentDescriptionByIdRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _documentDescriptionRepository.Queryable.Include(x => x.DocumentCategory).AsQueryable();
            query = query.Where(x => x.Id == request.Id);
            var documentDescription = query.FirstOrDefault();
            if (documentDescription == null) throw new Exception();
            return _documentDescriptionRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}