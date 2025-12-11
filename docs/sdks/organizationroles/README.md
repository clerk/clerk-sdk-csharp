# OrganizationRoles

## Overview

### Available Operations

* [List](#list) - Get a list of organization roles
* [Create](#create) - Create an organization role
* [Get](#get) - Retrieve an organization role
* [Update](#update) - Update an organization role
* [Delete](#delete) - Delete an organization role
* [AssignPermission](#assignpermission) - Assign a permission to an organization role
* [RemovePermission](#removepermission) - Remove a permission from an organization role

## List

This request returns the list of organization roles for the instance.
Results can be paginated using the optional `limit` and `offset` query parameters.
The organization roles are ordered by descending creation date.
Most recent roles will be returned first.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListOrganizationRoles" method="get" path="/organization_roles" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationRoles.ListAsync(
    orderBy: "-created_at",
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 | Type                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | Required                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               | Example                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Query`                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   | *string*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | Returns organization roles with ID, name, or key that match the given query.<br/>Uses exact match for organization role ID and partial match for name and key.                                                                                                                                                                                                                                                                                                                                            |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| `OrderBy`                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | Allows to return organization roles in a particular order.<br/>At the moment, you can order the returned organization roles by their `created_at`, `name`, or `key`.<br/>In order to specify the direction, you can use the `+/-` symbols prepended in the property to order by.<br/>For example, if you want organization roles to be returned in descending order according to their `created_at` property, you can use `-created_at`.<br/>If you don't use `+` or `-`, then `+` is implied.<br/>Defaults to `-created_at`. |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   | *long*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                                                                                                                                                                                                                                                                                                     | 20                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| `Offset`                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | *long*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                                                                                                                                                                                                                                                                                         | 10                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |

### Response

**[ListOrganizationRolesResponse](../../Models/Operations/ListOrganizationRolesResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Creates a new organization role with the given name and permissions for an instance.
The key must be unique for the instance and start with the 'org:' prefix, followed by lowercase alphanumeric characters and underscores only.
You can optionally provide a description for the role and specify whether it should be included in the initial role set.
Organization roles support permissions that can be assigned to control access within the organization.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateOrganizationRole" method="post" path="/organization_roles" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateOrganizationRoleRequestBody req = new CreateOrganizationRoleRequestBody() {
    Name = "<value>",
    Key = "<key>",
};

var res = await sdk.OrganizationRoles.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `request`                                                                                         | [CreateOrganizationRoleRequestBody](../../Models/Operations/CreateOrganizationRoleRequestBody.md) | :heavy_check_mark:                                                                                | The request object to use for the request.                                                        |

### Response

**[CreateOrganizationRoleResponse](../../Models/Operations/CreateOrganizationRoleResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 402, 403, 404, 422               | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Use this request to retrieve an existing organization role by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetOrganizationRole" method="get" path="/organization_roles/{organization_role_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationRoles.GetAsync(organizationRoleId: "<id>");

// handle response
```

### Parameters

| Parameter                       | Type                            | Required                        | Description                     |
| ------------------------------- | ------------------------------- | ------------------------------- | ------------------------------- |
| `OrganizationRoleId`            | *string*                        | :heavy_check_mark:              | The ID of the organization role |

### Response

**[GetOrganizationRoleResponse](../../Models/Operations/GetOrganizationRoleResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates an existing organization role.
You can update the name, key, description, and permissions of the role.
All parameters are optional - you can update only the fields you want to change.
If the role is used as a creator role or domain default role, updating the key will cascade the update to the organization settings.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateOrganizationRole" method="patch" path="/organization_roles/{organization_role_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationRoles.UpdateAsync(
    organizationRoleId: "<id>",
    requestBody: new UpdateOrganizationRoleRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `OrganizationRoleId`                                                                              | *string*                                                                                          | :heavy_check_mark:                                                                                | The ID of the organization role to update                                                         |
| `RequestBody`                                                                                     | [UpdateOrganizationRoleRequestBody](../../Models/Operations/UpdateOrganizationRoleRequestBody.md) | :heavy_check_mark:                                                                                | N/A                                                                                               |

### Response

**[UpdateOrganizationRoleResponse](../../Models/Operations/UpdateOrganizationRoleResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Deletes the organization role.
The role cannot be deleted if it is currently used as the default creator role, domain default role, assigned to any members, or exists in any invitations.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteOrganizationRole" method="delete" path="/organization_roles/{organization_role_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationRoles.DeleteAsync(organizationRoleId: "<id>");

// handle response
```

### Parameters

| Parameter                                 | Type                                      | Required                                  | Description                               |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| `OrganizationRoleId`                      | *string*                                  | :heavy_check_mark:                        | The ID of the organization role to delete |

### Response

**[DeleteOrganizationRoleResponse](../../Models/Operations/DeleteOrganizationRoleResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## AssignPermission

Assigns a permission to an organization role

### Example Usage

<!-- UsageSnippet language="csharp" operationID="AssignPermissionToOrganizationRole" method="post" path="/organization_roles/{organization_role_id}/permissions/{permission_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationRoles.AssignPermissionAsync(
    organizationRoleId: "<id>",
    permissionId: "<id>"
);

// handle response
```

### Parameters

| Parameter                          | Type                               | Required                           | Description                        |
| ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- |
| `OrganizationRoleId`               | *string*                           | :heavy_check_mark:                 | The ID of the organization role    |
| `PermissionId`                     | *string*                           | :heavy_check_mark:                 | The ID of the permission to assign |

### Response

**[AssignPermissionToOrganizationRoleResponse](../../Models/Operations/AssignPermissionToOrganizationRoleResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404, 409                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## RemovePermission

Removes a permission from an organization role

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RemovePermissionFromOrganizationRole" method="delete" path="/organization_roles/{organization_role_id}/permissions/{permission_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationRoles.RemovePermissionAsync(
    organizationRoleId: "<id>",
    permissionId: "<id>"
);

// handle response
```

### Parameters

| Parameter                          | Type                               | Required                           | Description                        |
| ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- |
| `OrganizationRoleId`               | *string*                           | :heavy_check_mark:                 | The ID of the organization role    |
| `PermissionId`                     | *string*                           | :heavy_check_mark:                 | The ID of the permission to remove |

### Response

**[RemovePermissionFromOrganizationRoleResponse](../../Models/Operations/RemovePermissionFromOrganizationRoleResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |