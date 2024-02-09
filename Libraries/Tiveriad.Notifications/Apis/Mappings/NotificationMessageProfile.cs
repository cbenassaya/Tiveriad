
using Tiveriad.Notifications.Apis.Contracts.NotificationMessageContracts;
using Tiveriad.Notifications.Core.Entities;
using AutoMapper;
namespace Tiveriad.Notifications.Apis.Mappings;

public class NotificationMessageProfile : Profile
{

    public NotificationMessageProfile()
    {

        CreateMap<NotificationMessageIdModelContract, NotificationMessage>();
        CreateMap<NotificationMessage, NotificationMessageReduceModelContract>();
    }


}

