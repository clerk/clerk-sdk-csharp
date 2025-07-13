# Clerk.BackendAPI


<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi();

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter = "frontend-api_1a2b3c4d",
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(req);

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

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when initializing the SDK:
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

Handling errors in this SDK should largely match your expectations. All operations return a response object or throw an exception.

By default, an API error will raise a `Clerk.BackendAPI.Models.Errors.SDKError` exception, which has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | The error message     |
| `Request`     | *HttpRequestMessage*  | The HTTP request      |
| `Response`    | *HttpResponseMessage* | The HTTP response     |

When custom error responses are specified for an operation, the SDK may also throw their associated exceptions. You can refer to respective *Errors* tables in SDK docs for more details on possible exception types for each operation. For example, the `VerifyAsync` method throws the following exceptions:

| Error Type                                 | Status Code   | Content Type     |
| ------------------------------------------ | ------------- | ---------------- |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404 | application/json |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX      | \*/\*            |

### Example

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Errors;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

try
{
    VerifyClientRequestBody req = new VerifyClientRequestBody() {
        Token = "jwt_token_example",
    };

    var res = await sdk.Clients.VerifyAsync(req);

    // handle response
}
catch (Exception ex)
{
    if (ex is ClerkErrors)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Clerk.BackendAPI.Models.Errors.SDKError)
    {
        // Handle default exception
        throw;
    }
}
```
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