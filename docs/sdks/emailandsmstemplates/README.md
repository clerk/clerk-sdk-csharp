# EmailAndSmsTemplates
(*EmailAndSmsTemplates*)

## Overview

### Available Operations

* [~~Upsert~~](#upsert) - Update a template for a given type and slug :warning: **Deprecated**
* [~~Revert~~](#revert) - Revert a template :warning: **Deprecated**
* [~~Preview~~](#preview) - Preview changes to a template :warning: **Deprecated**

## ~~Upsert~~

Updates the existing template of the given type and slug

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.UpsertAsync(
    templateType: Clerk.BackendAPI.Models.Operations.UpsertTemplatePathParamTemplateType.Sms,
    slug: "<value>",
    requestBody: new UpsertTemplateRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                        | [UpsertTemplatePathParamTemplateType](../../Models/Operations/UpsertTemplatePathParamTemplateType.md) | :heavy_check_mark:                                                                                    | The type of template to update                                                                        |
| `Slug`                                                                                                | *string*                                                                                              | :heavy_check_mark:                                                                                    | The slug of the template to update                                                                    |
| `RequestBody`                                                                                         | [UpsertTemplateRequestBody](../../Models/Operations/UpsertTemplateRequestBody.md)                     | :heavy_minus_sign:                                                                                    | N/A                                                                                                   |

### Response

**[UpsertTemplateResponse](../../Models/Operations/UpsertTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 402, 403, 404, 422               | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~Revert~~

Reverts an updated template to its default state

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.RevertAsync(
    templateType: Clerk.BackendAPI.Models.Operations.RevertTemplatePathParamTemplateType.Email,
    slug: "<value>"
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                        | [RevertTemplatePathParamTemplateType](../../Models/Operations/RevertTemplatePathParamTemplateType.md) | :heavy_check_mark:                                                                                    | The type of template to revert                                                                        |
| `Slug`                                                                                                | *string*                                                                                              | :heavy_check_mark:                                                                                    | The slug of the template to revert                                                                    |

### Response

**[RevertTemplateResponse](../../Models/Operations/RevertTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 402, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~Preview~~

Returns a preview of a template for a given template_type, slug and body

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.PreviewAsync(
    templateType: "<value>",
    slug: "<value>",
    requestBody: new PreviewTemplateRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `TemplateType`                                                                      | *string*                                                                            | :heavy_check_mark:                                                                  | The type of template to preview                                                     |
| `Slug`                                                                              | *string*                                                                            | :heavy_check_mark:                                                                  | The slug of the template to preview                                                 |
| `RequestBody`                                                                       | [PreviewTemplateRequestBody](../../Models/Operations/PreviewTemplateRequestBody.md) | :heavy_minus_sign:                                                                  | Required parameters                                                                 |

### Response

**[PreviewTemplateResponse](../../Models/Operations/PreviewTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |