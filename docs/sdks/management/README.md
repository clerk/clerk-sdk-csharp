# Management
(*Management*)

## Overview

### Available Operations

* [UpsertUser](#upsertuser) - Upsert a user
* [CreateOrganization](#createorganization) - Create an organization
* [CreateApplication](#createapplication) - Create an application (instance)

## UpsertUser

Upsert a user using the provided information. If a user with the same email_address exists, it will be updated. Otherwise, a new user will be created.
This endpoint is internal and requires a specific management token for authorization.


### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi();

ManagementUpsertUserRequest req = new ManagementUpsertUserRequest() {
    EmailAddress = "Roger_OReilly-Dibbert10@hotmail.com",
    FirstName = "Diana",
    LastName = "Schmidt-Kutch",
};

var res = await sdk.Management.UpsertUserAsync(
    security: new ManagementUpsertUserSecurity() {
        ManagementToken = "<YOUR_BEARER_TOKEN_HERE>",
    },
    request: req
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [ManagementUpsertUserRequest](../../Models/Components/ManagementUpsertUserRequest.md)   | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |
| `security`                                                                              | [ManagementUpsertUserSecurity](../../Models/Operations/ManagementUpsertUserSecurity.md) | :heavy_check_mark:                                                                      | The security requirements to use for the request.                                       |

### Response

**[ManagementUpsertUserResponse](../../Models/Operations/ManagementUpsertUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateOrganization

Create a new organization.
This endpoint is internal and requires a specific management token for authorization.


### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi();

ManagementCreateOrganizationRequest req = new ManagementCreateOrganizationRequest() {
    Name = "<value>",
    Slug = "<value>",
};

var res = await sdk.Management.CreateOrganizationAsync(
    security: new ManagementCreateOrganizationSecurity() {
        ManagementToken = "<YOUR_BEARER_TOKEN_HERE>",
    },
    request: req
);

// handle response
```

### Parameters

| Parameter                                                                                               | Type                                                                                                    | Required                                                                                                | Description                                                                                             |
| ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| `request`                                                                                               | [ManagementCreateOrganizationRequest](../../Models/Components/ManagementCreateOrganizationRequest.md)   | :heavy_check_mark:                                                                                      | The request object to use for the request.                                                              |
| `security`                                                                                              | [ManagementCreateOrganizationSecurity](../../Models/Operations/ManagementCreateOrganizationSecurity.md) | :heavy_check_mark:                                                                                      | The security requirements to use for the request.                                                       |

### Response

**[ManagementCreateOrganizationResponse](../../Models/Operations/ManagementCreateOrganizationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateApplication

Create a new application (instance).
This endpoint is internal and requires a specific management token for authorization.


### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi();

ManagementCreateApplicationRequest req = new ManagementCreateApplicationRequest() {
    Name = "<value>",
    OwnerId = "<id>",
    PlanId = "<id>",
};

var res = await sdk.Management.CreateApplicationAsync(
    security: new ManagementCreateApplicationSecurity() {
        ManagementToken = "<YOUR_BEARER_TOKEN_HERE>",
    },
    request: req
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `request`                                                                                             | [ManagementCreateApplicationRequest](../../Models/Components/ManagementCreateApplicationRequest.md)   | :heavy_check_mark:                                                                                    | The request object to use for the request.                                                            |
| `security`                                                                                            | [ManagementCreateApplicationSecurity](../../Models/Operations/ManagementCreateApplicationSecurity.md) | :heavy_check_mark:                                                                                    | The security requirements to use for the request.                                                     |

### Response

**[ManagementCreateApplicationResponse](../../Models/Operations/ManagementCreateApplicationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |