# EmailAndSmsTemplates
(*EmailAndSmsTemplates*)

## Overview

### Available Operations

* [~~Upsert~~](#upsert) - Update a template for a given type and slug :warning: **Deprecated**

## ~~Upsert~~

Updates the existing template of the given type and slug

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpsertTemplate" method="put" path="/templates/{template_type}/{slug}" -->
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