#region

using AutoMapper;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Documents.Apis.Contracts;

#endregion

namespace Tiveriad.Documents.Apis.Mappings;

public class DocumentProfile<T> : Profile where T : IEquatable<T>
{
    public DocumentProfile()
    {
        CreateMap<DocumentDescriptionBase<T>, DocumentDescriptionReaderModel>();
        CreateMap<DocumentDescriptionUpdaterModel, DocumentDescriptionBase<T>>();
        CreateMap<DocumentDescriptionWriterModel, DocumentDescriptionBase<T>>();
    }
}