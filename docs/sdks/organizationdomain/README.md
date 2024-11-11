# OrganizationDomain
(*OrganizationDomain*)

## Overview

### Available Operations

* [Update](#update) - Update an organization domain.

## Update

Updates the properties of an existing organization domain.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationDomain.UpdateAsync(
    organizationId: "<id>",
    domainId: "<id>",
    requestBody: new UpdateOrganizationDomainRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                           | Type                                                                                                | Required                                                                                            | Description                                                                                         |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                    | *string*                                                                                            | :heavy_check_mark:                                                                                  | The ID of the organization the domain belongs to                                                    |
| `DomainId`                                                                                          | *string*                                                                                            | :heavy_check_mark:                                                                                  | The ID of the domain                                                                                |
| `RequestBody`                                                                                       | [UpdateOrganizationDomainRequestBody](../../Models/Requests/UpdateOrganizationDomainRequestBody.md) | :heavy_check_mark:                                                                                  | N/A                                                                                                 |

### Response

**[UpdateOrganizationDomainResponse](../../Models/Requests/UpdateOrganizationDomainResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 404, 422                                                                 | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |