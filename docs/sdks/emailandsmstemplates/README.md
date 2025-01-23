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
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.UpsertAsync(
    templateType: UpsertTemplatePathParamTemplateType.Sms,
    slug: "verification-code",
    requestBody: new UpsertTemplateRequestBody() {
        Name = "Verification Code",
        Subject = "Your Verification Code",
        Markup = "<p>Your code: {{code}}</p>",
        Body = "Use this code to verify your email: {{code}}",
        DeliveredByClerk = true,
        FromEmailName = "hello",
        ReplyToEmailName = "support",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           | Example                                                                                               |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `TemplateType`                                                                                        | [UpsertTemplatePathParamTemplateType](../../Models/Operations/UpsertTemplatePathParamTemplateType.md) | :heavy_check_mark:                                                                                    | The type of template to update                                                                        | sms                                                                                                   |
| `Slug`                                                                                                | *string*                                                                                              | :heavy_check_mark:                                                                                    | The slug of the template to update                                                                    | verification-code                                                                                     |
| `RequestBody`                                                                                         | [UpsertTemplateRequestBody](../../Models/Operations/UpsertTemplateRequestBody.md)                     | :heavy_minus_sign:                                                                                    | N/A                                                                                                   |                                                                                                       |

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
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.RevertAsync(
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

## ~~Preview~~

Returns a preview of a template for a given template_type, slug and body

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAndSmsTemplates.PreviewAsync(
    templateType: "email",
    slug: "welcome-email",
    requestBody: new PreviewTemplateRequestBody() {
        Subject = "Welcome to our service!",
        Body = "Hi, thank you for joining our service.",
        FromEmailName = "hello",
        ReplyToEmailName = "support",
    }
);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `TemplateType`                                                                      | *string*                                                                            | :heavy_check_mark:                                                                  | The type of template to preview                                                     | email                                                                               |
| `Slug`                                                                              | *string*                                                                            | :heavy_check_mark:                                                                  | The slug of the template to preview                                                 | welcome-email                                                                       |
| `RequestBody`                                                                       | [PreviewTemplateRequestBody](../../Models/Operations/PreviewTemplateRequestBody.md) | :heavy_minus_sign:                                                                  | Required parameters                                                                 |                                                                                     |

### Response

**[PreviewTemplateResponse](../../Models/Operations/PreviewTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |