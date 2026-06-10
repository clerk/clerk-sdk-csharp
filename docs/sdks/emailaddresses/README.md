# EmailAddresses

## Overview

### Available Operations

* [Create](#create) - Create an email address
* [Get](#get) - Retrieve an email address
* [Delete](#delete) - Delete an email address
* [Update](#update) - Update an email address
* [PrepareVerification](#prepareverification) - Send a verification code to an email address
* [AttemptVerification](#attemptverification) - Verify a code sent to an email address
* [ReplaceForUser](#replaceforuser) - Replace a user's email address

## Create

Create a new email address

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateEmailAddress" method="post" path="/email_addresses" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateEmailAddressRequestBody req = new CreateEmailAddressRequestBody() {
    UserId = "user_12345",
    EmailAddress = "example@clerk.com",
    Verified = false,
    Primary = true,
};

var res = await sdk.EmailAddresses.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `request`                                                                                 | [CreateEmailAddressRequestBody](../../Models/Operations/CreateEmailAddressRequestBody.md) | :heavy_check_mark:                                                                        | The request object to use for the request.                                                |

### Response

**[CreateEmailAddressResponse](../../Models/Operations/CreateEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 409, 422               | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Returns the details of an email address.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetEmailAddress" method="get" path="/email_addresses/{email_address_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.GetAsync(emailAddressId: "email_address_id_example");

// handle response
```

### Parameters

| Parameter                               | Type                                    | Required                                | Description                             | Example                                 |
| --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- |
| `EmailAddressId`                        | *string*                                | :heavy_check_mark:                      | The ID of the email address to retrieve | email_address_id_example                |

### Response

**[GetEmailAddressResponse](../../Models/Operations/GetEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Delete the email address with the given ID

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteEmailAddress" method="delete" path="/email_addresses/{email_address_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.DeleteAsync(emailAddressId: "email_address_id_example");

// handle response
```

### Parameters

| Parameter                             | Type                                  | Required                              | Description                           | Example                               |
| ------------------------------------- | ------------------------------------- | ------------------------------------- | ------------------------------------- | ------------------------------------- |
| `EmailAddressId`                      | *string*                              | :heavy_check_mark:                    | The ID of the email address to delete | email_address_id_example              |

### Response

**[DeleteEmailAddressResponse](../../Models/Operations/DeleteEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 409                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates an email address.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateEmailAddress" method="patch" path="/email_addresses/{email_address_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.UpdateAsync(
    emailAddressId: "email_address_id_example",
    requestBody: new UpdateEmailAddressRequestBody() {
        Verified = false,
        Primary = true,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               | Example                                                                                   |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `EmailAddressId`                                                                          | *string*                                                                                  | :heavy_check_mark:                                                                        | The ID of the email address to update                                                     | email_address_id_example                                                                  |
| `RequestBody`                                                                             | [UpdateEmailAddressRequestBody](../../Models/Operations/UpdateEmailAddressRequestBody.md) | :heavy_minus_sign:                                                                        | N/A                                                                                       |                                                                                           |

### Response

**[UpdateEmailAddressResponse](../../Models/Operations/UpdateEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 409                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## PrepareVerification

Sends a one-time code to the given email address so that a backend can
verify the user controls it (for example, in a custom, backend-driven
sign-in flow). The code is tracked on its own verification; confirm it
with attempt_verification.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="PrepareEmailAddressVerification" method="post" path="/email_addresses/{email_address_id}/prepare_verification" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.PrepareVerificationAsync(emailAddressId: "<id>");

// handle response
```

### Parameters

| Parameter                                                    | Type                                                         | Required                                                     | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| `EmailAddressId`                                             | *string*                                                     | :heavy_check_mark:                                           | The ID of the email address to send the verification code to |

### Response

**[PrepareEmailAddressVerificationResponse](../../Models/Operations/PrepareEmailAddressVerificationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## AttemptVerification

Checks a one-time code against the verification identified by
verification_id, and returns the verification with its updated status
(`verified`, `unverified`, `expired`, or `failed`) and attempt count, so a
backend driving its own frontend can react on every attempt — an incorrect
or expired code is reported through the status, not as an error. Resubmitting
a verification whose code was already accepted is rejected with a
`verification_already_verified` error. If the code
is correct and the email address is not already verified, it is also marked
as verified as a side effect (just as it would be in a frontend verification
flow); an already verified email address is left unchanged. It never creates
a session; to sign the user in afterwards, mint a sign-in token.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="AttemptEmailAddressVerification" method="post" path="/email_addresses/{email_address_id}/attempt_verification" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.AttemptVerificationAsync(
    emailAddressId: "<id>",
    requestBody: new AttemptEmailAddressVerificationRequestBody() {
        VerificationId = "<id>",
        Code = "<value>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                           | Type                                                                                                                | Required                                                                                                            | Description                                                                                                         |
| ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| `EmailAddressId`                                                                                                    | *string*                                                                                                            | :heavy_check_mark:                                                                                                  | The ID of the email address whose code is being verified                                                            |
| `RequestBody`                                                                                                       | [AttemptEmailAddressVerificationRequestBody](../../Models/Operations/AttemptEmailAddressVerificationRequestBody.md) | :heavy_check_mark:                                                                                                  | N/A                                                                                                                 |

### Response

**[AttemptEmailAddressVerificationResponse](../../Models/Operations/AttemptEmailAddressVerificationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ReplaceForUser

Replaces all of the user's email addresses with a single primary email address.
By default the new email address is created verified, with the admin verification strategy.
When `identification_status` is `reserved` it is created reserved instead: unverified but usable
for sign-in and locked so no other user can claim it. Any existing email addresses are deleted.
If an existing email address is linked to a connected account, the request is rejected; remove
the connected account first.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ReplaceUserEmailAddress" method="put" path="/users/{user_id}/email_address" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.ReplaceForUserAsync(
    userId: "<id>",
    requestBody: new ReplaceUserEmailAddressRequestBody() {
        EmailAddress = "Ines83@gmail.com",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                           | Type                                                                                                | Required                                                                                            | Description                                                                                         |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `UserId`                                                                                            | *string*                                                                                            | :heavy_check_mark:                                                                                  | The ID of the user whose email address to replace                                                   |
| `RequestBody`                                                                                       | [ReplaceUserEmailAddressRequestBody](../../Models/Operations/ReplaceUserEmailAddressRequestBody.md) | :heavy_check_mark:                                                                                  | N/A                                                                                                 |

### Response

**[ReplaceUserEmailAddressResponse](../../Models/Operations/ReplaceUserEmailAddressResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |