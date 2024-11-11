# Miscellaneous
(*Miscellaneous*)

## Overview

Various endpoints that do not belong in any particular category.

### Available Operations

* [GetPublicInterstitial](#getpublicinterstitial) - Returns the markup for the interstitial page

## GetPublicInterstitial

The Clerk interstitial endpoint serves an html page that loads clerk.js in order to check the user's authentication state.
It is used by Clerk SDKs when the user's authentication state cannot be immediately determined.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi();

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(
    frontendApi: "<value>",
    publishableKey: "<value>"
);

// handle response
```

### Parameters

| Parameter                             | Type                                  | Required                              | Description                           |
| ------------------------------------- | ------------------------------------- | ------------------------------------- | ------------------------------------- |
| `FrontendApi`                         | *string*                              | :heavy_minus_sign:                    | The Frontend API key of your instance |
| `PublishableKey`                      | *string*                              | :heavy_minus_sign:                    | The publishable key of your instance  |

### Response

**[GetPublicInterstitialResponse](../../Models/Requests/GetPublicInterstitialResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |