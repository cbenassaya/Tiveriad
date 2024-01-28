#region

using AutoMapper;
using Tiveriad.Documents.Apis.Contracts.DocumentCategoryContracts;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Apis.Mappings;

public class DocumentCategoryProfile : Profile
{
    public DocumentCategoryProfile()
    {
        CreateMap<DocumentCategory, DocumentCategoryReaderModel>();
        CreateMap<DocumentCategory, DocumentCategoryReduceModel>();
        CreateMap<DocumentCategoryUpdaterModel, DocumentCategory>();
        CreateMap<DocumentCategoryWriterModel, DocumentCategory>();
    }
}