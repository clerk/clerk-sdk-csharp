# ScimDirectories

## Overview

### Available Operations

* [List](#list) - List all directories
* [Create](#create) - Create a directory
* [Get](#get) - Retrieve a directory
* [Update](#update) - Update a directory
* [Delete](#delete) - Delete a directory
* [RotateApiKey](#rotateapikey) - Rotate a directory's API key
* [ListGroupRoleMappings](#listgrouprolemappings) - List SCIM group role mappings
* [CreateGroupRoleMapping](#creategrouprolemapping) - Create a SCIM group role mapping
* [ReplaceGroupRoleMappings](#replacegrouprolemappings) - Replace SCIM group role mappings
* [DeleteGroupRoleMapping](#deletegrouprolemapping) - Delete a SCIM group role mapping

## List

Returns a list of all directories for the instance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListSCIMDirectories" method="get" path="/scim_directories" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.ListAsync(
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

**[ListSCIMDirectoriesResponse](../../Models/Operations/ListSCIMDirectoriesResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Create a new directory for the instance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateSCIMDirectory" method="post" path="/scim_directories" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateSCIMDirectoryRequestBody? req = null;

var res = await sdk.ScimDirectories.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `request`                                                                                   | [CreateSCIMDirectoryRequestBody](../../Models/Operations/CreateSCIMDirectoryRequestBody.md) | :heavy_check_mark:                                                                          | The request object to use for the request.                                                  |

### Response

**[CreateSCIMDirectoryResponse](../../Models/Operations/CreateSCIMDirectoryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Returns the details of a directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetSCIMDirectory" method="get" path="/scim_directories/{scim_directory_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.GetAsync(scimDirectoryId: "<id>");

// handle response
```

### Parameters

| Parameter                           | Type                                | Required                            | Description                         |
| ----------------------------------- | ----------------------------------- | ----------------------------------- | ----------------------------------- |
| `ScimDirectoryId`                   | *string*                            | :heavy_check_mark:                  | The ID of the directory to retrieve |

### Response

**[GetSCIMDirectoryResponse](../../Models/Operations/GetSCIMDirectoryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates a directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateSCIMDirectory" method="patch" path="/scim_directories/{scim_directory_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.UpdateAsync(scimDirectoryId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `ScimDirectoryId`                                                                           | *string*                                                                                    | :heavy_check_mark:                                                                          | The ID of the directory to update                                                           |
| `RequestBody`                                                                               | [UpdateSCIMDirectoryRequestBody](../../Models/Operations/UpdateSCIMDirectoryRequestBody.md) | :heavy_minus_sign:                                                                          | N/A                                                                                         |

### Response

**[UpdateSCIMDirectoryResponse](../../Models/Operations/UpdateSCIMDirectoryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Deletes a directory and stops provisioning for it. SCIM requests authenticated
with the directory's API key are rejected afterwards.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteSCIMDirectory" method="delete" path="/scim_directories/{scim_directory_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.DeleteAsync(scimDirectoryId: "<id>");

// handle response
```

### Parameters

| Parameter                         | Type                              | Required                          | Description                       |
| --------------------------------- | --------------------------------- | --------------------------------- | --------------------------------- |
| `ScimDirectoryId`                 | *string*                          | :heavy_check_mark:                | The ID of the directory to delete |

### Response

**[DeleteSCIMDirectoryResponse](../../Models/Operations/DeleteSCIMDirectoryResponse.md)**

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

<!-- UsageSnippet language="csharp" operationID="RotateSCIMDirectoryAPIKey" method="post" path="/scim_directories/{scim_directory_id}/rotate_api_key" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.RotateApiKeyAsync(scimDirectoryId: "<id>");

// handle response
```

### Parameters

| Parameter                                       | Type                                            | Required                                        | Description                                     |
| ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- |
| `ScimDirectoryId`                               | *string*                                        | :heavy_check_mark:                              | The ID of the directory whose API key to rotate |

### Response

**[RotateSCIMDirectoryAPIKeyResponse](../../Models/Operations/RotateSCIMDirectoryAPIKeyResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ListGroupRoleMappings

Returns the list of SCIM group to organization role mappings for a directory, ordered by precedence.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListSCIMGroupRoleMappings" method="get" path="/scim_directories/{scim_directory_id}/group_role_mappings" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.ListGroupRoleMappingsAsync(scimDirectoryId: "<id>");

// handle response
```

### Parameters

| Parameter                | Type                     | Required                 | Description              |
| ------------------------ | ------------------------ | ------------------------ | ------------------------ |
| `ScimDirectoryId`        | *string*                 | :heavy_check_mark:       | The ID of the directory. |

### Response

**[ListSCIMGroupRoleMappingsResponse](../../Models/Operations/ListSCIMGroupRoleMappingsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateGroupRoleMapping

Creates a new SCIM group to organization role mapping for a directory.
Group role mapping must be enabled on the directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateSCIMGroupRoleMapping" method="post" path="/scim_directories/{scim_directory_id}/group_role_mappings" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.CreateGroupRoleMappingAsync(
    scimDirectoryId: "<id>",
    requestBody: new CreateSCIMGroupRoleMappingRequestBody() {
        ScimGroupId = "<id>",
        RoleId = "<id>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `ScimDirectoryId`                                                                                         | *string*                                                                                                  | :heavy_check_mark:                                                                                        | The ID of the directory.                                                                                  |
| `RequestBody`                                                                                             | [CreateSCIMGroupRoleMappingRequestBody](../../Models/Operations/CreateSCIMGroupRoleMappingRequestBody.md) | :heavy_check_mark:                                                                                        | N/A                                                                                                       |

### Response

**[CreateSCIMGroupRoleMappingResponse](../../Models/Operations/CreateSCIMGroupRoleMappingResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ReplaceGroupRoleMappings

Replaces the entire set of SCIM group role mappings for a directory. The position of
each item in the `mappings` array determines its precedence (the first item gets
precedence 1). Passing an empty array removes all mappings. Group role mapping must be
enabled on the directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ReplaceSCIMGroupRoleMappings" method="put" path="/scim_directories/{scim_directory_id}/group_role_mappings" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.ReplaceGroupRoleMappingsAsync(
    scimDirectoryId: "<id>",
    requestBody: new ReplaceSCIMGroupRoleMappingsRequestBody() {
        Mappings = new List<Mappings>() {},
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `ScimDirectoryId`                                                                                             | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The ID of the directory.                                                                                      |
| `RequestBody`                                                                                                 | [ReplaceSCIMGroupRoleMappingsRequestBody](../../Models/Operations/ReplaceSCIMGroupRoleMappingsRequestBody.md) | :heavy_check_mark:                                                                                            | N/A                                                                                                           |

### Response

**[ReplaceSCIMGroupRoleMappingsResponse](../../Models/Operations/ReplaceSCIMGroupRoleMappingsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteGroupRoleMapping

Deletes a single SCIM group role mapping. Group role mapping must be enabled on the
directory.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteSCIMGroupRoleMapping" method="delete" path="/scim_directories/{scim_directory_id}/group_role_mappings/{mapping_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ScimDirectories.DeleteGroupRoleMappingAsync(
    scimDirectoryId: "<id>",
    mappingId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                        | Type                                             | Required                                         | Description                                      |
| ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ |
| `ScimDirectoryId`                                | *string*                                         | :heavy_check_mark:                               | The ID of the directory.                         |
| `MappingId`                                      | *string*                                         | :heavy_check_mark:                               | The ID of the SCIM group role mapping to delete. |

### Response

**[DeleteSCIMGroupRoleMappingResponse](../../Models/Operations/DeleteSCIMGroupRoleMappingResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |