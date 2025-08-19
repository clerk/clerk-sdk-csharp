# BetaFeatures
(*BetaFeatures*)

## Overview

### Available Operations

* [UpdateInstanceSettings](#updateinstancesettings) - Update instance settings
* [~~UpdateProductionInstanceDomain~~](#updateproductioninstancedomain) - Update production instance domain :warning: **Deprecated**

## UpdateInstanceSettings

Updates the settings of an instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateInstanceAuthConfig" method="patch" path="/beta_features/instance_settings" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

UpdateInstanceAuthConfigRequestBody req = new UpdateInstanceAuthConfigRequestBody() {
    FromEmailAddress = "noreply",
    ProgressiveSignUp = true,
    EnhancedEmailDeliverability = true,
    TestMode = true,
};

var res = await sdk.BetaFeatures.UpdateInstanceSettingsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `request`                                                                                             | [UpdateInstanceAuthConfigRequestBody](../../Models/Operations/UpdateInstanceAuthConfigRequestBody.md) | :heavy_check_mark:                                                                                    | The request object to use for the request.                                                            |

### Response

**[UpdateInstanceAuthConfigResponse](../../Models/Operations/UpdateInstanceAuthConfigResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~UpdateProductionInstanceDomain~~

Change the domain of a production instance.

Changing the domain requires updating the [DNS records](https://clerk.com/docs/deployments/overview#dns-records) accordingly, deploying new [SSL certificates](https://clerk.com/docs/deployments/overview#deploy-certificates), updating your Social Connection's redirect URLs and setting the new keys in your code.

WARNING: Changing your domain will invalidate all current user sessions (i.e. users will be logged out). Also, while your application is being deployed, a small downtime is expected to occur.

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateProductionInstanceDomain" method="put" path="/beta_features/domain" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

UpdateProductionInstanceDomainRequestBody req = new UpdateProductionInstanceDomainRequestBody() {
    HomeUrl = "https://www.example.com",
};

var res = await sdk.BetaFeatures.UpdateProductionInstanceDomainAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                         | [UpdateProductionInstanceDomainRequestBody](../../Models/Operations/UpdateProductionInstanceDomainRequestBody.md) | :heavy_check_mark:                                                                                                | The request object to use for the request.                                                                        |

### Response

**[UpdateProductionInstanceDomainResponse](../../Models/Operations/UpdateProductionInstanceDomainResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |