# Clerk.BackendAPI


<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.GetAsync(emailAddressId: "email_address_id_example");

// handle response
```
<!-- End SDK Example Usage [usage] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security scheme globally:

| Name         | Type | Scheme      |
| ------------ | ---- | ----------- |
| `BearerAuth` | http | HTTP Bearer |

To authenticate with the API the `BearerAuth` parameter must be set when initializing the SDK client instance. For example:
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter = "frontend-api_1a2b3c4d",
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(req);

// handle response
```
<!-- End Authentication [security] -->

<!-- Start Retries [retries] -->
## Retries

Some of the endpoints in this SDK support retries. If you use the SDK without any configuration, it will fall back to the default retry strategy provided by the API. However, the default retry strategy can be overridden on a per-operation basis, or across the entire SDK.

To change the default retry strategy for a single API call, simply pass a `RetryConfig` to the call:
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi();

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter = "frontend-api_1a2b3c4d",
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(
    retryConfig: new RetryConfig(
        strategy: RetryConfig.RetryStrategy.BACKOFF,
        backoff: new BackoffStrategy(
            initialIntervalMs: 1L,
            maxIntervalMs: 50L,
            maxElapsedTimeMs: 100L,
            exponent: 1.1
        ),
        retryConnectionErrors: false
    ),
    request: req
);

// handle response
```

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when intitializing the SDK:
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(retryConfig: new RetryConfig(
    strategy: RetryConfig.RetryStrategy.BACKOFF,
    backoff: new BackoffStrategy(
        initialIntervalMs: 1L,
        maxIntervalMs: 50L,
        maxElapsedTimeMs: 100L,
        exponent: 1.1
    ),
    retryConnectionErrors: false
));

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter = "frontend-api_1a2b3c4d",
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(req);

// handle response
```
<!-- End Retries [retries] -->

<!-- Start Error Handling [errors] -->
## Error Handling

[`SDKBaseError`](./src/Clerk/BackendAPI/Models/Errors/SDKBaseError.cs) is the base exception class for all HTTP error responses. It has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | Error message         |
| `Request`     | *HttpRequestMessage*  | HTTP request object   |
| `Response`    | *HttpResponseMessage* | HTTP response object  |

Some exceptions in this SDK include an additional `Payload` field, which will contain deserialized custom error data when present. Possible exceptions are listed in the [Error Classes](#error-classes) section.

### Example

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Errors;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

try
{
    var res = await sdk.AwsCredentials.DeleteAsync(id: "<id>");

    // handle response
}
catch (SDKBaseError ex)  // all SDK exceptions inherit from SDKBaseError
{
    // ex.ToString() provides a detailed error message
    System.Console.WriteLine(ex);

    // Base exception fields
    HttpRequestMessage request = ex.Request;
    HttpResponseMessage response = ex.Response;
    var statusCode = (int)response.StatusCode;
    var responseBody = ex.Body;

    if (ex is ClerkErrors) // different exceptions may be thrown depending on the method
    {
        // Check error data fields
        ClerkErrorsPayload payload = ex.Payload;
        List<ClerkError> Errors = payload.Errors;
        Clerk.BackendAPI.Models.Errors.Meta Meta = payload.Meta;
    }

    // An underlying cause may be provided
    if (ex.InnerException != null)
    {
        Exception cause = ex.InnerException;
    }
}
catch (System.Net.Http.HttpRequestException ex)
{
    // Check ex.InnerException for Network connectivity errors
}
```

### Error Classes

**Primary exceptions:**
* [`SDKBaseError`](./src/Clerk/BackendAPI/Models/Errors/SDKBaseError.cs): The base class for HTTP error responses.
  * [`ClerkErrors`](./src/Clerk/BackendAPI/Models/Errors/ClerkErrors.cs): Request was not successful. *

<details><summary>Less common exceptions (13)</summary>

* [`System.Net.Http.HttpRequestException`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception): Network connectivity error. For more details about the underlying cause, inspect the `ex.InnerException`.

* Inheriting from [`SDKBaseError`](./src/Clerk/BackendAPI/Models/Errors/SDKBaseError.cs):
  * [`CreateM2MTokenResponseBody`](./src/Clerk/BackendAPI/Models/Errors/CreateM2MTokenResponseBody.cs): 400 Bad Request. Status code `400`. Applicable to 1 of 159 methods.*
  * [`GetM2MTokensResponseBody`](./src/Clerk/BackendAPI/Models/Errors/GetM2MTokensResponseBody.cs): 400 Bad Request. Status code `400`. Applicable to 1 of 159 methods.*
  * [`RevokeM2MTokenResponseBody`](./src/Clerk/BackendAPI/Models/Errors/RevokeM2MTokenResponseBody.cs): 400 Bad Request. Status code `400`. Applicable to 1 of 159 methods.*
  * [`VerifyM2MTokenResponseBody`](./src/Clerk/BackendAPI/Models/Errors/VerifyM2MTokenResponseBody.cs): 400 Bad Request. Status code `400`. Applicable to 1 of 159 methods.*
  * [`VerifyOAuthAccessTokenResponseBody`](./src/Clerk/BackendAPI/Models/Errors/VerifyOAuthAccessTokenResponseBody.cs): 400 Bad Request. Status code `400`. Applicable to 1 of 159 methods.*
  * [`GetM2MTokensM2mResponseBody`](./src/Clerk/BackendAPI/Models/Errors/GetM2MTokensM2mResponseBody.cs): 403 Forbidden. Status code `403`. Applicable to 1 of 159 methods.*
  * [`GetM2MTokensM2mResponseResponseBody`](./src/Clerk/BackendAPI/Models/Errors/GetM2MTokensM2mResponseResponseBody.cs): 404 Not Found. Status code `404`. Applicable to 1 of 159 methods.*
  * [`RevokeM2MTokenM2mResponseBody`](./src/Clerk/BackendAPI/Models/Errors/RevokeM2MTokenM2mResponseBody.cs): 404 Not Found. Status code `404`. Applicable to 1 of 159 methods.*
  * [`VerifyM2MTokenM2mResponseBody`](./src/Clerk/BackendAPI/Models/Errors/VerifyM2MTokenM2mResponseBody.cs): 404 Not Found. Status code `404`. Applicable to 1 of 159 methods.*
  * [`VerifyOAuthAccessTokenOauthAccessTokensResponseBody`](./src/Clerk/BackendAPI/Models/Errors/VerifyOAuthAccessTokenOauthAccessTokensResponseBody.cs): 404 Not Found. Status code `404`. Applicable to 1 of 159 methods.*
  * [`CreateM2MTokenM2mResponseBody`](./src/Clerk/BackendAPI/Models/Errors/CreateM2MTokenM2mResponseBody.cs): 409 Conflict. Status code `409`. Applicable to 1 of 159 methods.*
  * [`ResponseValidationError`](./src/Clerk/BackendAPI/Models/Errors/ResponseValidationError.cs): Thrown when the response data could not be deserialized into the expected type.
</details>

\* Refer to the [relevant documentation](#available-resources-and-operations) to determine whether an exception applies to a specific operation.
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Override Server URL Per-Client

The default server can be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(serverUrl: "https://api.clerk.com/v1");

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter = "frontend-api_1a2b3c4d",
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(req);

// handle response
```
<!-- End Server Selection [server] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->