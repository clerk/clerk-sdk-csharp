# Templates
(*Templates*)

## Overview

### Available Operations

* [~~Preview~~](#preview) - Preview changes to a template :warning: **Deprecated**

## ~~Preview~~

Returns a preview of a template for a given template_type, slug and body

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="PreviewTemplate" method="post" path="/templates/{template_type}/{slug}/preview" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Templates.PreviewAsync(
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