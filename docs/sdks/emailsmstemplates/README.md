# EmailSmsTemplates
(*EmailSmsTemplates*)

## Overview

### Available Operations

* [~~List~~](#list) - List all templates :warning: **Deprecated**
* [~~Get~~](#get) - Retrieve a template :warning: **Deprecated**
* [~~ToggleDelivery~~](#toggledelivery) - Toggle the delivery by Clerk for a template of a given type and slug :warning: **Deprecated**

## ~~List~~

Returns a list of all templates.
The templates are returned sorted by position.

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailSmsTemplates.ListAsync(templateType: Clerk.BackendAPI.Models.Operations.TemplateType.Sms);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `TemplateType`                                          | [TemplateType](../../Models/Operations/TemplateType.md) | :heavy_check_mark:                                      | The type of templates to list (email or SMS)            |

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
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailSmsTemplates.GetAsync(
    templateType: Clerk.BackendAPI.Models.Operations.PathParamTemplateType.Sms,
    slug: "<value>"
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `TemplateType`                                                            | [PathParamTemplateType](../../Models/Operations/PathParamTemplateType.md) | :heavy_check_mark:                                                        | The type of templates to retrieve (email or SMS)                          |
| `Slug`                                                                    | *string*                                                                  | :heavy_check_mark:                                                        | The slug (i.e. machine-friendly name) of the template to retrieve         |

### Response

**[GetTemplateResponse](../../Models/Operations/GetTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~ToggleDelivery~~

Toggles the delivery by Clerk for a template of a given type and slug.
If disabled, Clerk will not deliver the resulting email or SMS.
The app developer will need to listen to the `email.created` or `sms.created` webhooks in order to handle delivery themselves.

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailSmsTemplates.ToggleDeliveryAsync(
    templateType: Clerk.BackendAPI.Models.Operations.ToggleTemplateDeliveryPathParamTemplateType.Email,
    slug: "<value>",
    requestBody: new ToggleTemplateDeliveryRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                                             | Type                                                                                                                  | Required                                                                                                              | Description                                                                                                           |
| --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                                        | [ToggleTemplateDeliveryPathParamTemplateType](../../Models/Operations/ToggleTemplateDeliveryPathParamTemplateType.md) | :heavy_check_mark:                                                                                                    | The type of template to toggle delivery for                                                                           |
| `Slug`                                                                                                                | *string*                                                                                                              | :heavy_check_mark:                                                                                                    | The slug of the template for which to toggle delivery                                                                 |
| `RequestBody`                                                                                                         | [ToggleTemplateDeliveryRequestBody](../../Models/Operations/ToggleTemplateDeliveryRequestBody.md)                     | :heavy_minus_sign:                                                                                                    | N/A                                                                                                                   |

### Response

**[ToggleTemplateDeliveryResponse](../../Models/Operations/ToggleTemplateDeliveryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |