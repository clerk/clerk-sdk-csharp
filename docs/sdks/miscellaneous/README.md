# Miscellaneous
(*Miscellaneous*)

## Overview

### Available Operations

* [GetPublicInterstitial](#getpublicinterstitial) - Returns the markup for the interstitial page

## GetPublicInterstitial

The Clerk interstitial endpoint serves an html page that loads clerk.js in order to check the user's authentication state.
It is used by Clerk SDKs when the user's authentication state cannot be immediately determined.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi();

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [GetPublicInterstitialRequest](../../Models/Operations/GetPublicInterstitialRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[GetPublicInterstitialResponse](../../Models/Operations/GetPublicInterstitialResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |