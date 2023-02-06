namespace Tiveriad.Commons.HttpApis
{
    /// <summary>
    /// Extension methods for <see cref="IApiClient"/>
    /// </summary>
    public static class ApiClientExtensions
    {
        /// <summary>
        /// Sends a GET request using specified fluent <paramref name="builder" /> as an asynchronous operation.
        /// </summary>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<HttpResponseMessage> GetAsync(this IApiClient apiClient, Action<QueryBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var httpClient = apiClient.HttpClient;
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress);
            requestMessage.SetContentSerializer(apiClient.ContentSerializer);

            var fluentBuilder = new QueryBuilder(requestMessage);
            builder(fluentBuilder);

            var response = await ApiDispatcher.SendAsync(httpClient, requestMessage).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Sends a GET request using specified fluent <paramref name="builder"/> as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<TResponse> GetAsync<TResponse>(this IApiClient apiClient, Action<QueryBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var response = await apiClient.GetAsync(builder).ConfigureAwait(false);
            var data = await response.DeserializeAsync<TResponse>().ConfigureAwait(false);

            return data;
        }


        /// <summary>
        /// Sends a POST request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<HttpResponseMessage> PostAsync(this IApiClient apiClient, Action<FormBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var httpClient = apiClient.HttpClient;
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress);
            requestMessage.SetContentSerializer(apiClient.ContentSerializer);

            var fluentBuilder = new FormBuilder(requestMessage);
            builder(fluentBuilder);

            var response = await ApiDispatcher.SendAsync(httpClient, requestMessage).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Sends a POST request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<TResponse> PostAsync<TResponse>(this IApiClient apiClient, Action<FormBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var response = await apiClient.PostAsync(builder).ConfigureAwait(false);
            var data = await response.DeserializeAsync<TResponse>().ConfigureAwait(false);

            return data;
        }


        /// <summary>
        /// Sends a PUT request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<HttpResponseMessage> PutAsync(this IApiClient apiClient, Action<FormBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var httpClient = apiClient.HttpClient;
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, httpClient.BaseAddress);
            requestMessage.SetContentSerializer(apiClient.ContentSerializer);

            var fluentBuilder = new FormBuilder(requestMessage);
            builder(fluentBuilder);

            var response = await ApiDispatcher.SendAsync(httpClient, requestMessage).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Sends a PUT request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<TResponse> PutAsync<TResponse>(this IApiClient apiClient, Action<FormBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var response = await apiClient.PutAsync(builder).ConfigureAwait(false);
            var data = await response.DeserializeAsync<TResponse>().ConfigureAwait(false);

            return data;
        }


        /// <summary>
        /// Sends a PATCH request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<HttpResponseMessage> PatchAsync(this IApiClient apiClient, Action<FormBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var httpClient = apiClient.HttpClient;
            var requestMessage = new HttpRequestMessage(FormBuilder.HttpPatch, httpClient.BaseAddress);
            requestMessage.SetContentSerializer(apiClient.ContentSerializer);

            var fluentBuilder = new FormBuilder(requestMessage);
            builder(fluentBuilder);

            var response = await ApiDispatcher.SendAsync(httpClient, requestMessage).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Sends a PATCH request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<TResponse> PatchAsync<TResponse>(this IApiClient apiClient, Action<FormBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var response = await apiClient.PatchAsync(builder).ConfigureAwait(false);
            var data = await response.DeserializeAsync<TResponse>().ConfigureAwait(false);

            return data;
        }


        /// <summary>
        /// Sends a DELETE request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<HttpResponseMessage> DeleteAsync(this IApiClient apiClient, Action<FormBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var httpClient = apiClient.HttpClient;
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, httpClient.BaseAddress);
            requestMessage.SetContentSerializer(apiClient.ContentSerializer);

            var fluentBuilder = new FormBuilder(requestMessage);
            builder(fluentBuilder);

            var response = await ApiDispatcher.SendAsync(httpClient, requestMessage).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Sends a DELETE request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<TResponse> DeleteAsync<TResponse>(this IApiClient apiClient, Action<FormBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var response = await apiClient.DeleteAsync(builder).ConfigureAwait(false);
            var data = await response.DeserializeAsync<TResponse>().ConfigureAwait(false);

            return data;
        }


        /// <summary>
        /// Sends a request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<HttpResponseMessage> SendAsync(this IApiClient apiClient, Action<SendBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var httpClient = apiClient.HttpClient;
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress);
            requestMessage.SetContentSerializer(apiClient.ContentSerializer);

            var fluentBuilder = new SendBuilder(requestMessage);
            builder(fluentBuilder);

            var response = await ApiDispatcher.SendAsync(httpClient, requestMessage).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Sends a request using specified fluent builder as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="builder">The fluent builder factory.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="builder" /> is <see langword="null" />.</exception>
        public static async Task<TResponse> SendAsync<TResponse>(this IApiClient apiClient, Action<SendBuilder> builder)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var response = await apiClient.SendAsync(builder).ConfigureAwait(false);
            var data = await response.DeserializeAsync<TResponse>().ConfigureAwait(false);

            return data;
        }


        /// <summary>
        /// Sends a request using specified request message as an asynchronous operation.
        /// </summary>
        /// <param name="apiClient">The <see cref="IApiClient"/> used to send request.</param>
        /// <param name="requestMessage">The request message to send.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="apiClient" /> or <paramref name="requestMessage" /> is <see langword="null" />.</exception>
        public static async Task<HttpResponseMessage> SendAsync(this IApiClient apiClient, HttpRequestMessage requestMessage)
        {
            if (apiClient == null)
                throw new ArgumentNullException(nameof(apiClient));

            if (requestMessage == null)
                throw new ArgumentNullException(nameof(requestMessage));

            var httpClient = apiClient.HttpClient;

            requestMessage.SetContentSerializer(apiClient.ContentSerializer);

            var response = await ApiDispatcher.SendAsync(httpClient, requestMessage).ConfigureAwait(false);

            return response;
        }

    }
}
