# Directories

## Overview

### Available Operations

* [List](#list) - List all directories
* [Create](#create) - Create a directory
* [Get](#get) - Retrieve a directory
* [Update](#update) - Update a directory
* [Delete](#delete) - Delete a directory
* [RotateApiKey](#rotateapikey) - Rotate a directory's API key
* [ListGroupRoleMappings](#listgrouprolemappings) - List directory group role mappings
* [CreateGroupRoleMapping](#creategrouprolemapping) - Create a directory group role mapping
* [ReplaceGroupRoleMappings](#replacegrouprolemappings) - Replace directory group role mappings
* [DeleteGroupRoleMapping](#deletegrouprolemapping) - Delete a directory group role mapping

## List

Returns a list of all directories for the instance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListDirectories" method="get" path="/directories" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.ListAsync(
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               | Example                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                                   | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     | 20                                                                                                                                        |
| `Offset`                                                                                                                                  | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. | 10                                                                                                                                        |

### Response

**[ListDirectoriesResponse](../../Models/Operations/ListDirectoriesResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Create a new directory for the instance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateDirectory" method="post" path="/directories" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateDirectoryRequestBody? req = null;

var res = await sdk.Directories.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [CreateDirectoryRequestBody](../../Models/Operations/CreateDirectoryRequestBody.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[CreateDirectoryResponse](../../Models/Operations/CreateDirectoryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Returns the details of a directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetDirectory" method="get" path="/directories/{directory_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.GetAsync(directoryId: "<id>");

// handle response
```

### Parameters

| Parameter                           | Type                                | Required                            | Description                         |
| ----------------------------------- | ----------------------------------- | ----------------------------------- | ----------------------------------- |
| `DirectoryId`                       | *string*                            | :heavy_check_mark:                  | The ID of the directory to retrieve |

### Response

**[GetDirectoryResponse](../../Models/Operations/GetDirectoryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates a directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateDirectory" method="patch" path="/directories/{directory_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.UpdateAsync(directoryId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `DirectoryId`                                                                       | *string*                                                                            | :heavy_check_mark:                                                                  | The ID of the directory to update                                                   |
| `RequestBody`                                                                       | [UpdateDirectoryRequestBody](../../Models/Operations/UpdateDirectoryRequestBody.md) | :heavy_minus_sign:                                                                  | N/A                                                                                 |

### Response

**[UpdateDirectoryResponse](../../Models/Operations/UpdateDirectoryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Deletes a directory and stops provisioning for it. Provisioning requests authenticated
with the directory's API key are rejected afterwards.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteDirectory" method="delete" path="/directories/{directory_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.DeleteAsync(directoryId: "<id>");

// handle response
```

### Parameters

| Parameter                         | Type                              | Required                          | Description                       |
| --------------------------------- | --------------------------------- | --------------------------------- | --------------------------------- |
| `DirectoryId`                     | *string*                          | :heavy_check_mark:                | The ID of the directory to delete |

### Response

**[DeleteDirectoryResponse](../../Models/Operations/DeleteDirectoryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## RotateApiKey

Generates a new API key for the directory and returns it in the `api_key` field.
This is the only way to obtain the key after creation, so make sure to update it in
your identity provider. The previous key remains valid for a short grace period before
it expires.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RotateDirectoryAPIKey" method="post" path="/directories/{directory_id}/rotate_api_key" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.RotateApiKeyAsync(directoryId: "<id>");

// handle response
```

### Parameters

| Parameter                                       | Type                                            | Required                                        | Description                                     |
| ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- |
| `DirectoryId`                                   | *string*                                        | :heavy_check_mark:                              | The ID of the directory whose API key to rotate |

### Response

**[RotateDirectoryAPIKeyResponse](../../Models/Operations/RotateDirectoryAPIKeyResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ListGroupRoleMappings

Returns the list of directory group to organization role mappings for a directory, ordered by precedence.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListDirectoryGroupRoleMappings" method="get" path="/directories/{directory_id}/group_role_mappings" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.ListGroupRoleMappingsAsync(directoryId: "<id>");

// handle response
```

### Parameters

| Parameter                | Type                     | Required                 | Description              |
| ------------------------ | ------------------------ | ------------------------ | ------------------------ |
| `DirectoryId`            | *string*                 | :heavy_check_mark:       | The ID of the directory. |

### Response

**[ListDirectoryGroupRoleMappingsResponse](../../Models/Operations/ListDirectoryGroupRoleMappingsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateGroupRoleMapping

Creates a new directory group to organization role mapping for a directory.
Group role mapping must be enabled on the directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateDirectoryGroupRoleMapping" method="post" path="/directories/{directory_id}/group_role_mappings" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.CreateGroupRoleMappingAsync(
    directoryId: "<id>",
    requestBody: new CreateDirectoryGroupRoleMappingRequestBody() {
        RoleId = "<id>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                           | Type                                                                                                                | Required                                                                                                            | Description                                                                                                         |
| ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| `DirectoryId`                                                                                                       | *string*                                                                                                            | :heavy_check_mark:                                                                                                  | The ID of the directory.                                                                                            |
| `RequestBody`                                                                                                       | [CreateDirectoryGroupRoleMappingRequestBody](../../Models/Operations/CreateDirectoryGroupRoleMappingRequestBody.md) | :heavy_check_mark:                                                                                                  | N/A                                                                                                                 |

### Response

**[CreateDirectoryGroupRoleMappingResponse](../../Models/Operations/CreateDirectoryGroupRoleMappingResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ReplaceGroupRoleMappings

Replaces the entire set of directory group role mappings for a directory. The position of
each item in the `mappings` array determines its precedence (the first item gets
precedence 1). Passing an empty array removes all mappings. Group role mapping must be
enabled on the directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ReplaceDirectoryGroupRoleMappings" method="put" path="/directories/{directory_id}/group_role_mappings" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.ReplaceGroupRoleMappingsAsync(
    directoryId: "<id>",
    requestBody: new ReplaceDirectoryGroupRoleMappingsRequestBody() {
        Mappings = new List<ReplaceDirectoryGroupRoleMappingsMappings>() {
            new ReplaceDirectoryGroupRoleMappingsMappings() {
                RoleId = "<id>",
            },
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                               | Type                                                                                                                    | Required                                                                                                                | Description                                                                                                             |
| ----------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| `DirectoryId`                                                                                                           | *string*                                                                                                                | :heavy_check_mark:                                                                                                      | The ID of the directory.                                                                                                |
| `RequestBody`                                                                                                           | [ReplaceDirectoryGroupRoleMappingsRequestBody](../../Models/Operations/ReplaceDirectoryGroupRoleMappingsRequestBody.md) | :heavy_check_mark:                                                                                                      | N/A                                                                                                                     |

### Response

**[ReplaceDirectoryGroupRoleMappingsResponse](../../Models/Operations/ReplaceDirectoryGroupRoleMappingsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteGroupRoleMapping

Deletes a single directory group role mapping. Group role mapping must be enabled on the
directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteDirectoryGroupRoleMapping" method="delete" path="/directories/{directory_id}/group_role_mappings/{mapping_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Directories.DeleteGroupRoleMappingAsync(
    directoryId: "<id>",
    mappingId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                             | Type                                                  | Required                                              | Description                                           |
| ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- |
| `DirectoryId`                                         | *string*                                              | :heavy_check_mark:                                    | The ID of the directory.                              |
| `MappingId`                                           | *string*                                              | :heavy_check_mark:                                    | The ID of the directory group role mapping to delete. |

### Response

**[DeleteDirectoryGroupRoleMappingResponse](../../Models/Operations/DeleteDirectoryGroupRoleMappingResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |