#region

using AutoMapper;
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using Tiveriad.Notifications.Apis.Contracts.NotificationMessageContracts;
using Tiveriad.Notifications.Apis.Contracts.SubjectContracts;
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

public class NotificationProfile : Profile
{
    public NotificationProfile()
    {
        CreateMap<Notification, NotificationReaderModel>();
        CreateMap<NotificationWriterModel, Notification>();
        CreateMap<NotificationUpdaterModel, Notification>();
    }
}

public class NotificationMessageProfile : Profile
{
    public NotificationMessageProfile()
    {
        CreateMap<NotificationMessage, NotificationMessageReduceModel>();
    }
}