# OrganizationDomain
(*OrganizationDomain*)

## Overview

### Available Operations

* [Update](#update) - Update an organization domain.

## Update

Updates the properties of an existing organization domain.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationDomain.UpdateAsync(
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