#region

using MediatR;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public class
    SaveDocumentDescriptionRequestHandler : IRequestHandler<SaveDocumentDescriptionRequest, DocumentDescription>
{
    private readonly IRepository<DocumentDescription, string> _documentDescriptionRepository;
    private IRepository<DocumentCategory, string> _documentCategoryRepository;

    public SaveDocumentDescriptionRequestHandler(IRepository<DocumentDescription, string> documentDescriptionRepository,
        IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentDescriptionRepository = documentDescriptionRepository;
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<DocumentDescription> Handle(SaveDocumentDescriptionRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _documentDescriptionRepository.AddOneAsync(request.DocumentDescription, cancellationToken);
            return request.DocumentDescription;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}