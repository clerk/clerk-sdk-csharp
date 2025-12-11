# OrganizationMemberships

## Overview

### Available Operations

* [Create](#create) - Create a new organization membership
* [List](#list) - Get a list of all members of an organization
* [Update](#update) - Update an organization membership
* [Delete](#delete) - Remove a member from an organization
* [UpdateMetadata](#updatemetadata) - Merge and update organization membership metadata

## Create

Adds a user as a member to the given organization.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateOrganizationMembership" method="post" path="/organizations/{organization_id}/memberships" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

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

<!-- UsageSnippet language="csharp" operationID="ListOrganizationMemberships" method="get" path="/organizations/{organization_id}/memberships" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListOrganizationMembershipsRequest req = new ListOrganizationMembershipsRequest() {
    OrganizationId = "org_789",
    EmailAddress = new List<string>() {
        "+created_at",
    },
    LastActiveAtBefore = 1700690400000,
    LastActiveAtAfter = 1700690400000,
    CreatedAtBefore = 1730160000000,
    CreatedAtAfter = 1730160000000,
    Limit = 20,
    Offset = 10,
};

var res = await sdk.OrganizationMemberships.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                           | Type                                                                                                | Required                                                                                            | Description                                                                                         |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `request`                                                                                           | [ListOrganizationMembershipsRequest](../../Models/Operations/ListOrganizationMembershipsRequest.md) | :heavy_check_mark:                                                                                  | The request object to use for the request.                                                          |

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

<!-- UsageSnippet language="csharp" operationID="UpdateOrganizationMembership" method="patch" path="/organizations/{organization_id}/memberships/{user_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

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
| `OrganizationId`                                                                                              | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The ID of the organization to which this membership belongs                                                   | org_12345                                                                                                     |
| `UserId`                                                                                                      | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The ID of the user to which this membership belongs                                                           | user_67890                                                                                                    |
| `RequestBody`                                                                                                 | [UpdateOrganizationMembershipRequestBody](../../Models/Operations/UpdateOrganizationMembershipRequestBody.md) | :heavy_check_mark:                                                                                            | N/A                                                                                                           |                                                                                                               |

### Response

**[UpdateOrganizationMembershipResponse](../../Models/Operations/UpdateOrganizationMembershipResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Removes the given membership from the organization

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteOrganizationMembership" method="delete" path="/organizations/{organization_id}/memberships/{user_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.DeleteAsync(
    organizationId: "org_12345",
    userId: "user_67890"
);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 | Example                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `OrganizationId`                                            | *string*                                                    | :heavy_check_mark:                                          | The ID of the organization to which this membership belongs | org_12345                                                   |
| `UserId`                                                    | *string*                                                    | :heavy_check_mark:                                          | The ID of the user to which this membership belongs         | user_67890                                                  |

### Response

**[DeleteOrganizationMembershipResponse](../../Models/Operations/DeleteOrganizationMembershipResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 404, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## UpdateMetadata

Update an organization membership's metadata attributes by merging existing values with the provided parameters.
Metadata values will be updated via a deep merge. Deep means that any nested JSON objects will be merged as well.
You can remove metadata keys at any level by setting their value to `null`.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateOrganizationMembershipMetadata" method="patch" path="/organizations/{organization_id}/memberships/{user_id}/metadata" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

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
| `OrganizationId`                                                                                                              | *string*                                                                                                                      | :heavy_check_mark:                                                                                                            | The ID of the organization to which this membership belongs                                                                   | org_123456                                                                                                                    |
| `UserId`                                                                                                                      | *string*                                                                                                                      | :heavy_check_mark:                                                                                                            | The ID of the user to which this membership belongs                                                                           | user_654321                                                                                                                   |
| `RequestBody`                                                                                                                 | [UpdateOrganizationMembershipMetadataRequestBody](../../Models/Operations/UpdateOrganizationMembershipMetadataRequestBody.md) | :heavy_minus_sign:                                                                                                            | N/A                                                                                                                           |                                                                                                                               |

### Response

**[UpdateOrganizationMembershipMetadataResponse](../../Models/Operations/UpdateOrganizationMembershipMetadataResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |