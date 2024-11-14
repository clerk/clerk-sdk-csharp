# InstanceSettings
(*InstanceSettings*)

## Overview

### Available Operations

* [Update](#update) - Update instance settings
* [UpdateRestrictions](#updaterestrictions) - Update instance restrictions
* [UpdateOrganization](#updateorganization) - Update instance organization settings

## Update

Updates the settings of an instance

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;
using Clerk.BackendAPI.Models.Components;

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

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

UpdateInstanceRestrictionsRequestBody req = new UpdateInstanceRestrictionsRequestBody() {
    Allowlist = false,
    Blocklist = true,
    BlockEmailSubaddresses = true,
    BlockDisposableEmailDomains = true,
    IgnoreDotsForGmailAddresses = false,
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

## UpdateOrganization

Updates the organization settings of the instance

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;
using Clerk.BackendAPI.Models.Components;

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

var res = await sdk.InstanceSettings.UpdateOrganizationAsync(req);

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
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 404, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |