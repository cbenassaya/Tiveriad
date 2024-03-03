using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public class UpdateDocumentDescriptionRequestHandler : IRequestHandler<UpdateDocumentDescriptionRequest, DocumentDescription>
{
    private IRepository<DocumentDescription, string> _documentDescriptionRepository;
    private IRepository<DocumentCategory, string> _documentCategoryRepository;
    public UpdateDocumentDescriptionRequestHandler(IRepository<DocumentDescription, string> documentDescriptionRepository, IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentDescriptionRepository = documentDescriptionRepository;
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<DocumentDescription> Handle(UpdateDocumentDescriptionRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            var query = _documentDescriptionRepository.Queryable.Include(x => x.DocumentCategory).AsQueryable();
            query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.OrganizationId == request.OrganizationId);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.DocumentDescription.Name;
            result.State = request.DocumentDescription.State;
            result.Description = request.DocumentDescription.Description;
            result.Path = request.DocumentDescription.Path;
            result.Provider = request.DocumentDescription.Provider;
            result.Reference = request.DocumentDescription.Reference;
            result.ReferenceType = request.DocumentDescription.ReferenceType;
            result.Properties = request.DocumentDescription.Properties;
            if (request.DocumentDescription.DocumentCategory != null) result.DocumentCategory = await _documentCategoryRepository.GetByIdAsync(request.DocumentDescription.DocumentCategory.Id, cancellationToken);
            return result;
        }, cancellationToken);
        
    }
}

