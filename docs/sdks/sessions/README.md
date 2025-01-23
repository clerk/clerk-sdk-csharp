# Sessions
(*Sessions*)

## Overview

The Session object is an abstraction over an HTTP session.
It models the period of information exchange between a user and the server.
Sessions are created when a user successfully goes through the sign in or sign up flows.
<https://clerk.com/docs/reference/clerkjs/session>

### Available Operations

* [List](#list) - List all sessions
* [CreateSession](#createsession) - Create a new active session
* [Get](#get) - Retrieve a session
* [Revoke](#revoke) - Revoke a session
* [~~Verify~~](#verify) - Verify a session :warning: **Deprecated**
* [CreateSessionToken](#createsessiontoken) - Create a session token
* [CreateToken](#createtoken) - Create a session token from a jwt template

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

## CreateSession

Create a new active session for the provided user ID.

This operation is only available for Clerk Development instances.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateSessionRequestBody req = new CreateSessionRequestBody() {};

var res = await sdk.Sessions.CreateSessionAsync(req);

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
         which is implemented transparently in all recent SDK versions (e.g. [NodeJS SDK](https://clerk.com/docs/backend-requests/handling/nodejs#clerk-express-require-auth)).
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

## CreateSessionToken

Creates a session JSON Web Token (JWT) based on a session.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.CreateSessionTokenAsync(
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

## CreateToken

Creates a JSON Web Token(JWT) based on a session and a JWT Template name defined for your instance

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Sessions.CreateTokenAsync(
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