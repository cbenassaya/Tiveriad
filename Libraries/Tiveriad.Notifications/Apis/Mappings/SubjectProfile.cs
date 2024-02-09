
using Tiveriad.Notifications.Apis.Contracts.SubjectContracts;
using Tiveriad.Notifications.Core.Entities;
using AutoMapper;
namespace Tiveriad.Notifications.Apis.Mappings;

public class SubjectProfile : Profile
{

    public SubjectProfile()
    {

        CreateMap<SubjectIdModelContract, Subject>();
        CreateMap<Subject, SubjectReduceModelContract>();
        CreateMap<Subject, SubjectReaderModelContract>();
        CreateMap<SubjectWriterModelContract, Subject>();
    }


}

