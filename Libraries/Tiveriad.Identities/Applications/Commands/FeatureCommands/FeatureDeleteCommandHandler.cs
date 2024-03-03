#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.FeatureCommands;

public class FeatureDeleteCommandHandler : IRequestHandler<FeatureDeleteCommandHandlerRequest, bool>
{
    private readonly IRepository<Feature, string> _languageRepository;

    public FeatureDeleteCommandHandler(IRepository<Feature, string> languageRepository)
    {
        _languageRepository = languageRepository;
    }


    public Task<bool> Handle(FeatureDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            
            var query = _languageRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);
            query = query.Where(x => x.Realm.Id == request.RealmId);

            var language = query.FirstOrDefault();
            if (language == null) throw new Exception();
            return _languageRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        
    }
}