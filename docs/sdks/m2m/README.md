# M2m

## Overview

### Available Operations

* [CreateToken](#createtoken) - Create a M2M Token
* [ListTokens](#listtokens) - Get M2M Tokens
* [RevokeToken](#revoketoken) - Revoke a M2M Token
* [VerifyToken](#verifytoken) - Verify a M2M Token

## CreateToken

Creates a new M2M Token. Must be authenticated via a Machine Secret Key.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="createM2MToken" method="post" path="/m2m_tokens" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateM2MTokenRequestBody req = new CreateM2MTokenRequestBody() {};

var res = await sdk.M2m.CreateTokenAsync(req);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `request`                                                                         | [CreateM2MTokenRequestBody](../../Models/Operations/CreateM2MTokenRequestBody.md) | :heavy_check_mark:                                                                | The request object to use for the request.                                        |

### Response

**[CreateM2MTokenResponse](../../Models/Operations/CreateM2MTokenResponse.md)**

### Errors

| Error Type                                                   | Status Code                                                  | Content Type                                                 |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.CreateM2MTokenResponseBody    | 400                                                          | application/json                                             |
| Clerk.BackendAPI.Models.Errors.CreateM2MTokenM2mResponseBody | 409                                                          | application/json                                             |
| Clerk.BackendAPI.Models.Errors.SDKError                      | 4XX, 5XX                                                     | \*/\*                                                        |

## ListTokens

Fetches M2M tokens for a specific machine.

This endpoint can be authenticated by either a Machine Secret Key or by a Clerk Secret Key.

- When fetching M2M tokens with a Machine Secret Key, only tokens associated with the authenticated machine can be retrieved.
- When fetching M2M tokens with a Clerk Secret Key, tokens for any machine in the instance can be retrieved.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getM2MTokens" method="get" path="/m2m_tokens" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetM2MTokensRequest req = new GetM2MTokensRequest() {
    Subject = "<value>",
};

var res = await sdk.M2m.ListTokensAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [GetM2MTokensRequest](../../Models/Operations/GetM2MTokensRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[GetM2MTokensResponse](../../Models/Operations/GetM2MTokensResponse.md)**

### Errors

| Error Type                                                         | Status Code                                                        | Content Type                                                       |
| ------------------------------------------------------------------ | ------------------------------------------------------------------ | ------------------------------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.GetM2MTokensResponseBody            | 400                                                                | application/json                                                   |
| Clerk.BackendAPI.Models.Errors.GetM2MTokensM2mResponseBody         | 403                                                                | application/json                                                   |
| Clerk.BackendAPI.Models.Errors.GetM2MTokensM2mResponseResponseBody | 404                                                                | application/json                                                   |
| Clerk.BackendAPI.Models.Errors.SDKError                            | 4XX, 5XX                                                           | \*/\*                                                              |

## RevokeToken

Revokes a M2M Token.

This endpoint can be authenticated by either a Machine Secret Key or by a Clerk Secret Key.

- When revoking a M2M Token with a Machine Secret Key, the token must managed by the Machine associated with the Machine Secret Key.
- When revoking a M2M Token with a Clerk Secret Key, any token on the Instance can be revoked.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="revokeM2MToken" method="post" path="/m2m_tokens/{m2m_token_id}/revoke" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.M2m.RevokeTokenAsync(
    m2mTokenId: "<id>",
    requestBody: new RevokeM2MTokenRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `M2mTokenId`                                                                      | *string*                                                                          | :heavy_check_mark:                                                                | N/A                                                                               |
| `RequestBody`                                                                     | [RevokeM2MTokenRequestBody](../../Models/Operations/RevokeM2MTokenRequestBody.md) | :heavy_check_mark:                                                                | N/A                                                                               |

### Response

**[RevokeM2MTokenResponse](../../Models/Operations/RevokeM2MTokenResponse.md)**

### Errors

| Error Type                                                   | Status Code                                                  | Content Type                                                 |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.RevokeM2MTokenResponseBody    | 400                                                          | application/json                                             |
| Clerk.BackendAPI.Models.Errors.RevokeM2MTokenM2mResponseBody | 404                                                          | application/json                                             |
| Clerk.BackendAPI.Models.Errors.SDKError                      | 4XX, 5XX                                                     | \*/\*                                                        |

## VerifyToken

Verifies a M2M Token.

This endpoint can be authenticated by either a Machine Secret Key or by a Clerk Secret Key.

- When verifying a M2M Token with a Machine Secret Key, the token must be granted access to the Machine associated with the Machine Secret Key.
- When verifying a M2M Token with a Clerk Secret Key, any token on the Instance can be verified.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="verifyM2MToken" method="post" path="/m2m_tokens/verify" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

VerifyM2MTokenRequestBody req = new VerifyM2MTokenRequestBody() {
    Token = "<value>",
};

var res = await sdk.M2m.VerifyTokenAsync(req);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `request`                                                                         | [VerifyM2MTokenRequestBody](../../Models/Operations/VerifyM2MTokenRequestBody.md) | :heavy_check_mark:                                                                | The request object to use for the request.                                        |

### Response

**[VerifyM2MTokenResponse](../../Models/Operations/VerifyM2MTokenResponse.md)**

### Errors

| Error Type                                                   | Status Code                                                  | Content Type                                                 |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.VerifyM2MTokenResponseBody    | 400                                                          | application/json                                             |
| Clerk.BackendAPI.Models.Errors.VerifyM2MTokenM2mResponseBody | 404                                                          | application/json                                             |
| Clerk.BackendAPI.Models.Errors.SDKError                      | 4XX, 5XX                                                     | \*/\*                                                        |