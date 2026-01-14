# RoleSets

## Overview

### Available Operations

* [List](#list) - Get a list of role sets
* [Create](#create) - Create a role set
* [Get](#get) - Retrieve a role set
* [Update](#update) - Update a role set
* [Replace](#replace) - Replace a role set
* [AddRoles](#addroles) - Add roles to a role set
* [ReplaceRole](#replacerole) - Replace a role in a role set

## List

Returns a list of role sets for the instance.
Results can be paginated using the optional `limit` and `offset` query parameters.
The role sets are ordered by descending creation date by default.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListRoleSets" method="get" path="/role_sets" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RoleSets.ListAsync(
    orderBy: "-created_at",
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | Type                                                                                                                                                                                                                                                                                                                                                                                                                                                                           | Required                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                    | Example                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `Query`                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | *string*                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                                                             | Returns role sets with ID, name, or key that match the given query.<br/>Uses exact match for role set ID and partial match for name and key.                                                                                                                                                                                                                                                                                                                                   |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| `OrderBy`                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | *string*                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                                                             | Allows to return role sets in a particular order.<br/>At the moment, you can order the returned role sets by their `created_at`, `name`, or `key`.<br/>In order to specify the direction, you can use the `+/-` symbols prepended in the property to order by.<br/>For example, if you want role sets to be returned in descending order according to their `created_at` property, you can use `-created_at`.<br/>If you don't use `+` or `-`, then `+` is implied.<br/>Defaults to `-created_at`. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | *long*                                                                                                                                                                                                                                                                                                                                                                                                                                                                         | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                                                             | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                                                                                                                                                                                                                                                                          | 20                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| `Offset`                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | *long*                                                                                                                                                                                                                                                                                                                                                                                                                                                                         | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                                                             | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                                                                                                                                                                                                                                                              | 10                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |

### Response

**[ListRoleSetsResponse](../../Models/Operations/ListRoleSetsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Creates a new role set with the given name and roles.
The key must be unique for the instance and start with the 'role_set:' prefix, followed by lowercase alphanumeric characters and underscores only.
You must provide at least one role and specify a default role key and creator role key.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateRoleSet" method="post" path="/role_sets" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateRoleSetRequestBody req = new CreateRoleSetRequestBody() {
    Name = "<value>",
    DefaultRoleKey = "<value>",
    CreatorRoleKey = "<value>",
    Roles = new List<string>() {
        "<value 1>",
        "<value 2>",
    },
};

var res = await sdk.RoleSets.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [CreateRoleSetRequestBody](../../Models/Operations/CreateRoleSetRequestBody.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[CreateRoleSetResponse](../../Models/Operations/CreateRoleSetResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 402, 403, 404, 422               | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Retrieves an existing role set by its key or ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetRoleSet" method="get" path="/role_sets/{role_set_key_or_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RoleSets.GetAsync(roleSetKeyOrId: "<id>");

// handle response
```

### Parameters

| Parameter                     | Type                          | Required                      | Description                   |
| ----------------------------- | ----------------------------- | ----------------------------- | ----------------------------- |
| `RoleSetKeyOrId`              | *string*                      | :heavy_check_mark:            | The key or ID of the role set |

### Response

**[GetRoleSetResponse](../../Models/Operations/GetRoleSetResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates an existing role set.
You can update the name, key, description, type, default role, or creator role.
All parameters are optional - you can update only the fields you want to change.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateRoleSet" method="patch" path="/role_sets/{role_set_key_or_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RoleSets.UpdateAsync(
    roleSetKeyOrId: "<id>",
    requestBody: new UpdateRoleSetRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `RoleSetKeyOrId`                                                                | *string*                                                                        | :heavy_check_mark:                                                              | The key or ID of the role set to update                                         |
| `RequestBody`                                                                   | [UpdateRoleSetRequestBody](../../Models/Operations/UpdateRoleSetRequestBody.md) | :heavy_check_mark:                                                              | N/A                                                                             |

### Response

**[UpdateRoleSetResponse](../../Models/Operations/UpdateRoleSetResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Replace

Replaces a role set with another role set. This is functionally equivalent to deleting
the role set but allows for atomic replacement with migration support.
Organizations using this role set will be migrated to the destination role set.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ReplaceRoleSet" method="post" path="/role_sets/{role_set_key_or_id}/replace" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RoleSets.ReplaceAsync(
    roleSetKeyOrId: "<id>",
    requestBody: new ReplaceRoleSetRequestBody() {
        DestRoleSetKey = "<value>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `RoleSetKeyOrId`                                                                  | *string*                                                                          | :heavy_check_mark:                                                                | The key or ID of the role set to replace                                          |
| `RequestBody`                                                                     | [ReplaceRoleSetRequestBody](../../Models/Operations/ReplaceRoleSetRequestBody.md) | :heavy_check_mark:                                                                | N/A                                                                               |

### Response

**[ReplaceRoleSetResponse](../../Models/Operations/ReplaceRoleSetResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## AddRoles

Adds one or more roles to an existing role set.
You can optionally update the default role or creator role when adding new roles.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="AddRolesToRoleSet" method="post" path="/role_sets/{role_set_key_or_id}/roles" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RoleSets.AddRolesAsync(
    roleSetKeyOrId: "<id>",
    requestBody: new AddRolesToRoleSetRequestBody() {
        RoleKeys = new List<string>() {
            "<value 1>",
            "<value 2>",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `RoleSetKeyOrId`                                                                        | *string*                                                                                | :heavy_check_mark:                                                                      | The key or ID of the role set                                                           |
| `RequestBody`                                                                           | [AddRolesToRoleSetRequestBody](../../Models/Operations/AddRolesToRoleSetRequestBody.md) | :heavy_check_mark:                                                                      | N/A                                                                                     |

### Response

**[AddRolesToRoleSetResponse](../../Models/Operations/AddRolesToRoleSetResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ReplaceRole

Replaces a role in a role set with another role. This atomically removes
the source role and reassigns any members to the destination role.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ReplaceRoleInRoleSet" method="post" path="/role_sets/{role_set_key_or_id}/roles/replace" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.RoleSets.ReplaceRoleAsync(
    roleSetKeyOrId: "<id>",
    requestBody: new ReplaceRoleInRoleSetRequestBody() {
        RoleKey = "<value>",
        ToRoleKey = "<value>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `RoleSetKeyOrId`                                                                              | *string*                                                                                      | :heavy_check_mark:                                                                            | The key or ID of the role set                                                                 |
| `RequestBody`                                                                                 | [ReplaceRoleInRoleSetRequestBody](../../Models/Operations/ReplaceRoleInRoleSetRequestBody.md) | :heavy_check_mark:                                                                            | N/A                                                                                           |

### Response

**[ReplaceRoleInRoleSetResponse](../../Models/Operations/ReplaceRoleInRoleSetResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |