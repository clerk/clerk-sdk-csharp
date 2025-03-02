# OrganizationDomains
(*OrganizationDomains*)

## Overview

### Available Operations

* [Create](#create) - Create a new organization domain.
* [List](#list) - Get a list of all domains of an organization.
* [Update](#update) - Update an organization domain.
* [Delete](#delete) - Remove a domain from an organization.

## Create

Creates a new organization domain. By default the domain is verified, but can be optionally set to unverified.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationDomains.CreateAsync(
    organizationId: "<id>",
    requestBody: new CreateOrganizationDomainRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                      | *string*                                                                                              | :heavy_check_mark:                                                                                    | The ID of the organization where the new domain will be created.                                      |
| `RequestBody`                                                                                         | [CreateOrganizationDomainRequestBody](../../Models/Operations/CreateOrganizationDomainRequestBody.md) | :heavy_check_mark:                                                                                    | N/A                                                                                                   |

### Response

**[CreateOrganizationDomainResponse](../../Models/Operations/CreateOrganizationDomainResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## List

Get a list of all domains of an organization.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListOrganizationDomainsRequest req = new ListOrganizationDomainsRequest() {
    OrganizationId = "<id>",
};

var res = await sdk.OrganizationDomains.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `request`                                                                                   | [ListOrganizationDomainsRequest](../../Models/Operations/ListOrganizationDomainsRequest.md) | :heavy_check_mark:                                                                          | The request object to use for the request.                                                  |

### Response

**[ListOrganizationDomainsResponse](../../Models/Operations/ListOrganizationDomainsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates the properties of an existing organization domain.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationDomains.UpdateAsync(
    organizationId: "<id>",
    domainId: "<id>",
    requestBody: new UpdateOrganizationDomainRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                      | *string*                                                                                              | :heavy_check_mark:                                                                                    | The ID of the organization the domain belongs to                                                      |
| `DomainId`                                                                                            | *string*                                                                                              | :heavy_check_mark:                                                                                    | The ID of the domain                                                                                  |
| `RequestBody`                                                                                         | [UpdateOrganizationDomainRequestBody](../../Models/Operations/UpdateOrganizationDomainRequestBody.md) | :heavy_check_mark:                                                                                    | N/A                                                                                                   |

### Response

**[UpdateOrganizationDomainResponse](../../Models/Operations/UpdateOrganizationDomainResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Removes the given domain from the organization.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationDomains.DeleteAsync(
    organizationId: "<id>",
    domainId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                        | Type                                             | Required                                         | Description                                      |
| ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ |
| `OrganizationId`                                 | *string*                                         | :heavy_check_mark:                               | The ID of the organization the domain belongs to |
| `DomainId`                                       | *string*                                         | :heavy_check_mark:                               | The ID of the domain                             |

### Response

**[DeleteOrganizationDomainResponse](../../Models/Operations/DeleteOrganizationDomainResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |