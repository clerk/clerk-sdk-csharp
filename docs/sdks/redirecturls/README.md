# RedirectUrls
(*RedirectUrls*)

## Overview

### Available Operations

* [List](#list) - List all redirect URLs
* [Create](#create) - Create a redirect URL
* [Get](#get) - Retrieve a redirect URL
* [Delete](#delete) - Delete a redirect URL

## List

Lists all whitelisted redirect_urls for the instance

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RedirectUrls.ListAsync();

// handle response
```

### Response

**[ListRedirectURLsResponse](../../Models/Operations/ListRedirectURLsResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |

## Create

Create a redirect URL

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateRedirectURLRequestBody req = new CreateRedirectURLRequestBody() {};

var res = await sdk.RedirectUrls.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [CreateRedirectURLRequestBody](../../Models/Operations/CreateRedirectURLRequestBody.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[CreateRedirectURLResponse](../../Models/Operations/CreateRedirectURLResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Retrieve the details of the redirect URL with the given ID

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RedirectUrls.GetAsync(id: "<id>");

// handle response
```

### Parameters

| Parameter                  | Type                       | Required                   | Description                |
| -------------------------- | -------------------------- | -------------------------- | -------------------------- |
| `Id`                       | *string*                   | :heavy_check_mark:         | The ID of the redirect URL |

### Response

**[GetRedirectURLResponse](../../Models/Operations/GetRedirectURLResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Remove the selected redirect URL from the whitelist of the instance

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RedirectUrls.DeleteAsync(id: "<id>");

// handle response
```

### Parameters

| Parameter                  | Type                       | Required                   | Description                |
| -------------------------- | -------------------------- | -------------------------- | -------------------------- |
| `Id`                       | *string*                   | :heavy_check_mark:         | The ID of the redirect URL |

### Response

**[DeleteRedirectURLResponse](../../Models/Operations/DeleteRedirectURLResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |