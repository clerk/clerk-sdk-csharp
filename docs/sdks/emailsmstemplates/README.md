# EmailSMSTemplates
(*EmailSMSTemplates*)

## Overview

### Available Operations

* [~~List~~](#list) - List all templates :warning: **Deprecated**
* [~~Get~~](#get) - Retrieve a template :warning: **Deprecated**
* [~~Revert~~](#revert) - Revert a template :warning: **Deprecated**
* [~~ToggleTemplateDelivery~~](#toggletemplatedelivery) - Toggle the delivery by Clerk for a template of a given type and slug :warning: **Deprecated**

## ~~List~~

Returns a list of all templates.
The templates are returned sorted by position.

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailSMSTemplates.ListAsync(
    templateType: TemplateType.Email,
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               | Example                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                                                            | [TemplateType](../../Models/Operations/TemplateType.md)                                                                                   | :heavy_check_mark:                                                                                                                        | The type of templates to list (email or SMS)                                                                                              | email                                                                                                                                     |
| `Paginated`                                                                                                                               | *bool*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Whether to paginate the results.<br/>If true, the results will be paginated.<br/>If false, the results will not be paginated.             |                                                                                                                                           |
| `Limit`                                                                                                                                   | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     | 20                                                                                                                                        |
| `Offset`                                                                                                                                  | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. | 10                                                                                                                                        |

### Response

**[GetTemplateListResponse](../../Models/Operations/GetTemplateListResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~Get~~

Returns the details of a template

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailSMSTemplates.GetAsync(
    templateType: PathParamTemplateType.Email,
    slug: "welcome-email"
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `TemplateType`                                                            | [PathParamTemplateType](../../Models/Operations/PathParamTemplateType.md) | :heavy_check_mark:                                                        | The type of templates to retrieve (email or SMS)                          | email                                                                     |
| `Slug`                                                                    | *string*                                                                  | :heavy_check_mark:                                                        | The slug (i.e. machine-friendly name) of the template to retrieve         | welcome-email                                                             |

### Response

**[GetTemplateResponse](../../Models/Operations/GetTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~Revert~~

Reverts an updated template to its default state

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailSMSTemplates.RevertAsync(
    templateType: RevertTemplatePathParamTemplateType.Email,
    slug: "welcome-email"
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           | Example                                                                                               |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                        | [RevertTemplatePathParamTemplateType](../../Models/Operations/RevertTemplatePathParamTemplateType.md) | :heavy_check_mark:                                                                                    | The type of template to revert                                                                        | email                                                                                                 |
| `Slug`                                                                                                | *string*                                                                                              | :heavy_check_mark:                                                                                    | The slug of the template to revert                                                                    | welcome-email                                                                                         |

### Response

**[RevertTemplateResponse](../../Models/Operations/RevertTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 402, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~ToggleTemplateDelivery~~

Toggles the delivery by Clerk for a template of a given type and slug.
If disabled, Clerk will not deliver the resulting email or SMS.
The app developer will need to listen to the `email.created` or `sms.created` webhooks in order to handle delivery themselves.

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailSMSTemplates.ToggleTemplateDeliveryAsync(
    templateType: ToggleTemplateDeliveryPathParamTemplateType.Email,
    slug: "welcome-email",
    requestBody: new ToggleTemplateDeliveryRequestBody() {
        DeliveredByClerk = true,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                             | Type                                                                                                                  | Required                                                                                                              | Description                                                                                                           | Example                                                                                                               |
| --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                                        | [ToggleTemplateDeliveryPathParamTemplateType](../../Models/Operations/ToggleTemplateDeliveryPathParamTemplateType.md) | :heavy_check_mark:                                                                                                    | The type of template to toggle delivery for                                                                           | email                                                                                                                 |
| `Slug`                                                                                                                | *string*                                                                                                              | :heavy_check_mark:                                                                                                    | The slug of the template for which to toggle delivery                                                                 | welcome-email                                                                                                         |
| `RequestBody`                                                                                                         | [ToggleTemplateDeliveryRequestBody](../../Models/Operations/ToggleTemplateDeliveryRequestBody.md)                     | :heavy_minus_sign:                                                                                                    | N/A                                                                                                                   |                                                                                                                       |

### Response

**[ToggleTemplateDeliveryResponse](../../Models/Operations/ToggleTemplateDeliveryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |