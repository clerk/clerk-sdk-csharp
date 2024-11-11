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
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.UpsertAsync(
    templateType: OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests.UpsertTemplatePathParamTemplateType.Sms,
    slug: "<value>",
    requestBody: new UpsertTemplateRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                           | Type                                                                                                | Required                                                                                            | Description                                                                                         |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                      | [UpsertTemplatePathParamTemplateType](../../Models/Requests/UpsertTemplatePathParamTemplateType.md) | :heavy_check_mark:                                                                                  | The type of template to update                                                                      |
| `Slug`                                                                                              | *string*                                                                                            | :heavy_check_mark:                                                                                  | The slug of the template to update                                                                  |
| `RequestBody`                                                                                       | [UpsertTemplateRequestBody](../../Models/Requests/UpsertTemplateRequestBody.md)                     | :heavy_minus_sign:                                                                                  | N/A                                                                                                 |

### Response

**[UpsertTemplateResponse](../../Models/Requests/UpsertTemplateResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 401, 402, 403, 404, 422                                                  | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## ~~Revert~~

Reverts an updated template to its default state

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.RevertAsync(
    templateType: OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests.RevertTemplatePathParamTemplateType.Email,
    slug: "<value>"
);

// handle response
```

### Parameters

| Parameter                                                                                           | Type                                                                                                | Required                                                                                            | Description                                                                                         |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                      | [RevertTemplatePathParamTemplateType](../../Models/Requests/RevertTemplatePathParamTemplateType.md) | :heavy_check_mark:                                                                                  | The type of template to revert                                                                      |
| `Slug`                                                                                              | *string*                                                                                            | :heavy_check_mark:                                                                                  | The slug of the template to revert                                                                  |

### Response

**[RevertTemplateResponse](../../Models/Requests/RevertTemplateResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 401, 402, 404                                                            | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## ~~Preview~~

Returns a preview of a template for a given template_type, slug and body

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.PreviewAsync(
    templateType: "<value>",
    slug: "<value>",
    requestBody: new PreviewTemplateRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `TemplateType`                                                                    | *string*                                                                          | :heavy_check_mark:                                                                | The type of template to preview                                                   |
| `Slug`                                                                            | *string*                                                                          | :heavy_check_mark:                                                                | The slug of the template to preview                                               |
| `RequestBody`                                                                     | [PreviewTemplateRequestBody](../../Models/Requests/PreviewTemplateRequestBody.md) | :heavy_minus_sign:                                                                | Required parameters                                                               |

### Response

**[PreviewTemplateResponse](../../Models/Requests/PreviewTemplateResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400, 401, 404, 422                                                            | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |