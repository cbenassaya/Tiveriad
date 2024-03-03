#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.FeatureCommands;

public class FeatureSaveCommandHandler : IRequestHandler<FeatureSaveCommandHandlerRequest, Feature>
{
    private readonly IRepository<Feature, string> _languageRepository;
    private readonly IRepository<Realm, string> _realmRepository;

    public FeatureSaveCommandHandler(IRepository<Feature, string> languageRepository, IRepository<Realm, string> realmRepository)
    {
        _languageRepository = languageRepository;
        _realmRepository = realmRepository;
    }


    public Task<Feature> Handle(FeatureSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            if (!string.IsNullOrEmpty(request.RealmId))
                request.Feature.Realm = await _realmRepository.GetByIdAsync(request.RealmId, cancellationToken);
            
            await _languageRepository.AddOneAsync(request.Feature, cancellationToken);
            return request.Feature;
        }, cancellationToken);
        
    }
}