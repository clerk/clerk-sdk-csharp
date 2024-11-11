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
Only users in the same instance as the organization can be added as members.

This organization will be the user's [active organization] (https://clerk.com/docs/organizations/overview#active-organization)
the next time they create a session, presuming they don't explicitly set a
different organization as active before then.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.CreateAsync(
    organizationId: "<id>",
    requestBody: new CreateOrganizationMembershipRequestBody() {
        UserId = "<id>",
        Role = "<value>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                   | Type                                                                                                        | Required                                                                                                    | Description                                                                                                 |
| ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                            | *string*                                                                                                    | :heavy_check_mark:                                                                                          | The ID of the organization where the new membership will be created                                         |
| `RequestBody`                                                                                               | [CreateOrganizationMembershipRequestBody](../../Models/Requests/CreateOrganizationMembershipRequestBody.md) | :heavy_check_mark:                                                                                          | N/A                                                                                                         |

### Response

**[CreateOrganizationMembershipResponse](../../Models/Requests/CreateOrganizationMembershipResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 403, 404, 422                                                            | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## List

Retrieves all user memberships for the given organization

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.ListAsync(
    organizationId: "<id>",
    limit: 10D,
    offset: 0D,
    orderBy: "<value>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                           | Type                                                                                                                                                                                                                                | Required                                                                                                                                                                                                                            | Description                                                                                                                                                                                                                         |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                            | :heavy_check_mark:                                                                                                                                                                                                                  | The organization ID.                                                                                                                                                                                                                |
| `Limit`                                                                                                                                                                                                                             | *double*                                                                                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                                                                                  | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                               |
| `Offset`                                                                                                                                                                                                                            | *double*                                                                                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                                                                                  | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                   |
| `OrderBy`                                                                                                                                                                                                                           | *string*                                                                                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                                                                                  | Sorts organizations memberships by phone_number, email_address, created_at, first_name, last_name or username.<br/>By prepending one of those values with + or -,<br/>we can choose to sort in ascending (ASC) or descending (DESC) order." |

### Response

**[ListOrganizationMembershipsResponse](../../Models/Requests/ListOrganizationMembershipsResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 401, 422                                                                      | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## Update

Updates the properties of an existing organization membership

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.UpdateAsync(
    organizationId: "<id>",
    userId: "<id>",
    requestBody: new UpdateOrganizationMembershipRequestBody() {
        Role = "<value>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                   | Type                                                                                                        | Required                                                                                                    | Description                                                                                                 |
| ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                            | *string*                                                                                                    | :heavy_check_mark:                                                                                          | The ID of the organization the membership belongs to                                                        |
| `UserId`                                                                                                    | *string*                                                                                                    | :heavy_check_mark:                                                                                          | The ID of the user that this membership belongs to                                                          |
| `RequestBody`                                                                                               | [UpdateOrganizationMembershipRequestBody](../../Models/Requests/UpdateOrganizationMembershipRequestBody.md) | :heavy_check_mark:                                                                                          | N/A                                                                                                         |

### Response

**[UpdateOrganizationMembershipResponse](../../Models/Requests/UpdateOrganizationMembershipResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 404, 422                                                                 | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## Delete

Removes the given membership from the organization

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.DeleteAsync(
    organizationId: "<id>",
    userId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                            | Type                                                 | Required                                             | Description                                          |
| ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| `OrganizationId`                                     | *string*                                             | :heavy_check_mark:                                   | The ID of the organization the membership belongs to |
| `UserId`                                             | *string*                                             | :heavy_check_mark:                                   | The ID of the user that this membership belongs to   |

### Response

**[DeleteOrganizationMembershipResponse](../../Models/Requests/DeleteOrganizationMembershipResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 401, 404                                                                 | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## UpdateMetadata

Update an organization membership's metadata attributes by merging existing values with the provided parameters.
Metadata values will be updated via a deep merge. Deep means that any nested JSON objects will be merged as well.
You can remove metadata keys at any level by setting their value to `null`.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.UpdateMetadataAsync(
    organizationId: "<id>",
    userId: "<id>",
    requestBody: new UpdateOrganizationMembershipMetadataRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                                                   | Type                                                                                                                        | Required                                                                                                                    | Description                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                                            | *string*                                                                                                                    | :heavy_check_mark:                                                                                                          | The ID of the organization the membership belongs to                                                                        |
| `UserId`                                                                                                                    | *string*                                                                                                                    | :heavy_check_mark:                                                                                                          | The ID of the user that this membership belongs to                                                                          |
| `RequestBody`                                                                                                               | [UpdateOrganizationMembershipMetadataRequestBody](../../Models/Requests/UpdateOrganizationMembershipMetadataRequestBody.md) | :heavy_check_mark:                                                                                                          | N/A                                                                                                                         |

### Response

**[UpdateOrganizationMembershipMetadataResponse](../../Models/Requests/UpdateOrganizationMembershipMetadataResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 404, 422                                                                 | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## ListForInstance

Retrieves all organization user memberships for the given instance.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationMemberships.ListForInstanceAsync(
    limit: 10D,
    offset: 0D,
    orderBy: "<value>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                          | Type                                                                                                                                                                                                                               | Required                                                                                                                                                                                                                           | Description                                                                                                                                                                                                                        |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                                                                                                                            | *double*                                                                                                                                                                                                                           | :heavy_minus_sign:                                                                                                                                                                                                                 | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                              |
| `Offset`                                                                                                                                                                                                                           | *double*                                                                                                                                                                                                                           | :heavy_minus_sign:                                                                                                                                                                                                                 | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                  |
| `OrderBy`                                                                                                                                                                                                                          | *string*                                                                                                                                                                                                                           | :heavy_minus_sign:                                                                                                                                                                                                                 | Sorts organizations memberships by phone_number, email_address, created_at, first_name, last_name or username.<br/>By prepending one of those values with + or -,<br/>we can choose to sort in ascending (ASC) or descending (DESC) order. |

### Response

**[InstanceGetOrganizationMembershipsResponse](../../Models/Requests/InstanceGetOrganizationMembershipsResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 401, 422, 500                                                            | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |