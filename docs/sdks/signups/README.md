# SignUps
(*SignUps*)

## Overview

### Available Operations

* [Get](#get) - Retrieve a sign-up by ID
* [Update](#update) - Update a sign-up

## Get

Retrieve the details of the sign-up with the given ID

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetSignUp" method="get" path="/sign_ups/{id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SignUps.GetAsync(id: "<id>");

// handle response
```

### Parameters

| Parameter                         | Type                              | Required                          | Description                       |
| --------------------------------- | --------------------------------- | --------------------------------- | --------------------------------- |
| `Id`                              | *string*                          | :heavy_check_mark:                | The ID of the sign-up to retrieve |

### Response

**[GetSignUpResponse](../../Models/Operations/GetSignUpResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Update the sign-up with the given ID

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateSignUp" method="patch" path="/sign_ups/{id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SignUps.UpdateAsync(
    id: "signup_1234567890abcdef",
    requestBody: new UpdateSignUpRequestBody() {
        ExternalId = "ext_id_7890abcdef123456",
        CustomAction = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `Id`                                                                          | *string*                                                                      | :heavy_check_mark:                                                            | The ID of the sign-up to update                                               | signup_1234567890abcdef                                                       |
| `RequestBody`                                                                 | [UpdateSignUpRequestBody](../../Models/Operations/UpdateSignUpRequestBody.md) | :heavy_minus_sign:                                                            | N/A                                                                           |                                                                               |

### Response

**[UpdateSignUpResponse](../../Models/Operations/UpdateSignUpResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |