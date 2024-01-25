#region

using AutoMapper;
using Tiveriad.Notifications.Apis.Contracts;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.Mappings;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<Subject, SubjectReaderModel>();
        CreateMap<Subject, SubjectReduceModel>();
        CreateMap<SubjectWriterModel, Subject>();
        CreateMap<SubjectUpdaterModel, Subject>();
    }
}