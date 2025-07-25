# OauthAccessTokens
(*OauthAccessTokens*)

## Overview

### Available Operations

* [Verify](#verify) - Verify an OAuth Access Token

## Verify

Verify an OAuth Access Token

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

VerifyOAuthAccessTokenRequestBody req = new VerifyOAuthAccessTokenRequestBody() {
    AccessToken = "XXXXXXXXXXXXXX",
};

var res = await sdk.OauthAccessTokens.VerifyAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `request`                                                                                         | [VerifyOAuthAccessTokenRequestBody](../../Models/Operations/VerifyOAuthAccessTokenRequestBody.md) | :heavy_check_mark:                                                                                | The request object to use for the request.                                                        |

### Response

**[VerifyOAuthAccessTokenResponse](../../Models/Operations/VerifyOAuthAccessTokenResponse.md)**

### Errors

| Error Type                                                                         | Status Code                                                                        | Content Type                                                                       |
| ---------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.VerifyOAuthAccessTokenResponseBody                  | 400                                                                                | application/json                                                                   |
| Clerk.BackendAPI.Models.Errors.VerifyOAuthAccessTokenOauthAccessTokensResponseBody | 404                                                                                | application/json                                                                   |
| Clerk.BackendAPI.Models.Errors.SDKError                                            | 4XX, 5XX                                                                           | \*/\*                                                                              |