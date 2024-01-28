#region

using MediatR;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class DeleteDocumentCategoryByIdRequestHandler : IRequestHandler<DeleteDocumentCategoryByIdRequest, bool>
{
    private readonly IRepository<DocumentCategory, string> _documentCategoryRepository;

    public DeleteDocumentCategoryByIdRequestHandler(IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<bool> Handle(DeleteDocumentCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _documentCategoryRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);
            var documentCategory = query.FirstOrDefault();
            if (documentCategory == null) throw new Exception();
            return _documentCategoryRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}