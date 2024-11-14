# ActorTokens
(*ActorTokens*)

## Overview

### Available Operations

* [Create](#create) - Create actor token
* [Revoke](#revoke) - Revoke actor token

## Create

Create an actor token that can be used to impersonate the given user.
The `actor` parameter needs to include at least a "sub" key whose value is the ID of the actor (impersonating) user.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateActorTokenRequestBody req = new CreateActorTokenRequestBody() {
    UserId = "<id>",
    Actor = new Models.Operations.Actor() {},
};

var res = await sdk.ActorTokens.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [CreateActorTokenRequestBody](../../Models/Operations/CreateActorTokenRequestBody.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[CreateActorTokenResponse](../../Models/Operations/CreateActorTokenResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 402, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Revoke

Revokes a pending actor token.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ActorTokens.RevokeAsync(actorTokenId: "<id>");

// handle response
```

### Parameters

| Parameter                                | Type                                     | Required                                 | Description                              |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| `ActorTokenId`                           | *string*                                 | :heavy_check_mark:                       | The ID of the actor token to be revoked. |

### Response

**[RevokeActorTokenResponse](../../Models/Operations/RevokeActorTokenResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |