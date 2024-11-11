# UserWeb3Wallets
(*UserWeb3Wallets*)

## Overview

### Available Operations

* [Delete](#delete) - Delete a user web3 wallet

## Delete

Delete the web3 wallet identification for a given user.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.UserWeb3Wallets.DeleteAsync(
    userId: "<id>",
    web3WalletIdentificationId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                        | Type                                             | Required                                         | Description                                      |
| ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ |
| `UserId`                                         | *string*                                         | :heavy_check_mark:                               | The ID of the user that owns the web3 wallet     |
| `Web3WalletIdentificationId`                     | *string*                                         | :heavy_check_mark:                               | The ID of the web3 wallet identity to be deleted |

### Response

**[UserWeb3WalletDeleteResponse](../../Models/Requests/UserWeb3WalletDeleteResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 403, 404, 500                                                            | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |