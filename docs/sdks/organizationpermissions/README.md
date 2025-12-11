# OrganizationPermissions

## Overview

### Available Operations

* [List](#list) - Get a list of all organization permissions
* [Create](#create) - Create a new organization permission
* [Get](#get) - Get an organization permission
* [Update](#update) - Update an organization permission
* [Delete](#delete) - Delete an organization permission

## List

Retrieves all organization permissions for the given instance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListOrganizationPermissions" method="get" path="/organization_permissions" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationPermissions.ListAsync(
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                                                                                                                          | Example                                                                                                                                                                                                                                                                                                                                                                                                              |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Query`                                                                                                                                                                                                                                                                                                                                                                                                              | *string*                                                                                                                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                   | Returns organization permissions with ID, name, or key that match the given query.<br/>Uses exact match for permission ID and partial match for name and key.                                                                                                                                                                                                                                                        |                                                                                                                                                                                                                                                                                                                                                                                                                      |
| `OrderBy`                                                                                                                                                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                   | Allows to return organization permissions in a particular order.<br/>At the moment, you can order the returned permissions by their `created_at`, `name`, or `key`.<br/>In order to specify the direction, you can use the `+/-` symbols prepended in the property to order by.<br/>For example, if you want permissions to be returned in descending order according to their `created_at` property, you can use `-created_at`. |                                                                                                                                                                                                                                                                                                                                                                                                                      |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                                              | *long*                                                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                   | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                                                                                                                                                                                                                | 20                                                                                                                                                                                                                                                                                                                                                                                                                   |
| `Offset`                                                                                                                                                                                                                                                                                                                                                                                                             | *long*                                                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                   | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                                                                                                                                                                                                    | 10                                                                                                                                                                                                                                                                                                                                                                                                                   |

### Response

**[ListOrganizationPermissionsResponse](../../Models/Operations/ListOrganizationPermissionsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Creates a new organization permission for the given instance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateOrganizationPermission" method="post" path="/organization_permissions" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateOrganizationPermissionRequestBody req = new CreateOrganizationPermissionRequestBody() {
    Name = "<value>",
    Key = "<key>",
};

var res = await sdk.OrganizationPermissions.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                     | [CreateOrganizationPermissionRequestBody](../../Models/Operations/CreateOrganizationPermissionRequestBody.md) | :heavy_check_mark:                                                                                            | The request object to use for the request.                                                                    |

### Response

**[CreateOrganizationPermissionResponse](../../Models/Operations/CreateOrganizationPermissionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 402, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Retrieves the details of an organization permission.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetOrganizationPermission" method="get" path="/organization_permissions/{permission_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationPermissions.GetAsync(permissionId: "<id>");

// handle response
```

### Parameters

| Parameter                            | Type                                 | Required                             | Description                          |
| ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ |
| `PermissionId`                       | *string*                             | :heavy_check_mark:                   | The ID of the permission to retrieve |

### Response

**[GetOrganizationPermissionResponse](../../Models/Operations/GetOrganizationPermissionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates the properties of an existing organization permission.
System permissions cannot be updated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateOrganizationPermission" method="patch" path="/organization_permissions/{permission_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationPermissions.UpdateAsync(
    permissionId: "<id>",
    requestBody: new UpdateOrganizationPermissionRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `PermissionId`                                                                                                | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The ID of the permission to update                                                                            |
| `RequestBody`                                                                                                 | [UpdateOrganizationPermissionRequestBody](../../Models/Operations/UpdateOrganizationPermissionRequestBody.md) | :heavy_check_mark:                                                                                            | N/A                                                                                                           |

### Response

**[UpdateOrganizationPermissionResponse](../../Models/Operations/UpdateOrganizationPermissionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Deletes an organization permission.
System permissions cannot be deleted.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteOrganizationPermission" method="delete" path="/organization_permissions/{permission_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationPermissions.DeleteAsync(permissionId: "<id>");

// handle response
```

### Parameters

| Parameter                          | Type                               | Required                           | Description                        |
| ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- |
| `PermissionId`                     | *string*                           | :heavy_check_mark:                 | The ID of the permission to delete |

### Response

**[DeleteOrganizationPermissionResponse](../../Models/Operations/DeleteOrganizationPermissionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |