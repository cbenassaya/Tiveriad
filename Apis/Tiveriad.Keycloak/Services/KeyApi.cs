using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Services;

public class KeyApi:IKeyApi
{
    public KeysMetadataRepresentation RealmKeysGet(string realm)
    {
        throw new NotImplementedException();
    }

    public ApiResponse<KeysMetadataRepresentation> RealmKeysGetWithHttpInfo(string realm)
    {
        throw new NotImplementedException();
    }

    public Task<KeysMetadataRepresentation> RealmKeysGetAsync(string realm)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<KeysMetadataRepresentation>> RealmKeysGetAsyncWithHttpInfo(string realm)
    {
        throw new NotImplementedException();
    }
}