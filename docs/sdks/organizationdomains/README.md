# OrganizationDomains
(*OrganizationDomains*)

## Overview

### Available Operations

* [Create](#create) - Create a new organization domain.
* [List](#list) - Get a list of all domains of an organization.
* [Delete](#delete) - Remove a domain from an organization.

## Create

Creates a new organization domain. By default the domain is verified, but can be optionally set to unverified.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationDomains.CreateAsync(
    organizationId: "<id>",
    requestBody: new CreateOrganizationDomainRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                           | Type                                                                                                | Required                                                                                            | Description                                                                                         |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                    | *string*                                                                                            | :heavy_check_mark:                                                                                  | The ID of the organization where the new domain will be created.                                    |
| `RequestBody`                                                                                       | [CreateOrganizationDomainRequestBody](../../Models/Requests/CreateOrganizationDomainRequestBody.md) | :heavy_check_mark:                                                                                  | N/A                                                                                                 |

### Response

**[CreateOrganizationDomainResponse](../../Models/Requests/CreateOrganizationDomainResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 403, 404, 422                                                            | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## List

Get a list of all domains of an organization.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListOrganizationDomainsRequest req = new ListOrganizationDomainsRequest() {
    OrganizationId = "<id>",
};

var res = await sdk.OrganizationDomains.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `request`                                                                                 | [ListOrganizationDomainsRequest](../../Models/Requests/ListOrganizationDomainsRequest.md) | :heavy_check_mark:                                                                        | The request object to use for the request.                                                |

### Response

**[ListOrganizationDomainsResponse](../../Models/Requests/ListOrganizationDomainsResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 401, 422                                                                      | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## Delete

Removes the given domain from the organization.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

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

**[DeleteOrganizationDomainResponse](../../Models/Requests/DeleteOrganizationDomainResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 401, 404                                                                 | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |