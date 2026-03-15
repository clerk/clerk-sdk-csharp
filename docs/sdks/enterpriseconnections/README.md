# EnterpriseConnections

## Overview

### Available Operations

* [List](#list) - List enterprise connections
* [Create](#create) - Create an enterprise connection
* [Get](#get) - Retrieve an enterprise connection
* [Update](#update) - Update an enterprise connection
* [Delete](#delete) - Delete an enterprise connection

## List

Returns the list of enterprise connections for the instance.
Results can be paginated using the optional `limit` and `offset` query parameters.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListEnterpriseConnections" method="get" path="/enterprise_connections" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EnterpriseConnections.ListAsync(
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                           | Type                                                                                                                                                                | Required                                                                                                                                                            | Description                                                                                                                                                         | Example                                                                                                                                                             |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                                                             | *long*                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                  | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                               | 20                                                                                                                                                                  |
| `Offset`                                                                                                                                                            | *long*                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                  | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                   | 10                                                                                                                                                                  |
| `OrganizationId`                                                                                                                                                    | *string*                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                  | Filter enterprise connections by organization ID                                                                                                                    |                                                                                                                                                                     |
| `Active`                                                                                                                                                            | *bool*                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                  | Filter by active status. If true, only active connections are returned. If false, only inactive connections are returned. If omitted, all connections are returned. |                                                                                                                                                                     |

### Response

**[ListEnterpriseConnectionsResponse](../../Models/Operations/ListEnterpriseConnectionsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Create a new enterprise connection.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateEnterpriseConnection" method="post" path="/enterprise_connections" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateEnterpriseConnectionRequestBody? req = null;

var res = await sdk.EnterpriseConnections.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                 | [CreateEnterpriseConnectionRequestBody](../../Models/Operations/CreateEnterpriseConnectionRequestBody.md) | :heavy_check_mark:                                                                                        | The request object to use for the request.                                                                |

### Response

**[CreateEnterpriseConnectionResponse](../../Models/Operations/CreateEnterpriseConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Fetches the enterprise connection whose ID matches the provided `enterprise_connection_id` in the path.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetEnterpriseConnection" method="get" path="/enterprise_connections/{enterprise_connection_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EnterpriseConnections.GetAsync(enterpriseConnectionId: "<id>");

// handle response
```

### Parameters

| Parameter                           | Type                                | Required                            | Description                         |
| ----------------------------------- | ----------------------------------- | ----------------------------------- | ----------------------------------- |
| `EnterpriseConnectionId`            | *string*                            | :heavy_check_mark:                  | The ID of the enterprise connection |

### Response

**[GetEnterpriseConnectionResponse](../../Models/Operations/GetEnterpriseConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates the enterprise connection whose ID matches the provided `enterprise_connection_id` in the path.
When enabling the connection (setting `active` to true), any existing verified organization domains that match the connection's domains (e.g. used for enrollment modes like automatic invitation) may be deleted so the connection can be enabled.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateEnterpriseConnection" method="patch" path="/enterprise_connections/{enterprise_connection_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EnterpriseConnections.UpdateAsync(
    enterpriseConnectionId: "<id>",
    requestBody: new UpdateEnterpriseConnectionRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `EnterpriseConnectionId`                                                                                  | *string*                                                                                                  | :heavy_check_mark:                                                                                        | The ID of the enterprise connection to update                                                             |
| `RequestBody`                                                                                             | [UpdateEnterpriseConnectionRequestBody](../../Models/Operations/UpdateEnterpriseConnectionRequestBody.md) | :heavy_check_mark:                                                                                        | N/A                                                                                                       |

### Response

**[UpdateEnterpriseConnectionResponse](../../Models/Operations/UpdateEnterpriseConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 402, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Deletes the enterprise connection whose ID matches the provided `enterprise_connection_id` in the path.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteEnterpriseConnection" method="delete" path="/enterprise_connections/{enterprise_connection_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EnterpriseConnections.DeleteAsync(enterpriseConnectionId: "<id>");

// handle response
```

### Parameters

| Parameter                                     | Type                                          | Required                                      | Description                                   |
| --------------------------------------------- | --------------------------------------------- | --------------------------------------------- | --------------------------------------------- |
| `EnterpriseConnectionId`                      | *string*                                      | :heavy_check_mark:                            | The ID of the enterprise connection to delete |

### Response

**[DeleteEnterpriseConnectionResponse](../../Models/Operations/DeleteEnterpriseConnectionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |