# Sessions

## Overview

### Available Operations

* [List](#list) - List all sessions
* [Create](#create) - Create a new active session
* [Get](#get) - Retrieve a session
* [Update](#update) - Update a session
* [Refresh](#refresh) - Refresh a session
* [GetReverification](#getreverification) - Retrieve a reverification
* [Revoke](#revoke) - Revoke a session
* [CreateToken](#createtoken) - Create a session token
* [CreateTokenFromTemplate](#createtokenfromtemplate) - Create a session token from a JWT template

## List

Returns a list of sessions matching the provided criteria.
The sessions are returned sorted by creation date, with the newest sessions appearing first.

Note: This endpoint does not return all sessions that have ever existed. Old and inactive sessions are periodically cleaned up and will not be included in the results.

**Deprecation Notice (2024-01-01):** All parameters were initially considered optional, however
moving forward at least one of `client_id` or `user_id` parameters should be provided.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetSessionList" method="get" path="/sessions" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetSessionListRequest req = new GetSessionListRequest() {
    ClientId = "client_123",
    UserId = "user_456",
    Status = Clerk.BackendAPI.Models.Operations.Status.Active,
    Limit = 20,
    Offset = 10,
};

var res = await sdk.Sessions.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [GetSessionListRequest](../../Models/Operations/GetSessionListRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[GetSessionListResponse](../../Models/Operations/GetSessionListResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Create a new active session for the provided user ID.

**This operation is intended only for use in testing, and is not available for production instances.** If you are looking to generate a user session from the backend,
we recommend using the [Sign-in Tokens](https://clerk.com/docs/reference/backend-api/tag/Sign-in-Tokens#operation/CreateSignInToken) resource instead.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="createSession" method="post" path="/sessions" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateSessionRequestBody? req = null;

var res = await sdk.Sessions.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [CreateSessionRequestBody](../../Models/Operations/CreateSessionRequestBody.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[CreateSessionResponse](../../Models/Operations/CreateSessionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Retrieve the details of a session

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetSession" method="get" path="/sessions/{session_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.GetAsync(sessionId: "sess_1234567890abcdef");

// handle response
```

### Parameters

| Parameter             | Type                  | Required              | Description           | Example               |
| --------------------- | --------------------- | --------------------- | --------------------- | --------------------- |
| `SessionId`           | *string*              | :heavy_check_mark:    | The ID of the session | sess_1234567890abcdef |

### Response

**[GetSessionResponse](../../Models/Operations/GetSessionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Changes when a session expires. Use this to give one session a longer or shorter lifetime than the one configured for your instance, for example to keep a user signed in on a device they chose to remember.

`expire_at` can exceed the instance's session lifetime. The change applies only to this session, so new sign-ins still start from the instance's session lifetime. If `expire_at` is later than the session's `abandon_at`, `abandon_at` moves to the same time. The inactivity timeout, if your instance has one, still applies.

Only active and pending sessions can be updated. Expired, revoked, and other ended sessions can't be revived, and sessions with an actor, such as impersonation and agent sessions, can't be updated. To end a session immediately, revoke it instead.

Take the session ID from the `sid` claim of a verified session token. Never take it from an unverified client request, or a user could change another user's session.

Requires a plan that includes custom session duration.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateSession" method="patch" path="/sessions/{session_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.UpdateAsync(
    sessionId: "<id>",
    requestBody: new UpdateSessionRequestBody() {
        ExpireAt = System.DateTime.Parse("2024-10-26T14:00:58.586Z").ToUniversalTime(),
    }
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `SessionId`                                                                     | *string*                                                                        | :heavy_check_mark:                                                              | The ID of the session                                                           |
| `RequestBody`                                                                   | [UpdateSessionRequestBody](../../Models/Operations/UpdateSessionRequestBody.md) | :heavy_check_mark:                                                              | N/A                                                                             |

### Response

**[UpdateSessionResponse](../../Models/Operations/UpdateSessionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 402, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Refresh

Refreshes a session by creating a new session token. A 401 is returned when there
are validation errors, which signals the SDKs to fall back to the handshake flow.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RefreshSession" method="post" path="/sessions/{session_id}/refresh" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.RefreshAsync(sessionId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `SessionId`                                                                       | *string*                                                                          | :heavy_check_mark:                                                                | The ID of the session                                                             |
| `RequestBody`                                                                     | [RefreshSessionRequestBody](../../Models/Operations/RefreshSessionRequestBody.md) | :heavy_minus_sign:                                                                | Refresh session parameters                                                        |

### Response

**[RefreshSessionResponse](../../Models/Operations/RefreshSessionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetReverification

Retrieve a reverification scoped to a session. A resource server can use this to validate a reverification id it received from its client: confirm it is real, scoped to the expected session, completed, and how fresh each factor is. Single-use / replay detection is the caller's responsibility (the id is stable, so the caller dedups consumed ids).


### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetReverification" method="get" path="/sessions/{session_id}/reverifications/{reverification_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.GetReverificationAsync(
    sessionId: "<id>",
    reverificationId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                           | Type                                                | Required                                            | Description                                         |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| `SessionId`                                         | *string*                                            | :heavy_check_mark:                                  | The ID of the session the reverification belongs to |
| `ReverificationId`                                  | *string*                                            | :heavy_check_mark:                                  | The ID of the reverification                        |

### Response

**[GetReverificationResponse](../../Models/Operations/GetReverificationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Revoke

Sets the status of a session as "revoked", which is an unauthenticated state.
In multi-session mode, a revoked session will still be returned along with its client object, however the user will need to sign in again.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RevokeSession" method="post" path="/sessions/{session_id}/revoke" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.RevokeAsync(sessionId: "sess_1234567890abcdef");

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     | Example                                                                         |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `SessionId`                                                                     | *string*                                                                        | :heavy_check_mark:                                                              | The ID of the session                                                           | sess_1234567890abcdef                                                           |
| `RequestBody`                                                                   | [RevokeSessionRequestBody](../../Models/Operations/RevokeSessionRequestBody.md) | :heavy_minus_sign:                                                              | N/A                                                                             |                                                                                 |

### Response

**[RevokeSessionResponse](../../Models/Operations/RevokeSessionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateToken

Creates a session JSON Web Token (JWT) based on a session.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateSessionToken" method="post" path="/sessions/{session_id}/tokens" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.CreateTokenAsync(sessionId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `SessionId`                                                                               | *string*                                                                                  | :heavy_check_mark:                                                                        | The ID of the session                                                                     |
| `RequestBody`                                                                             | [CreateSessionTokenRequestBody](../../Models/Operations/CreateSessionTokenRequestBody.md) | :heavy_minus_sign:                                                                        | N/A                                                                                       |

### Response

**[CreateSessionTokenResponse](../../Models/Operations/CreateSessionTokenResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateTokenFromTemplate

Creates a JSON Web Token (JWT) based on a session and a JWT Template name defined for your instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateSessionTokenFromTemplate" method="post" path="/sessions/{session_id}/tokens/{template_name}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.CreateTokenFromTemplateAsync(
    sessionId: "ses_123abcd4567",
    templateName: "custom_hasura"
);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       | Example                                                                                                           |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `SessionId`                                                                                                       | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The ID of the session                                                                                             | ses_123abcd4567                                                                                                   |
| `TemplateName`                                                                                                    | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The name of the JWT template defined in your instance (e.g. `custom_hasura`).                                     | custom_hasura                                                                                                     |
| `RequestBody`                                                                                                     | [CreateSessionTokenFromTemplateRequestBody](../../Models/Operations/CreateSessionTokenFromTemplateRequestBody.md) | :heavy_minus_sign:                                                                                                | N/A                                                                                                               |                                                                                                                   |

### Response

**[CreateSessionTokenFromTemplateResponse](../../Models/Operations/CreateSessionTokenFromTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |