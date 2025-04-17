# ExperimentalAccountlessApplications
(*ExperimentalAccountlessApplications*)

## Overview

### Available Operations

* [Create](#create) - Create an accountless application [EXPERIMENTAL]
* [Complete](#complete) - Complete an accountless application [EXPERIMENTAL]

## Create

Creates a new accountless application. [EXPERIMENTAL]

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ExperimentalAccountlessApplications.CreateAsync();

// handle response
```

### Response

**[CreateAccountlessApplicationResponse](../../Models/Operations/CreateAccountlessApplicationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Complete

Completes an accountless application. [EXPERIMENTAL]

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ExperimentalAccountlessApplications.CompleteAsync();

// handle response
```

### Response

**[CompleteAccountlessApplicationResponse](../../Models/Operations/CompleteAccountlessApplicationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |