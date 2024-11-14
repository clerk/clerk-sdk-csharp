# PhoneNumbers
(*PhoneNumbers*)

## Overview

### Available Operations

* [Create](#create) - Create a phone number
* [Get](#get) - Retrieve a phone number
* [Delete](#delete) - Delete a phone number
* [Update](#update) - Update a phone number

## Create

Create a new phone number

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreatePhoneNumberRequestBody req = new CreatePhoneNumberRequestBody() {
    UserId = "usr_12345",
    PhoneNumber = "+11234567890",
    Verified = true,
    Primary = false,
    ReservedForSecondFactor = false,
};

var res = await sdk.PhoneNumbers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [CreatePhoneNumberRequestBody](../../Models/Operations/CreatePhoneNumberRequestBody.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[CreatePhoneNumberResponse](../../Models/Operations/CreatePhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Returns the details of a phone number

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.GetAsync(phoneNumberId: "phone_12345");

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            | Example                                |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `PhoneNumberId`                        | *string*                               | :heavy_check_mark:                     | The ID of the phone number to retrieve | phone_12345                            |

### Response

**[GetPhoneNumberResponse](../../Models/Operations/GetPhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Delete the phone number with the given ID

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.DeleteAsync(phoneNumberId: "phone_12345");

// handle response
```

### Parameters

| Parameter                            | Type                                 | Required                             | Description                          | Example                              |
| ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ |
| `PhoneNumberId`                      | *string*                             | :heavy_check_mark:                   | The ID of the phone number to delete | phone_12345                          |

### Response

**[DeletePhoneNumberResponse](../../Models/Operations/DeletePhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates a phone number

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.UpdateAsync(
    phoneNumberId: "phone_12345",
    requestBody: new UpdatePhoneNumberRequestBody() {
        Verified = false,
        Primary = true,
        ReservedForSecondFactor = true,
    }
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `PhoneNumberId`                                                                         | *string*                                                                                | :heavy_check_mark:                                                                      | The ID of the phone number to update                                                    | phone_12345                                                                             |
| `RequestBody`                                                                           | [UpdatePhoneNumberRequestBody](../../Models/Operations/UpdatePhoneNumberRequestBody.md) | :heavy_minus_sign:                                                                      | N/A                                                                                     |                                                                                         |

### Response

**[UpdatePhoneNumberResponse](../../Models/Operations/UpdatePhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |