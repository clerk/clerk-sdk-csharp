# InstanceSettings
(*InstanceSettings*)

## Overview

### Available Operations

* [Get](#get) - Fetch the current instance
* [Update](#update) - Update instance settings
* [UpdateRestrictions](#updaterestrictions) - Update instance restrictions
* [ChangeDomain](#changedomain) - Update production instance domain
* [UpdateOrganizationSettings](#updateorganizationsettings) - Update instance organization settings

## Get

Fetches the current instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetInstance" method="get" path="/instance" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.InstanceSettings.GetAsync();

// handle response
```

### Response

**[GetInstanceResponse](../../Models/Operations/GetInstanceResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |

## Update

Updates the settings of an instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateInstance" method="patch" path="/instance" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

UpdateInstanceRequestBody req = new UpdateInstanceRequestBody() {
    TestMode = true,
    Hibp = false,
    EnhancedEmailDeliverability = true,
    SupportEmail = "support@example.com",
    ClerkJsVersion = "2.3.1",
    DevelopmentOrigin = "http://localhost:3000",
    AllowedOrigins = new List<string>() {
        "http://localhost:3000",
        "chrome-extension://extension_uiid",
        "capacitor://localhost",
    },
    UrlBasedSessionSyncing = true,
};

var res = await sdk.InstanceSettings.UpdateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `request`                                                                         | [UpdateInstanceRequestBody](../../Models/Operations/UpdateInstanceRequestBody.md) | :heavy_check_mark:                                                                | The request object to use for the request.                                        |

### Response

**[UpdateInstanceResponse](../../Models/Operations/UpdateInstanceResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 422                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## UpdateRestrictions

Updates the restriction settings of an instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateInstanceRestrictions" method="patch" path="/instance/restrictions" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

UpdateInstanceRestrictionsRequestBody req = new UpdateInstanceRestrictionsRequestBody() {
    Allowlist = false,
    Blocklist = true,
    BlockEmailSubaddresses = true,
    BlockDisposableEmailDomains = true,
};

var res = await sdk.InstanceSettings.UpdateRestrictionsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                 | [UpdateInstanceRestrictionsRequestBody](../../Models/Operations/UpdateInstanceRestrictionsRequestBody.md) | :heavy_check_mark:                                                                                        | The request object to use for the request.                                                                |

### Response

**[UpdateInstanceRestrictionsResponse](../../Models/Operations/UpdateInstanceRestrictionsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ChangeDomain

Change the domain of a production instance.

Changing the domain requires updating the [DNS records](https://clerk.com/docs/deployments/overview#dns-records) accordingly, deploying new [SSL certificates](https://clerk.com/docs/deployments/overview#deploy), updating your Social Connection's redirect URLs and setting the new keys in your code.

WARNING: Changing your domain will invalidate all current user sessions (i.e. users will be logged out). Also, while your application is being deployed, a small downtime is expected to occur.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ChangeProductionInstanceDomain" method="post" path="/instance/change_domain" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ChangeProductionInstanceDomainRequestBody req = new ChangeProductionInstanceDomainRequestBody() {
    HomeUrl = "https://www.newdomain.com",
};

var res = await sdk.InstanceSettings.ChangeDomainAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                         | [ChangeProductionInstanceDomainRequestBody](../../Models/Operations/ChangeProductionInstanceDomainRequestBody.md) | :heavy_check_mark:                                                                                                | The request object to use for the request.                                                                        |

### Response

**[ChangeProductionInstanceDomainResponse](../../Models/Operations/ChangeProductionInstanceDomainResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## UpdateOrganizationSettings

Updates the organization settings of the instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateInstanceOrganizationSettings" method="patch" path="/instance/organization_settings" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

UpdateInstanceOrganizationSettingsRequestBody req = new UpdateInstanceOrganizationSettingsRequestBody() {
    Enabled = true,
    MaxAllowedMemberships = 10,
    AdminDeleteEnabled = false,
    DomainsEnabled = true,
    DomainsEnrollmentModes = new List<string>() {
        "automatic_invitation",
        "automatic_suggestion",
    },
    CreatorRoleId = "creator_role",
    DomainsDefaultRoleId = "member_role",
};

var res = await sdk.InstanceSettings.UpdateOrganizationSettingsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                                 | Type                                                                                                                      | Required                                                                                                                  | Description                                                                                                               |
| ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                                 | [UpdateInstanceOrganizationSettingsRequestBody](../../Models/Operations/UpdateInstanceOrganizationSettingsRequestBody.md) | :heavy_check_mark:                                                                                                        | The request object to use for the request.                                                                                |

### Response

**[UpdateInstanceOrganizationSettingsResponse](../../Models/Operations/UpdateInstanceOrganizationSettingsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 402, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |