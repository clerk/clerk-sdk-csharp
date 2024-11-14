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
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SamlConnections.ListAsync(
    limit: 10D,
    offset: 0D
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                                   | *double*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     |
| `Offset`                                                                                                                                  | *double*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. |

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
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateSAMLConnectionRequestBody req = new CreateSAMLConnectionRequestBody() {
    Name = "<value>",
    Domain = "low-packaging.info",
    Provider = Clerk.BackendAPI.Models.Operations.Provider.SamlCustom,
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
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Fetches the SAML Connection whose ID matches the provided `saml_connection_id` in the path.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SamlConnections.GetAsync(samlConnectionId: "<id>");

// handle response
```

### Parameters

| Parameter                     | Type                          | Required                      | Description                   |
| ----------------------------- | ----------------------------- | ----------------------------- | ----------------------------- |
| `SamlConnectionId`            | *string*                      | :heavy_check_mark:            | The ID of the SAML Connection |

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
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SamlConnections.UpdateAsync(
    samlConnectionId: "<id>",
    requestBody: new UpdateSAMLConnectionRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `SamlConnectionId`                                                                            | *string*                                                                                      | :heavy_check_mark:                                                                            | The ID of the SAML Connection to update                                                       |
| `RequestBody`                                                                                 | [UpdateSAMLConnectionRequestBody](../../Models/Operations/UpdateSAMLConnectionRequestBody.md) | :heavy_check_mark:                                                                            | N/A                                                                                           |

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
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SamlConnections.DeleteAsync(samlConnectionId: "<id>");

// handle response
```

### Parameters

| Parameter                               | Type                                    | Required                                | Description                             |
| --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- |
| `SamlConnectionId`                      | *string*                                | :heavy_check_mark:                      | The ID of the SAML Connection to delete |

### Response

**[DeleteSAMLConnectionResponse](../../Models/Operations/DeleteSAMLConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |