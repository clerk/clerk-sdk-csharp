# SamlConnections
(*SamlConnections*)

## Overview

### Available Operations

* [List](#list) - Get a list of SAML Connections for an instance
* [Create](#create) - Create a SAML Connection
* [Get](#get) - Retrieve a SAML Connection by ID
* [Update](#update) - Update a SAML Connection
* [Delete](#delete) - Delete a SAML Connection

## List

Returns the list of SAML Connections for an instance.
Results can be paginated using the optional `limit` and `offset` query parameters.
The SAML Connections are ordered by descending creation date and the most recent will be returned first.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SamlConnections.ListAsync(
    limit: 20,
    offset: 10,
    organizationId: new List<string>() {
        "<id>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                   | Type                                                                                                                                                                                                                                                                                                        | Required                                                                                                                                                                                                                                                                                                    | Description                                                                                                                                                                                                                                                                                                 | Example                                                                                                                                                                                                                                                                                                     |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                                                                                                                                                                                                     | *long*                                                                                                                                                                                                                                                                                                      | :heavy_minus_sign:                                                                                                                                                                                                                                                                                          | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                                                                                                       | 20                                                                                                                                                                                                                                                                                                          |
| `Offset`                                                                                                                                                                                                                                                                                                    | *long*                                                                                                                                                                                                                                                                                                      | :heavy_minus_sign:                                                                                                                                                                                                                                                                                          | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                                                                                           | 10                                                                                                                                                                                                                                                                                                          |
| `OrganizationId`                                                                                                                                                                                                                                                                                            | List<*string*>                                                                                                                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                                                                                                                          | Returns SAML connections that have an associated organization ID to the<br/>given organizations.<br/>For each organization id, the `+` and `-` can be<br/>prepended to the id, which denote whether the<br/>respective organization should be included or<br/>excluded from the result set.<br/>Accepts up to 100 organization ids. |                                                                                                                                                                                                                                                                                                             |

### Response

**[ListSAMLConnectionsResponse](../../Models/Operations/ListSAMLConnectionsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Create a new SAML Connection.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateSAMLConnectionRequestBody req = new CreateSAMLConnectionRequestBody() {
    Name = "My SAML Connection",
    Domain = "example.org",
    Provider = Provider.SamlCustom,
    IdpEntityId = "http://idp.example.org/",
    IdpSsoUrl = "http://idp.example.org/sso",
    IdpCertificate = "MIIDdzCCAl+gAwIBAgIJAKcyBaiiz+DT...",
    IdpMetadataUrl = "http://idp.example.org/metadata.xml",
    IdpMetadata = "<EntityDescriptor ...",
    AttributeMapping = new Models.Operations.AttributeMapping() {
        UserId = "nameid",
        EmailAddress = "mail",
        FirstName = "givenName",
        LastName = "surname",
    },
};

var res = await sdk.SamlConnections.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `request`                                                                                     | [CreateSAMLConnectionRequestBody](../../Models/Operations/CreateSAMLConnectionRequestBody.md) | :heavy_check_mark:                                                                            | The request object to use for the request.                                                    |

### Response

**[CreateSAMLConnectionResponse](../../Models/Operations/CreateSAMLConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Fetches the SAML Connection whose ID matches the provided `saml_connection_id` in the path.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SamlConnections.GetAsync(samlConnectionId: "saml_conn_123");

// handle response
```

### Parameters

| Parameter                     | Type                          | Required                      | Description                   | Example                       |
| ----------------------------- | ----------------------------- | ----------------------------- | ----------------------------- | ----------------------------- |
| `SamlConnectionId`            | *string*                      | :heavy_check_mark:            | The ID of the SAML Connection | saml_conn_123                 |

### Response

**[GetSAMLConnectionResponse](../../Models/Operations/GetSAMLConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates the SAML Connection whose ID matches the provided `id` in the path.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SamlConnections.UpdateAsync(
    samlConnectionId: "saml_conn_123_update",
    requestBody: new UpdateSAMLConnectionRequestBody() {
        Name = "Example SAML Connection",
        Domain = "example.com",
        IdpEntityId = "entity_123",
        IdpSsoUrl = "https://idp.example.com/sso",
        IdpCertificate = "MIIDBTCCAe2gAwIBAgIQ...",
        IdpMetadataUrl = "https://idp.example.com/metadata",
        IdpMetadata = "<EntityDescriptor>...</EntityDescriptor>",
        AttributeMapping = new UpdateSAMLConnectionAttributeMapping() {
            UserId = "id123",
            EmailAddress = "user@example.com",
            FirstName = "Jane",
            LastName = "Doe",
        },
        Active = true,
        SyncUserAttributes = false,
        AllowSubdomains = true,
        AllowIdpInitiated = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   | Example                                                                                       |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `SamlConnectionId`                                                                            | *string*                                                                                      | :heavy_check_mark:                                                                            | The ID of the SAML Connection to update                                                       | saml_conn_123_update                                                                          |
| `RequestBody`                                                                                 | [UpdateSAMLConnectionRequestBody](../../Models/Operations/UpdateSAMLConnectionRequestBody.md) | :heavy_check_mark:                                                                            | N/A                                                                                           |                                                                                               |

### Response

**[UpdateSAMLConnectionResponse](../../Models/Operations/UpdateSAMLConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Deletes the SAML Connection whose ID matches the provided `id` in the path.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SamlConnections.DeleteAsync(samlConnectionId: "saml_conn_123_delete");

// handle response
```

### Parameters

| Parameter                               | Type                                    | Required                                | Description                             | Example                                 |
| --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- |
| `SamlConnectionId`                      | *string*                                | :heavy_check_mark:                      | The ID of the SAML Connection to delete | saml_conn_123_delete                    |

### Response

**[DeleteSAMLConnectionResponse](../../Models/Operations/DeleteSAMLConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |