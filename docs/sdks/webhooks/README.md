# Webhooks
(*Webhooks*)

## Overview

### Available Operations

* [CreateSvixApp](#createsvixapp) - Create a Svix app
* [DeleteSvixApp](#deletesvixapp) - Delete a Svix app
* [GenerateSvixAuthURL](#generatesvixauthurl) - Create a Svix Dashboard URL

## CreateSvixApp

Create a Svix app and associate it with the current instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateSvixApp" method="post" path="/webhooks/svix" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Webhooks.CreateSvixAppAsync();

// handle response
```

### Response

**[CreateSvixAppResponse](../../Models/Operations/CreateSvixAppResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteSvixApp

Delete a Svix app and disassociate it from the current instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteSvixApp" method="delete" path="/webhooks/svix" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Webhooks.DeleteSvixAppAsync();

// handle response
```

### Response

**[DeleteSvixAppResponse](../../Models/Operations/DeleteSvixAppResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GenerateSvixAuthURL

Generate a new url for accessing the Svix's management dashboard for that particular instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GenerateSvixAuthURL" method="post" path="/webhooks/svix_url" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Webhooks.GenerateSvixAuthURLAsync();

// handle response
```

### Response

**[GenerateSvixAuthURLResponse](../../Models/Operations/GenerateSvixAuthURLResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |