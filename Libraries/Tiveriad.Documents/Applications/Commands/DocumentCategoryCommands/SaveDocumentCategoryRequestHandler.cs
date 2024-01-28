#region

using MediatR;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class SaveDocumentCategoryRequestHandler : IRequestHandler<SaveDocumentCategoryRequest, DocumentCategory>
{
    private readonly IRepository<DocumentCategory, string> _documentCategoryRepository;

    public SaveDocumentCategoryRequestHandler(IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<DocumentCategory> Handle(SaveDocumentCategoryRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _documentCategoryRepository.AddOneAsync(request.DocumentCategory, cancellationToken);
            return request.DocumentCategory;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}