# SignInTokens

## Overview

### Available Operations

* [Create](#create) - Create sign-in token
* [Revoke](#revoke) - Revoke the given sign-in token

## Create

Creates a new sign-in token and associates it with the given user.
By default, sign-in tokens expire in 30 days.
You can optionally supply a different duration in seconds using the `expires_in_seconds` property.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateSignInToken" method="post" path="/sign_in_tokens" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateSignInTokenRequestBody req = new CreateSignInTokenRequestBody() {
    UserId = "user_12345",
};

var res = await sdk.SignInTokens.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [CreateSignInTokenRequestBody](../../Models/Operations/CreateSignInTokenRequestBody.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[CreateSignInTokenResponse](../../Models/Operations/CreateSignInTokenResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Revoke

Revokes a pending sign-in token

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RevokeSignInToken" method="post" path="/sign_in_tokens/{sign_in_token_id}/revoke" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SignInTokens.RevokeAsync(signInTokenId: "tok_test_1234567890");

// handle response
```

### Parameters

| Parameter                                 | Type                                      | Required                                  | Description                               | Example                                   |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| `SignInTokenId`                           | *string*                                  | :heavy_check_mark:                        | The ID of the sign-in token to be revoked | tok_test_1234567890                       |

### Response

**[RevokeSignInTokenResponse](../../Models/Operations/RevokeSignInTokenResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |