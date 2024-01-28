#region

using MediatR;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class UpdateDocumentCategoryRequestHandler : IRequestHandler<UpdateDocumentCategoryRequest, DocumentCategory>
{
    private readonly IRepository<DocumentCategory, string> _documentCategoryRepository;

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
            query = query.Where(x => x.Id == request.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.DocumentCategory.Name;
            result.Code = request.DocumentCategory.Code;

            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}