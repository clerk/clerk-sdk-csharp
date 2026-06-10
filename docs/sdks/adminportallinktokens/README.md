# AdminPortalLinkTokens

## Overview

### Available Operations

* [CreateAdminPortalLinkToken](#createadminportallinktoken) - Create an Admin Portal Link Token
* [RevokeAdminPortalLinkToken](#revokeadminportallinktoken) - Revoke an Admin Portal Link Token

## CreateAdminPortalLinkToken

Create an Admin Portal Link Token

### Example Usage

<!-- UsageSnippet language="csharp" operationID="createAdminPortalLinkToken" method="post" path="/admin_portal_link_tokens" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateAdminPortalLinkTokenRequestBody req = new CreateAdminPortalLinkTokenRequestBody() {};

var res = await sdk.AdminPortalLinkTokens.CreateAdminPortalLinkTokenAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                 | [CreateAdminPortalLinkTokenRequestBody](../../Models/Operations/CreateAdminPortalLinkTokenRequestBody.md) | :heavy_check_mark:                                                                                        | The request object to use for the request.                                                                |

### Response

**[CreateAdminPortalLinkTokenResponse](../../Models/Operations/CreateAdminPortalLinkTokenResponse.md)**

### Errors

| Error Type                                                                                            | Status Code                                                                                           | Content Type                                                                                          |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.CreateAdminPortalLinkTokenResponseBody                                 | 400                                                                                                   | application/json                                                                                      |
| Clerk.BackendAPI.Models.Errors.CreateAdminPortalLinkTokenAdminPortalLinkTokensResponseBody            | 401                                                                                                   | application/json                                                                                      |
| Clerk.BackendAPI.Models.Errors.CreateAdminPortalLinkTokenAdminPortalLinkTokensResponseResponseBody    | 403                                                                                                   | application/json                                                                                      |
| Clerk.BackendAPI.Models.Errors.CreateAdminPortalLinkTokenAdminPortalLinkTokensResponse409ResponseBody | 409                                                                                                   | application/json                                                                                      |
| Clerk.BackendAPI.Models.Errors.SDKError                                                               | 4XX, 5XX                                                                                              | \*/\*                                                                                                 |

## RevokeAdminPortalLinkToken

Revoke an Admin Portal Link Token

### Example Usage

<!-- UsageSnippet language="csharp" operationID="revokeAdminPortalLinkToken" method="post" path="/admin_portal_link_tokens/{adminPortalLinkTokenID}/revoke" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.AdminPortalLinkTokens.RevokeAdminPortalLinkTokenAsync(
    adminPortalLinkTokenID: "<id>",
    requestBody: new RevokeAdminPortalLinkTokenRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `AdminPortalLinkTokenID`                                                                                  | *string*                                                                                                  | :heavy_check_mark:                                                                                        | N/A                                                                                                       |
| `RequestBody`                                                                                             | [RevokeAdminPortalLinkTokenRequestBody](../../Models/Operations/RevokeAdminPortalLinkTokenRequestBody.md) | :heavy_check_mark:                                                                                        | N/A                                                                                                       |

### Response

**[RevokeAdminPortalLinkTokenResponse](../../Models/Operations/RevokeAdminPortalLinkTokenResponse.md)**

### Errors

| Error Type                                                                                            | Status Code                                                                                           | Content Type                                                                                          |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| Clerk.BackendAPI.Models.Errors.RevokeAdminPortalLinkTokenResponseBody                                 | 400                                                                                                   | application/json                                                                                      |
| Clerk.BackendAPI.Models.Errors.RevokeAdminPortalLinkTokenAdminPortalLinkTokensResponseBody            | 401                                                                                                   | application/json                                                                                      |
| Clerk.BackendAPI.Models.Errors.RevokeAdminPortalLinkTokenAdminPortalLinkTokensResponseResponseBody    | 403                                                                                                   | application/json                                                                                      |
| Clerk.BackendAPI.Models.Errors.RevokeAdminPortalLinkTokenAdminPortalLinkTokensResponse404ResponseBody | 404                                                                                                   | application/json                                                                                      |
| Clerk.BackendAPI.Models.Errors.SDKError                                                               | 4XX, 5XX                                                                                              | \*/\*                                                                                                 |