# Organizations
(*Organizations*)

## Overview

### Available Operations

* [List](#list) - Get a list of organizations for an instance
* [Create](#create) - Create an organization
* [Get](#get) - Retrieve an organization by ID or slug
* [Update](#update) - Update an organization
* [Delete](#delete) - Delete an organization
* [MergeMetadata](#mergemetadata) - Merge and update metadata for an organization
* [UploadLogo](#uploadlogo) - Upload a logo for the organization
* [DeleteLogo](#deletelogo) - Delete the organization's logo.
* [GetBillingSubscription](#getbillingsubscription) - Retrieve an organization's billing subscription

## List

This request returns the list of organizations for an instance.
Results can be paginated using the optional `limit` and `offset` query parameters.
The organizations are ordered by descending creation date.
Most recent organizations will be returned first.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListOrganizations" method="get" path="/organizations" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListOrganizationsRequest req = new ListOrganizationsRequest() {
    Query = "false",
    UserId = new List<string>() {
        "clerk",
    },
    OrganizationId = new List<string>() {
        "-name",
    },
    Limit = 20,
    Offset = 10,
};

var res = await sdk.Organizations.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [ListOrganizationsRequest](../../Models/Operations/ListOrganizationsRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[ListOrganizationsResponse](../../Models/Operations/ListOrganizationsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Creates a new organization with the given name for an instance.
You can specify an optional slug for the new organization.
If provided, the organization slug can contain only lowercase alphanumeric characters (letters and digits) and the dash "-".
Organization slugs must be unique for the instance.
You can provide additional metadata for the organization and set any custom attribute you want.
Organizations support private and public metadata.
Private metadata can only be accessed from the Backend API.
Public metadata can be accessed from the Backend API, and are read-only from the Frontend API.
The `created_by` user will see this as their [active organization](https://clerk.com/docs/organizations/overview#active-organization)
the next time they create a session, presuming they don't explicitly set a different organization as active before then.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateOrganization" method="post" path="/organizations" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateOrganizationRequestBody req = new CreateOrganizationRequestBody() {
    Name = "NewOrg",
    CreatedBy = "user_123",
    PrivateMetadata = new Dictionary<string, object>() {
        { "internal_code", "ABC123" },
    },
    PublicMetadata = new Dictionary<string, object>() {
        { "public_event", "Annual Summit" },
    },
    Slug = "neworg",
    MaxAllowedMemberships = 100,
};

var res = await sdk.Organizations.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `request`                                                                                 | [CreateOrganizationRequestBody](../../Models/Operations/CreateOrganizationRequestBody.md) | :heavy_check_mark:                                                                        | The request object to use for the request.                                                |

### Response

**[CreateOrganizationResponse](../../Models/Operations/CreateOrganizationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Fetches the organization whose ID or slug matches the provided `id_or_slug` URL query parameter.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetOrganization" method="get" path="/organizations/{organization_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Organizations.GetAsync(organizationId: "org_123");

// handle response
```

### Parameters

| Parameter                                                                                                                      | Type                                                                                                                           | Required                                                                                                                       | Description                                                                                                                    | Example                                                                                                                        |
| ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ |
| `OrganizationId`                                                                                                               | *string*                                                                                                                       | :heavy_check_mark:                                                                                                             | The ID or slug of the organization                                                                                             | org_123                                                                                                                        |
| `IncludeMembersCount`                                                                                                          | *bool*                                                                                                                         | :heavy_minus_sign:                                                                                                             | Flag to denote whether or not the organization's members count should be included in the response.                             |                                                                                                                                |
| `IncludeMissingMemberWithElevatedPermissions`                                                                                  | *bool*                                                                                                                         | :heavy_minus_sign:                                                                                                             | Flag to denote whether or not to include a member with elevated permissions who is not currently a member of the organization. |                                                                                                                                |

### Response

**[GetOrganizationResponse](../../Models/Operations/GetOrganizationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates an existing organization

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateOrganization" method="patch" path="/organizations/{organization_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Organizations.UpdateAsync(
    organizationId: "org_123_update",
    requestBody: new UpdateOrganizationRequestBody() {
        PublicMetadata = new Dictionary<string, object>() {

        },
        PrivateMetadata = new Dictionary<string, object>() {

        },
        Name = "New Organization Name",
        Slug = "new-org-slug",
        MaxAllowedMemberships = 100,
        AdminDeleteEnabled = true,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               | Example                                                                                   |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                          | *string*                                                                                  | :heavy_check_mark:                                                                        | The ID of the organization to update                                                      | org_123_update                                                                            |
| `RequestBody`                                                                             | [UpdateOrganizationRequestBody](../../Models/Operations/UpdateOrganizationRequestBody.md) | :heavy_check_mark:                                                                        | N/A                                                                                       |                                                                                           |

### Response

**[UpdateOrganizationResponse](../../Models/Operations/UpdateOrganizationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Deletes the given organization.
Please note that deleting an organization will also delete all memberships and invitations.
This is not reversible.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteOrganization" method="delete" path="/organizations/{organization_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Organizations.DeleteAsync(organizationId: "org_321_delete");

// handle response
```

### Parameters

| Parameter                            | Type                                 | Required                             | Description                          | Example                              |
| ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ |
| `OrganizationId`                     | *string*                             | :heavy_check_mark:                   | The ID of the organization to delete | org_321_delete                       |

### Response

**[DeleteOrganizationResponse](../../Models/Operations/DeleteOrganizationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## MergeMetadata

Update organization metadata attributes by merging existing values with the provided parameters.
Metadata values will be updated via a deep merge.
Deep meaning that any nested JSON objects will be merged as well.
You can remove metadata keys at any level by setting their value to `null`.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="MergeOrganizationMetadata" method="patch" path="/organizations/{organization_id}/metadata" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Organizations.MergeMetadataAsync(
    organizationId: "org_12345",
    requestBody: new MergeOrganizationMetadataRequestBody() {
        PublicMetadata = new Dictionary<string, object>() {
            { "announcement", "We are opening a new office!" },
        },
        PrivateMetadata = new Dictionary<string, object>() {
            { "internal_use_only", "Future plans discussion." },
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                               | Type                                                                                                    | Required                                                                                                | Description                                                                                             | Example                                                                                                 |
| ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                        | *string*                                                                                                | :heavy_check_mark:                                                                                      | The ID of the organization for which metadata will be merged or updated                                 | org_12345                                                                                               |
| `RequestBody`                                                                                           | [MergeOrganizationMetadataRequestBody](../../Models/Operations/MergeOrganizationMetadataRequestBody.md) | :heavy_check_mark:                                                                                      | N/A                                                                                                     |                                                                                                         |

### Response

**[MergeOrganizationMetadataResponse](../../Models/Operations/MergeOrganizationMetadataResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## UploadLogo

Set or replace an organization's logo, by uploading an image file.
This endpoint uses the `multipart/form-data` request content type and accepts a file of image type.
The file size cannot exceed 10MB.
Only the following file content types are supported: `image/jpeg`, `image/png`, `image/gif`, `image/webp`.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UploadOrganizationLogo" method="put" path="/organizations/{organization_id}/logo" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Organizations.UploadLogoAsync(
    organizationId: "org_12345",
    requestBody: new UploadOrganizationLogoRequestBody() {
        UploaderUserId = "user_67890",
        File = new UploadOrganizationLogoFile() {
            FileName = "example.file",
            Content = System.IO.File.ReadAllBytes("example.file"),
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       | Example                                                                                           |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                  | *string*                                                                                          | :heavy_check_mark:                                                                                | The ID of the organization for which to upload a logo                                             | org_12345                                                                                         |
| `RequestBody`                                                                                     | [UploadOrganizationLogoRequestBody](../../Models/Operations/UploadOrganizationLogoRequestBody.md) | :heavy_minus_sign:                                                                                | N/A                                                                                               |                                                                                                   |

### Response

**[UploadOrganizationLogoResponse](../../Models/Operations/UploadOrganizationLogoResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404, 413                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteLogo

Delete the organization's logo.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteOrganizationLogo" method="delete" path="/organizations/{organization_id}/logo" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Organizations.DeleteLogoAsync(organizationId: "org_12345");

// handle response
```

### Parameters

| Parameter                                                      | Type                                                           | Required                                                       | Description                                                    | Example                                                        |
| -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- |
| `OrganizationId`                                               | *string*                                                       | :heavy_check_mark:                                             | The ID of the organization for which the logo will be deleted. | org_12345                                                      |

### Response

**[DeleteOrganizationLogoResponse](../../Models/Operations/DeleteOrganizationLogoResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetBillingSubscription

Retrieves the billing subscription for the specified organization.
This includes subscription details, active plans, billing information, and payment status.
The subscription contains subscription items which represent the individual plans the organization is subscribed to.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetOrganizationBillingSubscription" method="get" path="/organizations/{organization_id}/billing/subscription" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Organizations.GetBillingSubscriptionAsync(organizationId: "<id>");

// handle response
```

### Parameters

| Parameter                                                 | Type                                                      | Required                                                  | Description                                               |
| --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| `OrganizationId`                                          | *string*                                                  | :heavy_check_mark:                                        | The ID of the organization whose subscription to retrieve |

### Response

**[GetOrganizationBillingSubscriptionResponse](../../Models/Operations/GetOrganizationBillingSubscriptionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |