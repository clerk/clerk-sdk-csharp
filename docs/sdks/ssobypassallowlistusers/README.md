# SsoBypassAllowlistUsers

## Overview

### Available Operations

* [List](#list) - List the SSO bypass allowlist
* [Create](#create) - Add a user to the SSO bypass allowlist
* [Delete](#delete) - Remove a user from the SSO bypass allowlist

## List

Returns the users who may verify an email code instead of reaching their identity provider when
enterprise SSO is unreachable.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListSSOBypassAllowlistUsers" method="get" path="/sso_bypass_allowlist_users" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SsoBypassAllowlistUsers.ListAsync();

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `EnterpriseConnectionId`                                          | *string*                                                          | :heavy_minus_sign:                                                | Restrict the list to the users this enterprise connection serves. |

### Response

**[ListSSOBypassAllowlistUsersResponse](../../Models/Operations/ListSSOBypassAllowlistUsersResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Puts a user on the allowlist. The request is rejected unless the user holds a verified email
address on a domain one of the instance's enterprise connections serves.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateSSOBypassAllowlistUser" method="post" path="/sso_bypass_allowlist_users" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateSSOBypassAllowlistUserRequestBody req = new CreateSSOBypassAllowlistUserRequestBody() {
    UserId = "<id>",
};

var res = await sdk.SsoBypassAllowlistUsers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                     | [CreateSSOBypassAllowlistUserRequestBody](../../Models/Operations/CreateSSOBypassAllowlistUserRequestBody.md) | :heavy_check_mark:                                                                                            | The request object to use for the request.                                                                    |

### Response

**[CreateSSOBypassAllowlistUserResponse](../../Models/Operations/CreateSSOBypassAllowlistUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Removes the user from the allowlist, across every enterprise connection that serves them.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteSSOBypassAllowlistUser" method="delete" path="/sso_bypass_allowlist_users/{userID}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SsoBypassAllowlistUsers.DeleteAsync(userID: "<id>");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `UserID`                       | *string*                       | :heavy_check_mark:             | The ID of the allowlisted user |

### Response

**[DeleteSSOBypassAllowlistUserResponse](../../Models/Operations/DeleteSSOBypassAllowlistUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |