# Sessions
(*Sessions*)

## Overview

### Available Operations

* [List](#list) - List all sessions
* [Create](#create) - Create a new active session
* [Get](#get) - Retrieve a session
* [Refresh](#refresh) - Refresh a session
* [Revoke](#revoke) - Revoke a session
* [~~Verify~~](#verify) - Verify a session :warning: **Deprecated**
* [CreateToken](#createtoken) - Create a session token
* [CreateTokenFromTemplate](#createtokenfromtemplate) - Create a session token from a jwt template

## List

Returns a list of all sessions.
The sessions are returned sorted by creation date, with the newest sessions appearing first.
**Deprecation Notice (2024-01-01):** All parameters were initially considered optional, however
moving forward at least one of `client_id` or `user_id` parameters should be provided.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetSessionListRequest req = new GetSessionListRequest() {
    ClientId = "client_123",
    UserId = "user_456",
    Status = Status.Active,
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

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateSessionRequestBody req = new CreateSessionRequestBody() {
    UserId = "<id>",
};

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

## Refresh

Refreshes a session by creating a new session token. A 401 is returned when there
are validation errors, which signals the SDKs to fallback to the handshake flow.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.RefreshAsync(
    sessionId: "<id>",
    requestBody: new RefreshSessionRequestBody() {
        ExpiredToken = "<value>",
        RefreshToken = "<value>",
        RequestOrigin = "<value>",
    }
);

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
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Revoke

Sets the status of a session as "revoked", which is an unauthenticated state.
In multi-session mode, a revoked session will still be returned along with its client object, however the user will need to sign in again.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.RevokeAsync(sessionId: "sess_1234567890abcdef");

// handle response
```

### Parameters

| Parameter             | Type                  | Required              | Description           | Example               |
| --------------------- | --------------------- | --------------------- | --------------------- | --------------------- |
| `SessionId`           | *string*              | :heavy_check_mark:    | The ID of the session | sess_1234567890abcdef |

### Response

**[RevokeSessionResponse](../../Models/Operations/RevokeSessionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~Verify~~

Returns the session if it is authenticated, otherwise returns an error.
WARNING: This endpoint is deprecated and will be removed in future versions. We strongly recommend switching to networkless verification using short-lived session tokens,
         which is implemented transparently in all recent SDK versions (e.g. [NodeJS SDK](https://clerk.com/docs/backend-requests/handling/nodejs#require-auth)).
         For more details on how networkless verification works, refer to our [Session Tokens documentation](https://clerk.com/docs/backend-requests/resources/session-tokens).

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.VerifyAsync(
    sessionId: "sess_w8q4g9s60j28fghv00f3",
    requestBody: new VerifySessionRequestBody() {
        Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzZXNzaW9uX2lkIjoic2Vzc193OHF4ZzZzNm9qMjhmZ2h2MDBmMyIsImlhdCI6MTU4MjY0OTg2Mn0.J4KP2L6bEZ6YccHFW4E2vKbOLw_mmO0gF_GNRw-wtLM",
    }
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     | Example                                                                         |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `SessionId`                                                                     | *string*                                                                        | :heavy_check_mark:                                                              | The ID of the session                                                           | sess_w8q4g9s60j28fghv00f3                                                       |
| `RequestBody`                                                                   | [VerifySessionRequestBody](../../Models/Operations/VerifySessionRequestBody.md) | :heavy_minus_sign:                                                              | Parameters.                                                                     |                                                                                 |

### Response

**[VerifySessionResponse](../../Models/Operations/VerifySessionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 410                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateToken

Creates a session JSON Web Token (JWT) based on a session.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.CreateTokenAsync(
    sessionId: "<id>",
    requestBody: new CreateSessionTokenRequestBody() {}
);

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
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateTokenFromTemplate

Creates a JSON Web Token(JWT) based on a session and a JWT Template name defined for your instance

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.CreateTokenFromTemplateAsync(
    sessionId: "ses_123abcd4567",
    templateName: "custom_hasura",
    requestBody: new CreateSessionTokenFromTemplateRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       | Example                                                                                                           |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `SessionId`                                                                                                       | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The ID of the session                                                                                             | ses_123abcd4567                                                                                                   |
| `TemplateName`                                                                                                    | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The name of the JWT Template defined in your instance (e.g. `custom_hasura`).                                     | custom_hasura                                                                                                     |
| `RequestBody`                                                                                                     | [CreateSessionTokenFromTemplateRequestBody](../../Models/Operations/CreateSessionTokenFromTemplateRequestBody.md) | :heavy_minus_sign:                                                                                                | N/A                                                                                                               |                                                                                                                   |

### Response

**[CreateSessionTokenFromTemplateResponse](../../Models/Operations/CreateSessionTokenFromTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |