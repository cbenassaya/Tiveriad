#region

using MediatR;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class DeleteUserByIdRequestHandler : IRequestHandler<DeleteUserByIdRequest, bool>
{
    private readonly IDomainEventStore _store;
    private readonly IRepository<User, string> _userRepository;

    public DeleteUserByIdRequestHandler(IRepository<User, string> userRepository, IDomainEventStore store)
    {
        _userRepository = userRepository;
        _store = store;
    }

    public Task<bool> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var user = _userRepository.GetById(request.Id);
            if (user == null)
                return false;
            var result = _userRepository.DeleteOne(user) == 1;
            if (result)
                _store.Add<UserDomainEvent, string>(new UserDomainEvent { User = user, EventType = "DELETE" });
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}