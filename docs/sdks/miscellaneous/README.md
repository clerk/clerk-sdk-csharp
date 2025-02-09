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
using Clerk.BackendAPI;

var sdk = new ClerkBackendApi();

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(
    frontendApi: "frontend-api_1a2b3c4d",
    publishableKey: "pub_1a2b3c4d"
);

// handle response
```

### Parameters

| Parameter                             | Type                                  | Required                              | Description                           | Example                               |
| ------------------------------------- | ------------------------------------- | ------------------------------------- | ------------------------------------- | ------------------------------------- |
| `FrontendApi`                         | *string*                              | :heavy_minus_sign:                    | The Frontend API key of your instance | frontend-api_1a2b3c4d                 |
| `PublishableKey`                      | *string*                              | :heavy_minus_sign:                    | The publishable key of your instance  | pub_1a2b3c4d                          |

### Response

**[GetPublicInterstitialResponse](../../Models/Operations/GetPublicInterstitialResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |