# PhoneNumbers

## Overview

### Available Operations

* [Create](#create) - Create a phone number
* [Get](#get) - Retrieve a phone number
* [Delete](#delete) - Delete a phone number
* [Update](#update) - Update a phone number
* [PrepareVerification](#prepareverification) - Send a verification code to a phone number
* [AttemptVerification](#attemptverification) - Verify a code sent to a phone number
* [ReplaceForUser](#replaceforuser) - Replace a user's phone number

## Create

Create a new phone number

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreatePhoneNumber" method="post" path="/phone_numbers" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreatePhoneNumberRequestBody req = new CreatePhoneNumberRequestBody() {
    UserId = "usr_12345",
    PhoneNumber = "+11234567890",
    Verified = true,
    Primary = false,
    ReservedForSecondFactor = false,
};

var res = await sdk.PhoneNumbers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [CreatePhoneNumberRequestBody](../../Models/Operations/CreatePhoneNumberRequestBody.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[CreatePhoneNumberResponse](../../Models/Operations/CreatePhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Returns the details of a phone number

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetPhoneNumber" method="get" path="/phone_numbers/{phone_number_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.GetAsync(phoneNumberId: "phone_12345");

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            | Example                                |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `PhoneNumberId`                        | *string*                               | :heavy_check_mark:                     | The ID of the phone number to retrieve | phone_12345                            |

### Response

**[GetPhoneNumberResponse](../../Models/Operations/GetPhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Delete the phone number with the given ID

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeletePhoneNumber" method="delete" path="/phone_numbers/{phone_number_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.DeleteAsync(phoneNumberId: "phone_12345");

// handle response
```

### Parameters

| Parameter                            | Type                                 | Required                             | Description                          | Example                              |
| ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ |
| `PhoneNumberId`                      | *string*                             | :heavy_check_mark:                   | The ID of the phone number to delete | phone_12345                          |

### Response

**[DeletePhoneNumberResponse](../../Models/Operations/DeletePhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates a phone number

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdatePhoneNumber" method="patch" path="/phone_numbers/{phone_number_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.UpdateAsync(
    phoneNumberId: "phone_12345",
    requestBody: new UpdatePhoneNumberRequestBody() {
        Verified = false,
        Primary = true,
        ReservedForSecondFactor = true,
    }
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `PhoneNumberId`                                                                         | *string*                                                                                | :heavy_check_mark:                                                                      | The ID of the phone number to update                                                    | phone_12345                                                                             |
| `RequestBody`                                                                           | [UpdatePhoneNumberRequestBody](../../Models/Operations/UpdatePhoneNumberRequestBody.md) | :heavy_minus_sign:                                                                      | N/A                                                                                     |                                                                                         |

### Response

**[UpdatePhoneNumberResponse](../../Models/Operations/UpdatePhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## PrepareVerification

Sends a one-time code to the given phone number so that a backend can
verify the user controls it (for example, in a custom, backend-driven
sign-in flow). The code is tracked on its own verification; confirm it
with attempt_verification.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="PreparePhoneNumberVerification" method="post" path="/phone_numbers/{phone_number_id}/prepare_verification" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.PrepareVerificationAsync(phoneNumberId: "<id>");

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `PhoneNumberId`                                             | *string*                                                    | :heavy_check_mark:                                          | The ID of the phone number to send the verification code to |

### Response

**[PreparePhoneNumberVerificationResponse](../../Models/Operations/PreparePhoneNumberVerificationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 429                    | application/json                           |
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
is correct and the phone number is not already verified, it is also marked
as verified as a side effect (just as it would be in a frontend verification
flow); an already verified phone number is left unchanged. It never creates
a session; to sign the user in afterwards, mint a sign-in token.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="AttemptPhoneNumberVerification" method="post" path="/phone_numbers/{phone_number_id}/attempt_verification" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.AttemptVerificationAsync(
    phoneNumberId: "<id>",
    requestBody: new AttemptPhoneNumberVerificationRequestBody() {
        VerificationId = "<id>",
        Code = "<value>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `PhoneNumberId`                                                                                                   | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The ID of the phone number whose code is being verified                                                           |
| `RequestBody`                                                                                                     | [AttemptPhoneNumberVerificationRequestBody](../../Models/Operations/AttemptPhoneNumberVerificationRequestBody.md) | :heavy_check_mark:                                                                                                | N/A                                                                                                               |

### Response

**[AttemptPhoneNumberVerificationResponse](../../Models/Operations/AttemptPhoneNumberVerificationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ReplaceForUser

Replaces all of the user's phone numbers with a single primary phone number.
By default the new phone number is created verified, with the admin verification strategy.
When `identification_status` is `reserved` it is created reserved instead: unverified but usable
for sign-in and locked so no other user can claim it. The new phone number is never reserved for
second factor. Any existing phone numbers are deleted; replacing a phone number that is reserved
for second factor disables the user's MFA.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ReplaceUserPhoneNumber" method="put" path="/users/{user_id}/phone_number" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PhoneNumbers.ReplaceForUserAsync(
    userId: "<id>",
    requestBody: new ReplaceUserPhoneNumberRequestBody() {
        PhoneNumber = "1-440-484-8878 x689",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `UserId`                                                                                          | *string*                                                                                          | :heavy_check_mark:                                                                                | The ID of the user whose phone number to replace                                                  |
| `RequestBody`                                                                                     | [ReplaceUserPhoneNumberRequestBody](../../Models/Operations/ReplaceUserPhoneNumberRequestBody.md) | :heavy_check_mark:                                                                                | N/A                                                                                               |

### Response

**[ReplaceUserPhoneNumberResponse](../../Models/Operations/ReplaceUserPhoneNumberResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |