
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using AutoMapper;
namespace Tiveriad.Notifications.Apis.Mappings;

public class NotificationProfile : Profile
{

    public NotificationProfile()
    {

        CreateMap<Notification, NotificationReaderModelContract>();
        CreateMap<NotificationWriterModelContract, Notification>();
    }


}

