# Machines

## Overview

### Available Operations

* [List](#list) - Get a list of machines for an instance
* [Create](#create) - Create a machine
* [Get](#get) - Retrieve a machine
* [Update](#update) - Update a machine
* [Delete](#delete) - Delete a machine
* [GetSecretKey](#getsecretkey) - Retrieve a machine secret key
* [RotateSecretKey](#rotatesecretkey) - Rotate a machine's secret key
* [CreateScope](#createscope) - Create a machine scope
* [DeleteScope](#deletescope) - Delete a machine scope

## List

This request returns the list of machines for an instance. The machines are
ordered by descending creation date (i.e. most recent machines will be
returned first)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListMachines" method="get" path="/machines" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Machines.ListAsync(
    limit: 20,
    offset: 10,
    orderBy: "-created_at"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                | *long*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                                                                                                                                                                                  | 20                                                                                                                                                                                                                                                                                                                                                                                     |
| `Offset`                                                                                                                                                                                                                                                                                                                                                                               | *long*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                                                                                                                                                                      | 10                                                                                                                                                                                                                                                                                                                                                                                     |
| `Query`                                                                                                                                                                                                                                                                                                                                                                                | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Returns machines with ID or name that match the given query. Uses exact match for machine ID and partial match for name.                                                                                                                                                                                                                                                               |                                                                                                                                                                                                                                                                                                                                                                                        |
| `OrderBy`                                                                                                                                                                                                                                                                                                                                                                              | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Allows to return machines in a particular order.<br/>You can order the returned machines by their `name` or `created_at`.<br/>To specify the direction, use the `+` or `-` symbols prepended to the property to order by.<br/>For example, to return machines in descending order by `created_at`, use `-created_at`.<br/>If you don't use `+` or `-`, then `+` is implied.<br/>Defaults to `-created_at`. |                                                                                                                                                                                                                                                                                                                                                                                        |

### Response

**[ListMachinesResponse](../../Models/Operations/ListMachinesResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Creates a new machine.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateMachine" method="post" path="/machines" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateMachineRequestBody? req = null;

var res = await sdk.Machines.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [CreateMachineRequestBody](../../Models/Operations/CreateMachineRequestBody.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[CreateMachineResponse](../../Models/Operations/CreateMachineResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Returns the details of a machine.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetMachine" method="get" path="/machines/{machine_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Machines.GetAsync(machineId: "<id>");

// handle response
```

### Parameters

| Parameter                         | Type                              | Required                          | Description                       |
| --------------------------------- | --------------------------------- | --------------------------------- | --------------------------------- |
| `MachineId`                       | *string*                          | :heavy_check_mark:                | The ID of the machine to retrieve |

### Response

**[GetMachineResponse](../../Models/Operations/GetMachineResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates an existing machine.
Only the provided fields will be updated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateMachine" method="patch" path="/machines/{machine_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Machines.UpdateAsync(machineId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `MachineId`                                                                     | *string*                                                                        | :heavy_check_mark:                                                              | The ID of the machine to update                                                 |
| `RequestBody`                                                                   | [UpdateMachineRequestBody](../../Models/Operations/UpdateMachineRequestBody.md) | :heavy_minus_sign:                                                              | N/A                                                                             |

### Response

**[UpdateMachineResponse](../../Models/Operations/UpdateMachineResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Deletes a machine.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteMachine" method="delete" path="/machines/{machine_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Machines.DeleteAsync(machineId: "<id>");

// handle response
```

### Parameters

| Parameter                       | Type                            | Required                        | Description                     |
| ------------------------------- | ------------------------------- | ------------------------------- | ------------------------------- |
| `MachineId`                     | *string*                        | :heavy_check_mark:              | The ID of the machine to delete |

### Response

**[DeleteMachineResponse](../../Models/Operations/DeleteMachineResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetSecretKey

Returns the secret key for a machine.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetMachineSecretKey" method="get" path="/machines/{machine_id}/secret_key" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Machines.GetSecretKeyAsync(machineId: "<id>");

// handle response
```

### Parameters

| Parameter                                            | Type                                                 | Required                                             | Description                                          |
| ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| `MachineId`                                          | *string*                                             | :heavy_check_mark:                                   | The ID of the machine to retrieve the secret key for |

### Response

**[GetMachineSecretKeyResponse](../../Models/Operations/GetMachineSecretKeyResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## RotateSecretKey

Rotates the machine's secret key.
When the secret key is rotated, make sure to update it in your machine/application.
The previous secret key will remain valid for the duration specified by the previous_token_ttl parameter.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RotateMachineSecretKey" method="post" path="/machines/{machine_id}/secret_key/rotate" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Machines.RotateSecretKeyAsync(
    machineId: "<id>",
    requestBody: new RotateMachineSecretKeyRequestBody() {
        PreviousTokenTtl = 632625,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `MachineId`                                                                                       | *string*                                                                                          | :heavy_check_mark:                                                                                | The ID of the machine to rotate the secret key for                                                |
| `RequestBody`                                                                                     | [RotateMachineSecretKeyRequestBody](../../Models/Operations/RotateMachineSecretKeyRequestBody.md) | :heavy_check_mark:                                                                                | N/A                                                                                               |

### Response

**[RotateMachineSecretKeyResponse](../../Models/Operations/RotateMachineSecretKeyResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateScope

Creates a new machine scope, allowing the specified machine to access another machine.
Maximum of 150 scopes per machine.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateMachineScope" method="post" path="/machines/{machine_id}/scopes" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Machines.CreateScopeAsync(machineId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `MachineId`                                                                               | *string*                                                                                  | :heavy_check_mark:                                                                        | The ID of the machine that will have access to another machine                            |
| `RequestBody`                                                                             | [CreateMachineScopeRequestBody](../../Models/Operations/CreateMachineScopeRequestBody.md) | :heavy_minus_sign:                                                                        | N/A                                                                                       |

### Response

**[CreateMachineScopeResponse](../../Models/Operations/CreateMachineScopeResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 409, 422               | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteScope

Deletes a machine scope, removing access from one machine to another.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteMachineScope" method="delete" path="/machines/{machine_id}/scopes/{other_machine_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Machines.DeleteScopeAsync(
    machineId: "<id>",
    otherMachineId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                | Type                                                     | Required                                                 | Description                                              |
| -------------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------------------- |
| `MachineId`                                              | *string*                                                 | :heavy_check_mark:                                       | The ID of the machine that has access to another machine |
| `OtherMachineId`                                         | *string*                                                 | :heavy_check_mark:                                       | The ID of the machine that is being accessed             |

### Response

**[DeleteMachineScopeResponse](../../Models/Operations/DeleteMachineScopeResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |