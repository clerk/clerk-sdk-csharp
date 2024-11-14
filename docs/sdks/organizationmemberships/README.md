# OrganizationMemberships
(*OrganizationMemberships*)

## Overview

### Available Operations

* [Create](#create) - Create a new organization membership
* [List](#list) - Get a list of all members of an organization
* [Update](#update) - Update an organization membership
* [Delete](#delete) - Remove a member from an organization
* [UpdateMetadata](#updatemetadata) - Merge and update organization membership metadata
* [ListForInstance](#listforinstance) - Get a list of all organization memberships within an instance.

## Create

Adds a user as a member to the given organization.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.CreateAsync(
    organizationId: "org_123",
    requestBody: new CreateOrganizationMembershipRequestBody() {
        UserId = "user_456",
        Role = "admin",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   | Example                                                                                                       |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                              | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The ID of the organization where the new membership will be created                                           | org_123                                                                                                       |
| `RequestBody`                                                                                                 | [CreateOrganizationMembershipRequestBody](../../Models/Operations/CreateOrganizationMembershipRequestBody.md) | :heavy_check_mark:                                                                                            | N/A                                                                                                           |                                                                                                               |

### Response

**[CreateOrganizationMembershipResponse](../../Models/Operations/CreateOrganizationMembershipResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## List

Retrieves all user memberships for the given organization

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.ListAsync(
    organizationId: "org_789",
    limit: 20,
    offset: 10,
    orderBy: "+created_at"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                           | Type                                                                                                                                                                                                                                | Required                                                                                                                                                                                                                            | Description                                                                                                                                                                                                                         | Example                                                                                                                                                                                                                             |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                                  | The organization ID.                                                                                                                                                                                                                | org_789                                                                                                                                                                                                                             |
| `Limit`                                                                                                                                                                                                                             | *long*                                                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                                                  | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                               | 20                                                                                                                                                                                                                                  |
| `Offset`                                                                                                                                                                                                                            | *long*                                                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                                                  | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                   | 10                                                                                                                                                                                                                                  |
| `OrderBy`                                                                                                                                                                                                                           | *string*                                                                                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                                                                                  | Sorts organizations memberships by phone_number, email_address, created_at, first_name, last_name or username.<br/>By prepending one of those values with + or -,<br/>we can choose to sort in ascending (ASC) or descending (DESC) order." | +created_at                                                                                                                                                                                                                         |

### Response

**[ListOrganizationMembershipsResponse](../../Models/Operations/ListOrganizationMembershipsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates the properties of an existing organization membership

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.UpdateAsync(
    organizationId: "org_12345",
    userId: "user_67890",
    requestBody: new UpdateOrganizationMembershipRequestBody() {
        Role = "admin",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   | Example                                                                                                       |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                              | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The ID of the organization the membership belongs to                                                          | org_12345                                                                                                     |
| `UserId`                                                                                                      | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The ID of the user that this membership belongs to                                                            | user_67890                                                                                                    |
| `RequestBody`                                                                                                 | [UpdateOrganizationMembershipRequestBody](../../Models/Operations/UpdateOrganizationMembershipRequestBody.md) | :heavy_check_mark:                                                                                            | N/A                                                                                                           |                                                                                                               |

### Response

**[UpdateOrganizationMembershipResponse](../../Models/Operations/UpdateOrganizationMembershipResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Removes the given membership from the organization

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.DeleteAsync(
    organizationId: "org_12345",
    userId: "user_67890"
);

// handle response
```

### Parameters

| Parameter                                            | Type                                                 | Required                                             | Description                                          | Example                                              |
| ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| `OrganizationId`                                     | *string*                                             | :heavy_check_mark:                                   | The ID of the organization the membership belongs to | org_12345                                            |
| `UserId`                                             | *string*                                             | :heavy_check_mark:                                   | The ID of the user that this membership belongs to   | user_67890                                           |

### Response

**[DeleteOrganizationMembershipResponse](../../Models/Operations/DeleteOrganizationMembershipResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## UpdateMetadata

Update an organization membership's metadata attributes by merging existing values with the provided parameters.
Metadata values will be updated via a deep merge. Deep means that any nested JSON objects will be merged as well.
You can remove metadata keys at any level by setting their value to `null`.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.UpdateMetadataAsync(
    organizationId: "org_123456",
    userId: "user_654321",
    requestBody: new UpdateOrganizationMembershipMetadataRequestBody() {
        PublicMetadata = new Dictionary<string, object>() {

        },
        PrivateMetadata = new Dictionary<string, object>() {

        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                                     | Type                                                                                                                          | Required                                                                                                                      | Description                                                                                                                   | Example                                                                                                                       |
| ----------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                                              | *string*                                                                                                                      | :heavy_check_mark:                                                                                                            | The ID of the organization the membership belongs to                                                                          | org_123456                                                                                                                    |
| `UserId`                                                                                                                      | *string*                                                                                                                      | :heavy_check_mark:                                                                                                            | The ID of the user that this membership belongs to                                                                            | user_654321                                                                                                                   |
| `RequestBody`                                                                                                                 | [UpdateOrganizationMembershipMetadataRequestBody](../../Models/Operations/UpdateOrganizationMembershipMetadataRequestBody.md) | :heavy_check_mark:                                                                                                            | N/A                                                                                                                           |                                                                                                                               |

### Response

**[UpdateOrganizationMembershipMetadataResponse](../../Models/Operations/UpdateOrganizationMembershipMetadataResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ListForInstance

Retrieves all organization user memberships for the given instance.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.ListForInstanceAsync(
    limit: 20,
    offset: 10,
    orderBy: "<value>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                          | Type                                                                                                                                                                                                                               | Required                                                                                                                                                                                                                           | Description                                                                                                                                                                                                                        | Example                                                                                                                                                                                                                            |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                                                                                                                            | *long*                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                 | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                              | 20                                                                                                                                                                                                                                 |
| `Offset`                                                                                                                                                                                                                           | *long*                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                 | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                  | 10                                                                                                                                                                                                                                 |
| `OrderBy`                                                                                                                                                                                                                          | *string*                                                                                                                                                                                                                           | :heavy_minus_sign:                                                                                                                                                                                                                 | Sorts organizations memberships by phone_number, email_address, created_at, first_name, last_name or username.<br/>By prepending one of those values with + or -,<br/>we can choose to sort in ascending (ASC) or descending (DESC) order. |                                                                                                                                                                                                                                    |

### Response

**[InstanceGetOrganizationMembershipsResponse](../../Models/Operations/InstanceGetOrganizationMembershipsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 422, 500                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |