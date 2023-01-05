using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IClientAttributeCertificateApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Get a keystore file for the client, containing private key and public certificate
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Keystore configuration as JSON</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>byte[]</returns>
    byte[] RealmClientsIdCertificatesAttrDownloadPost(KeyStoreConfig body, string realm, string id, string attr);

    /// <summary>
    ///     Get a keystore file for the client, containing private key and public certificate
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Keystore configuration as JSON</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>ApiResponse of byte[]</returns>
    ApiResponse<byte[]> RealmClientsIdCertificatesAttrDownloadPostWithHttpInfo(KeyStoreConfig body, string realm,
        string id, string attr);

    /// <summary>
    ///     Generate a new keypair and certificate, and get the private key file   Generates a keypair and certificate and
    ///     serves the private key in a specified keystore format.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Keystore configuration as JSON</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>byte[]</returns>
    byte[] RealmClientsIdCertificatesAttrGenerateAndDownloadPost(KeyStoreConfig body, string realm, string id,
        string attr);

    /// <summary>
    ///     Generate a new keypair and certificate, and get the private key file   Generates a keypair and certificate and
    ///     serves the private key in a specified keystore format.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Keystore configuration as JSON</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>ApiResponse of byte[]</returns>
    ApiResponse<byte[]> RealmClientsIdCertificatesAttrGenerateAndDownloadPostWithHttpInfo(KeyStoreConfig body,
        string realm, string id, string attr);

    /// <summary>
    ///     Generate a new certificate with new key pair
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>CertificateRepresentation</returns>
    CertificateRepresentation RealmClientsIdCertificatesAttrGeneratePost(string realm, string id, string attr);

    /// <summary>
    ///     Generate a new certificate with new key pair
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>ApiResponse of CertificateRepresentation</returns>
    ApiResponse<CertificateRepresentation> RealmClientsIdCertificatesAttrGeneratePostWithHttpInfo(string realm,
        string id, string attr);

    /// <summary>
    ///     Get key info
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>CertificateRepresentation</returns>
    CertificateRepresentation RealmClientsIdCertificatesAttrGet(string realm, string id, string attr);

    /// <summary>
    ///     Get key info
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>ApiResponse of CertificateRepresentation</returns>
    ApiResponse<CertificateRepresentation> RealmClientsIdCertificatesAttrGetWithHttpInfo(string realm, string id,
        string attr);

    /// <summary>
    ///     Upload only certificate, not private key
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>CertificateRepresentation</returns>
    CertificateRepresentation RealmClientsIdCertificatesAttrUploadCertificatePost(string realm, string id, string attr);

    /// <summary>
    ///     Upload only certificate, not private key
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>ApiResponse of CertificateRepresentation</returns>
    ApiResponse<CertificateRepresentation> RealmClientsIdCertificatesAttrUploadCertificatePostWithHttpInfo(string realm,
        string id, string attr);

    /// <summary>
    ///     Upload certificate and eventually private key
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>CertificateRepresentation</returns>
    CertificateRepresentation RealmClientsIdCertificatesAttrUploadPost(string realm, string id, string attr);

    /// <summary>
    ///     Upload certificate and eventually private key
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>ApiResponse of CertificateRepresentation</returns>
    ApiResponse<CertificateRepresentation> RealmClientsIdCertificatesAttrUploadPostWithHttpInfo(string realm, string id,
        string attr);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get a keystore file for the client, containing private key and public certificate
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Keystore configuration as JSON</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of byte[]</returns>
    Task<byte[]> RealmClientsIdCertificatesAttrDownloadPostAsync(KeyStoreConfig body, string realm, string id,
        string attr);

    /// <summary>
    ///     Get a keystore file for the client, containing private key and public certificate
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Keystore configuration as JSON</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of ApiResponse (byte[])</returns>
    Task<ApiResponse<byte[]>> RealmClientsIdCertificatesAttrDownloadPostAsyncWithHttpInfo(KeyStoreConfig body,
        string realm, string id, string attr);

    /// <summary>
    ///     Generate a new keypair and certificate, and get the private key file   Generates a keypair and certificate and
    ///     serves the private key in a specified keystore format.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Keystore configuration as JSON</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of byte[]</returns>
    Task<byte[]> RealmClientsIdCertificatesAttrGenerateAndDownloadPostAsync(KeyStoreConfig body, string realm,
        string id, string attr);

    /// <summary>
    ///     Generate a new keypair and certificate, and get the private key file   Generates a keypair and certificate and
    ///     serves the private key in a specified keystore format.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Keystore configuration as JSON</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of ApiResponse (byte[])</returns>
    Task<ApiResponse<byte[]>> RealmClientsIdCertificatesAttrGenerateAndDownloadPostAsyncWithHttpInfo(
        KeyStoreConfig body, string realm, string id, string attr);

    /// <summary>
    ///     Generate a new certificate with new key pair
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of CertificateRepresentation</returns>
    Task<CertificateRepresentation> RealmClientsIdCertificatesAttrGeneratePostAsync(string realm, string id,
        string attr);

    /// <summary>
    ///     Generate a new certificate with new key pair
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of ApiResponse (CertificateRepresentation)</returns>
    Task<ApiResponse<CertificateRepresentation>> RealmClientsIdCertificatesAttrGeneratePostAsyncWithHttpInfo(
        string realm, string id, string attr);

    /// <summary>
    ///     Get key info
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of CertificateRepresentation</returns>
    Task<CertificateRepresentation> RealmClientsIdCertificatesAttrGetAsync(string realm, string id, string attr);

    /// <summary>
    ///     Get key info
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of ApiResponse (CertificateRepresentation)</returns>
    Task<ApiResponse<CertificateRepresentation>> RealmClientsIdCertificatesAttrGetAsyncWithHttpInfo(string realm,
        string id, string attr);

    /// <summary>
    ///     Upload only certificate, not private key
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of CertificateRepresentation</returns>
    Task<CertificateRepresentation> RealmClientsIdCertificatesAttrUploadCertificatePostAsync(string realm, string id,
        string attr);

    /// <summary>
    ///     Upload only certificate, not private key
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of ApiResponse (CertificateRepresentation)</returns>
    Task<ApiResponse<CertificateRepresentation>> RealmClientsIdCertificatesAttrUploadCertificatePostAsyncWithHttpInfo(
        string realm, string id, string attr);

    /// <summary>
    ///     Upload certificate and eventually private key
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of CertificateRepresentation</returns>
    Task<CertificateRepresentation> RealmClientsIdCertificatesAttrUploadPostAsync(string realm, string id, string attr);

    /// <summary>
    ///     Upload certificate and eventually private key
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="attr"></param>
    /// <returns>Task of ApiResponse (CertificateRepresentation)</returns>
    Task<ApiResponse<CertificateRepresentation>> RealmClientsIdCertificatesAttrUploadPostAsyncWithHttpInfo(string realm,
        string id, string attr);

    #endregion Asynchronous Operations
}