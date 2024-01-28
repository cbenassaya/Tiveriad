#region

using AutoMapper;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Apis.Mappings;

public class DocumentDescriptionProfile : Profile
{
    public DocumentDescriptionProfile()
    {
        CreateMap<DocumentDescription, DocumentDescriptionReaderModel>();
        CreateMap<DocumentDescriptionUpdaterModel, DocumentDescription>();
        CreateMap<DocumentDescriptionWriterModel, DocumentDescription>();
    }
}