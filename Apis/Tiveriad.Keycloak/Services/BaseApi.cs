#region

using Tiveriad.Commons.HttpApis;
using Tiveriad.Commons.RetryLogic;
using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Services;

public class BaseApi
{
    private readonly HttpClient _httpClient;
    private readonly IKeycloakSessionFactory _keycloakSessionFactory;

    public BaseApi(HttpClient httpClient, IKeycloakSessionFactory keycloakSessionFactory)
    {
        _httpClient = httpClient;
        _keycloakSessionFactory = keycloakSessionFactory;
    }

    public async Task<ApiResponse<T>> Execute<T>(Func<ApiClient, string, Task<ApiResponse<T>>> func)
    {
        var apiClient = new ApiClient(_httpClient);


        var retryResult = Retry.On<Exception>().Until(handle => handle.Context.Exceptions.Count > 3).Execute(context =>
        {
            if (context.Exceptions.Count > 0)
                _keycloakSessionFactory.GetSession().RenewToken();

            return func(apiClient, _keycloakSessionFactory.GetSession().Token);
        });

        return await retryResult.Value;
    }
}