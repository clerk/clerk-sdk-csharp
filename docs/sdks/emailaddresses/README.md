# EmailAddresses
(*EmailAddresses*)

## Overview

### Available Operations

* [Create](#create) - Create an email address
* [Get](#get) - Retrieve an email address
* [Delete](#delete) - Delete an email address
* [Update](#update) - Update an email address

## Create

Create a new email address

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateEmailAddressRequestBody req = new CreateEmailAddressRequestBody() {};

var res = await sdk.EmailAddresses.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `request`                                                                                 | [CreateEmailAddressRequestBody](../../Models/Operations/CreateEmailAddressRequestBody.md) | :heavy_check_mark:                                                                        | The request object to use for the request.                                                |

### Response

**[CreateEmailAddressResponse](../../Models/Operations/CreateEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Returns the details of an email address.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.GetAsync(emailAddressId: "<id>");

// handle response
```

### Parameters

| Parameter                               | Type                                    | Required                                | Description                             |
| --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- |
| `EmailAddressId`                        | *string*                                | :heavy_check_mark:                      | The ID of the email address to retrieve |

### Response

**[GetEmailAddressResponse](../../Models/Operations/GetEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Delete the email address with the given ID

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.DeleteAsync(emailAddressId: "<id>");

// handle response
```

### Parameters

| Parameter                             | Type                                  | Required                              | Description                           |
| ------------------------------------- | ------------------------------------- | ------------------------------------- | ------------------------------------- |
| `EmailAddressId`                      | *string*                              | :heavy_check_mark:                    | The ID of the email address to delete |

### Response

**[DeleteEmailAddressResponse](../../Models/Operations/DeleteEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates an email address.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.UpdateAsync(
    emailAddressId: "<id>",
    requestBody: new UpdateEmailAddressRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `EmailAddressId`                                                                          | *string*                                                                                  | :heavy_check_mark:                                                                        | The ID of the email address to update                                                     |
| `RequestBody`                                                                             | [UpdateEmailAddressRequestBody](../../Models/Operations/UpdateEmailAddressRequestBody.md) | :heavy_minus_sign:                                                                        | N/A                                                                                       |

### Response

**[UpdateEmailAddressResponse](../../Models/Operations/UpdateEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |