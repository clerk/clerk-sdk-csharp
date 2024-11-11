# SignUps
(*SignUps*)

## Overview

### Available Operations

* [Update](#update) - Update a sign-up

## Update

Update the sign-up with the given ID

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.SignUps.UpdateAsync(
    id: "<id>",
    requestBody: new UpdateSignUpRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `Id`                                                                        | *string*                                                                    | :heavy_check_mark:                                                          | The ID of the sign-up to update                                             |
| `RequestBody`                                                               | [UpdateSignUpRequestBody](../../Models/Requests/UpdateSignUpRequestBody.md) | :heavy_minus_sign:                                                          | N/A                                                                         |

### Response

**[UpdateSignUpResponse](../../Models/Requests/UpdateSignUpResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 403                                                                           | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |