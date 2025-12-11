# APIKeys

## Overview

Endpoints for managing API Keys

### Available Operations

* [CreateApiKey](#createapikey) - Create an API Key
* [GetApiKeys](#getapikeys) - Get API Keys
* [GetApiKey](#getapikey) - Get an API Key by ID
* [UpdateApiKey](#updateapikey) - Update an API Key
* [DeleteApiKey](#deleteapikey) - Delete an API Key
* [GetApiKeySecret](#getapikeysecret) - Get an API Key Secret
* [RevokeApiKey](#revokeapikey) - Revoke an API Key
* [VerifyApiKey](#verifyapikey) - Verify an API Key

## CreateApiKey

Create an API Key

### Example Usage

<!-- UsageSnippet language="csharp" operationID="createApiKey" method="post" path="/api_keys" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateApiKeyRequestBody req = new CreateApiKeyRequestBody() {
    Name = "<value>",
    Subject = "<value>",
};

var res = await sdk.APIKeys.CreateApiKeyAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [CreateApiKeyRequestBody](../../Models/Operations/CreateApiKeyRequestBody.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[CreateApiKeyResponse](../../Models/Operations/CreateApiKeyResponse.md)**

### Errors

| Error Type                                                     | Status Code                                                    | Content Type                                                   |
| -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.CreateApiKeyResponseBody        | 400                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.CreateAPIKeyAPIKeysResponseBody | 409                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.SDKError                        | 4XX, 5XX                                                       | \*/\*                                                          |

## GetApiKeys

Get API Keys

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getApiKeys" method="get" path="/api_keys" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetApiKeysRequest req = new GetApiKeysRequest() {
    Subject = "<value>",
};

var res = await sdk.APIKeys.GetApiKeysAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [GetApiKeysRequest](../../Models/Operations/GetApiKeysRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[GetApiKeysResponse](../../Models/Operations/GetApiKeysResponse.md)**

### Errors

| Error Type                                                   | Status Code                                                  | Content Type                                                 |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.GetApiKeysResponseBody        | 400                                                          | application/json                                             |
| Clerk.BackendAPI.Models.Errors.GetAPIKeysAPIKeysResponseBody | 404                                                          | application/json                                             |
| Clerk.BackendAPI.Models.Errors.SDKError                      | 4XX, 5XX                                                     | \*/\*                                                        |

## GetApiKey

Get an API Key by ID

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getApiKey" method="get" path="/api_keys/{apiKeyID}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.APIKeys.GetApiKeyAsync(apiKeyID: "<id>");

// handle response
```

### Parameters

| Parameter          | Type               | Required           | Description        |
| ------------------ | ------------------ | ------------------ | ------------------ |
| `ApiKeyID`         | *string*           | :heavy_check_mark: | N/A                |

### Response

**[GetApiKeyResponse](../../Models/Operations/GetApiKeyResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.GetApiKeyResponseBody        | 400                                                         | application/json                                            |
| Clerk.BackendAPI.Models.Errors.GetAPIKeyAPIKeysResponseBody | 404                                                         | application/json                                            |
| Clerk.BackendAPI.Models.Errors.SDKError                     | 4XX, 5XX                                                    | \*/\*                                                       |

## UpdateApiKey

Update an API Key

### Example Usage

<!-- UsageSnippet language="csharp" operationID="updateApiKey" method="patch" path="/api_keys/{apiKeyID}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.APIKeys.UpdateApiKeyAsync(
    apiKeyID: "<id>",
    requestBody: new UpdateApiKeyRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `ApiKeyID`                                                                    | *string*                                                                      | :heavy_check_mark:                                                            | N/A                                                                           |
| `RequestBody`                                                                 | [UpdateApiKeyRequestBody](../../Models/Operations/UpdateApiKeyRequestBody.md) | :heavy_check_mark:                                                            | N/A                                                                           |

### Response

**[UpdateApiKeyResponse](../../Models/Operations/UpdateApiKeyResponse.md)**

### Errors

| Error Type                                                     | Status Code                                                    | Content Type                                                   |
| -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.UpdateApiKeyResponseBody        | 400                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.UpdateAPIKeyAPIKeysResponseBody | 404                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.SDKError                        | 4XX, 5XX                                                       | \*/\*                                                          |

## DeleteApiKey

Delete an API Key

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteApiKey" method="delete" path="/api_keys/{apiKeyID}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.APIKeys.DeleteApiKeyAsync(apiKeyID: "<id>");

// handle response
```

### Parameters

| Parameter          | Type               | Required           | Description        |
| ------------------ | ------------------ | ------------------ | ------------------ |
| `ApiKeyID`         | *string*           | :heavy_check_mark: | N/A                |

### Response

**[DeleteApiKeyResponse](../../Models/Operations/DeleteApiKeyResponse.md)**

### Errors

| Error Type                                                     | Status Code                                                    | Content Type                                                   |
| -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.DeleteApiKeyResponseBody        | 400                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.DeleteAPIKeyAPIKeysResponseBody | 404                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.SDKError                        | 4XX, 5XX                                                       | \*/\*                                                          |

## GetApiKeySecret

Get an API Key Secret

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getApiKeySecret" method="get" path="/api_keys/{apiKeyID}/secret" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.APIKeys.GetApiKeySecretAsync(apiKeyID: "<id>");

// handle response
```

### Parameters

| Parameter          | Type               | Required           | Description        |
| ------------------ | ------------------ | ------------------ | ------------------ |
| `ApiKeyID`         | *string*           | :heavy_check_mark: | N/A                |

### Response

**[GetApiKeySecretResponse](../../Models/Operations/GetApiKeySecretResponse.md)**

### Errors

| Error Type                                                        | Status Code                                                       | Content Type                                                      |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.GetApiKeySecretResponseBody        | 400                                                               | application/json                                                  |
| Clerk.BackendAPI.Models.Errors.GetAPIKeySecretAPIKeysResponseBody | 404                                                               | application/json                                                  |
| Clerk.BackendAPI.Models.Errors.SDKError                           | 4XX, 5XX                                                          | \*/\*                                                             |

## RevokeApiKey

Revoke an API Key

### Example Usage

<!-- UsageSnippet language="csharp" operationID="revokeApiKey" method="post" path="/api_keys/{apiKeyID}/revoke" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.APIKeys.RevokeApiKeyAsync(
    apiKeyID: "<id>",
    requestBody: new RevokeApiKeyRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `ApiKeyID`                                                                    | *string*                                                                      | :heavy_check_mark:                                                            | N/A                                                                           |
| `RequestBody`                                                                 | [RevokeApiKeyRequestBody](../../Models/Operations/RevokeApiKeyRequestBody.md) | :heavy_check_mark:                                                            | N/A                                                                           |

### Response

**[RevokeApiKeyResponse](../../Models/Operations/RevokeApiKeyResponse.md)**

### Errors

| Error Type                                                     | Status Code                                                    | Content Type                                                   |
| -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.RevokeApiKeyResponseBody        | 400                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.RevokeAPIKeyAPIKeysResponseBody | 404                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.SDKError                        | 4XX, 5XX                                                       | \*/\*                                                          |

## VerifyApiKey

Verify an API Key

### Example Usage

<!-- UsageSnippet language="csharp" operationID="verifyApiKey" method="post" path="/api_keys/verify" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

VerifyApiKeyRequestBody req = new VerifyApiKeyRequestBody() {
    Secret = "<value>",
};

var res = await sdk.APIKeys.VerifyApiKeyAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [VerifyApiKeyRequestBody](../../Models/Operations/VerifyApiKeyRequestBody.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[VerifyApiKeyResponse](../../Models/Operations/VerifyApiKeyResponse.md)**

### Errors

| Error Type                                                     | Status Code                                                    | Content Type                                                   |
| -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.VerifyApiKeyResponseBody        | 400                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.VerifyAPIKeyAPIKeysResponseBody | 404                                                            | application/json                                               |
| Clerk.BackendAPI.Models.Errors.SDKError                        | 4XX, 5XX                                                       | \*/\*                                                          |