using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public class SaveDocumentDescriptionRequestHandler : IRequestHandler<SaveDocumentDescriptionRequest, DocumentDescription>
{
    private IRepository<DocumentDescription, string> _documentDescriptionRepository;
    private IRepository<DocumentCategory, string> _documentCategoryRepository;
    public SaveDocumentDescriptionRequestHandler(IRepository<DocumentDescription, string> documentDescriptionRepository, IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentDescriptionRepository = documentDescriptionRepository;
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<DocumentDescription> Handle(SaveDocumentDescriptionRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            await _documentDescriptionRepository.AddOneAsync(request.DocumentDescription, cancellationToken);
            return request.DocumentDescription;
        }, cancellationToken);
        
    }
}

