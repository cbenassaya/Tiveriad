using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class UpdateDocumentCategoryRequestHandler : IRequestHandler<UpdateDocumentCategoryRequest, DocumentCategory>
{
    private IRepository<DocumentCategory, string> _documentCategoryRepository;
    public UpdateDocumentCategoryRequestHandler(IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<DocumentCategory> Handle(UpdateDocumentCategoryRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _documentCategoryRepository.Queryable;
            query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.OrganizationId == request.OrganizationId);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.DocumentCategory.Name;
            result.Code = request.DocumentCategory.Code;

            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

