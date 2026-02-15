# Users

## Overview

### Available Operations

* [List](#list) - List all users
* [Create](#create) - Create a new user
* [Count](#count) - Count users
* [Get](#get) - Retrieve a user
* [Update](#update) - Update a user
* [Delete](#delete) - Delete a user
* [Ban](#ban) - Ban a user
* [Unban](#unban) - Unban a user
* [BulkBan](#bulkban) - Ban multiple users
* [BulkUnban](#bulkunban) - Unban multiple users
* [Lock](#lock) - Lock a user
* [Unlock](#unlock) - Unlock a user
* [SetProfileImage](#setprofileimage) - Set user profile image
* [DeleteProfileImage](#deleteprofileimage) - Delete user profile image
* [UpdateMetadata](#updatemetadata) - Merge and update a user's metadata
* [GetBillingSubscription](#getbillingsubscription) - Retrieve a user's billing subscription
* [GetOAuthAccessToken](#getoauthaccesstoken) - Retrieve the OAuth access token of a user
* [GetOrganizationMemberships](#getorganizationmemberships) - Retrieve all memberships for a user
* [GetOrganizationInvitations](#getorganizationinvitations) - Retrieve all invitations for a user
* [VerifyPassword](#verifypassword) - Verify the password of a user
* [VerifyTotp](#verifytotp) - Verify a TOTP or backup code for a user
* [DisableMfa](#disablemfa) - Disable a user's MFA methods
* [DeleteBackupCodes](#deletebackupcodes) - Disable all user's Backup codes
* [DeletePasskey](#deletepasskey) - Delete a user passkey
* [DeleteWeb3Wallet](#deleteweb3wallet) - Delete a user web3 wallet
* [DeleteTOTP](#deletetotp) - Delete all the user's TOTPs
* [DeleteExternalAccount](#deleteexternalaccount) - Delete External Account
* [SetPasswordCompromised](#setpasswordcompromised) - Set a user's password as compromised
* [UnsetPasswordCompromised](#unsetpasswordcompromised) - Unset a user's password as compromised
* [GetInstanceOrganizationMemberships](#getinstanceorganizationmemberships) - Get a list of all organization memberships within an instance.

## List

Returns a list of all users.
The users are returned sorted by creation date, with the newest users appearing first.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetUserList" method="get" path="/users" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetUserListRequest req = new GetUserListRequest() {
    EmailAddress = new List<string>() {
        "test@example.com",
    },
    PhoneNumber = new List<string>() {
        "+12345678901",
    },
    ExternalId = new List<string>() {
        "external-id-123",
    },
    Username = new List<string>() {
        "user123",
    },
    Web3Wallet = new List<string>() {
        "0x123456789abcdef0x123456789abcdef",
    },
    UserId = new List<string>() {
        "user-id-123",
    },
    OrganizationId = new List<string>() {
        "org-id-123",
    },
    Query = "John",
    LastActiveAtBefore = 1700690400000,
    LastActiveAtAfter = 1700690400000,
    LastActiveAtSince = 1700690400000,
    CreatedAtBefore = 1730160000000,
    CreatedAtAfter = 1730160000000,
    LastSignInAtBefore = 1700690400000,
    LastSignInAtAfter = 1700690400000,
    Limit = 20,
    Offset = 10,
};

var res = await sdk.Users.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [GetUserListRequest](../../Models/Operations/GetUserListRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[GetUserListResponse](../../Models/Operations/GetUserListResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Creates a new user. Your user management settings determine how you should setup your user model.

Any email address and phone number created using this method will be marked as verified.

Note: If you are performing a migration, check out our guide on [zero downtime migrations](https://clerk.com/docs/deployments/migrate-overview).

The following rate limit rules apply to this endpoint: 1000 requests per 10 seconds for production instances and 100 requests per 10 seconds for development instances

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateUser" method="post" path="/users" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateUserRequestBody req = new CreateUserRequestBody() {
    ExternalId = "ext-id-001",
    FirstName = "John",
    LastName = "Doe",
    EmailAddress = new List<string>() {
        "john.doe@example.com",
    },
    PhoneNumber = new List<string>() {
        "+12345678901",
    },
    Web3Wallet = new List<string>() {
        "0x123456789abcdef0x123456789abcdef",
    },
    Username = "johndoe123",
    Password = "Secure*Pass4",
    PasswordDigest = "$argon2i$v=19$m=4096,t=3,p=1$4t6CL3P7YiHBtwESXawI8Hm20zJj4cs7/4/G3c187e0$m7RQFczcKr5bIR0IIxbpO2P0tyrLjf3eUW3M3QSwnLc",
    SkipPasswordChecks = false,
    SkipPasswordRequirement = false,
    TotpSecret = "base32totpsecretkey",
    BackupCodes = new List<string>() {
        "123456",
        "654321",
    },
    PublicMetadata = new Dictionary<string, object>() {
        { "role", "user" },
    },
    PrivateMetadata = new Dictionary<string, object>() {
        { "internal_id", "789" },
    },
    UnsafeMetadata = new Dictionary<string, object>() {
        { "preferences", new Dictionary<string, object>() {
            { "theme", "dark" },
        } },
    },
    CreatedAt = "2023-03-15T07:15:20.902Z",
};

var res = await sdk.Users.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [CreateUserRequestBody](../../Models/Operations/CreateUserRequestBody.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[CreateUserResponse](../../Models/Operations/CreateUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Count

Returns a total count of all users that match the given filtering criteria.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetUsersCount" method="get" path="/users/count" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetUsersCountRequest req = new GetUsersCountRequest() {
    EmailAddress = new List<string>() {
        "user@example.com",
    },
    PhoneNumber = new List<string>() {
        "+1234567890",
    },
    ExternalId = new List<string>() {
        "external-id-123",
    },
    Username = new List<string>() {
        "username123",
    },
    Web3Wallet = new List<string>() {
        "0x123456789abcdef",
    },
    UserId = new List<string>() {
        "user-id-123",
    },
    OrganizationId = new List<string>() {
        "John Doe",
    },
    LastActiveAtBefore = 1700690400000,
    LastActiveAtAfter = 1700690400000,
    LastActiveAtSince = 1700690400000,
    CreatedAtBefore = 1730160000000,
    CreatedAtAfter = 1730160000000,
    LastSignInAtBefore = 1700690400000,
    LastSignInAtAfter = 1700690400000,
};

var res = await sdk.Users.CountAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [GetUsersCountRequest](../../Models/Operations/GetUsersCountRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[GetUsersCountResponse](../../Models/Operations/GetUsersCountResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 422                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Retrieve the details of a user

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetUser" method="get" path="/users/{user_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.GetAsync(userId: "usr_1");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `UserId`                       | *string*                       | :heavy_check_mark:             | The ID of the user to retrieve | usr_1                          |

### Response

**[GetUserResponse](../../Models/Operations/GetUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Update a user's attributes.

You can set the user's primary contact identifiers (email address and phone numbers) by updating the `primary_email_address_id` and `primary_phone_number_id` attributes respectively.
Both IDs should correspond to verified identifications that belong to the user.

You can remove a user's username by setting the username attribute to null or the blank string "".
This is a destructive action; the identification will be deleted forever.
Usernames can be removed only if they are optional in your instance settings and there's at least one other identifier which can be used for authentication.

This endpoint allows changing a user's password. When passing the `password` parameter directly you have two further options.
You can ignore the password policy checks for your instance by setting the `skip_password_checks` parameter to `true`.
You can also choose to sign the user out of all their active sessions on any device once the password is updated. Just set `sign_out_of_other_sessions` to `true`.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateUser" method="patch" path="/users/{user_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.UpdateAsync(
    userId: "usr_1",
    requestBody: new UpdateUserRequestBody() {
        ExternalId = "ext_123",
        FirstName = "Jane",
        LastName = "Doe",
        PrimaryEmailAddressId = "eml_12345",
        NotifyPrimaryEmailAddressChanged = true,
        PrimaryPhoneNumberId = "phn_67890",
        PrimaryWeb3WalletId = "wlt_123",
        Username = "janedoe",
        ProfileImageId = "img_789",
        Password = "secretPass123!",
        PasswordDigest = "$argon2i$v=19$m=4096,t=3,p=1$4t6CL3P7YiHBtwESXawI8Hm20zJj4cs7/4/G3c187e0$m7RQFczcKr5bIR0IIxbpO2P0tyrLjf3eUW3M3QSwnLc",
        SkipPasswordChecks = false,
        SignOutOfOtherSessions = true,
        TotpSecret = "ABCD1234EFGH5678",
        BackupCodes = new List<string>() {
            "123456",
            "654321",
        },
        PublicMetadata = new Dictionary<string, object>() {
            { "theme", "dark" },
        },
        PrivateMetadata = new Dictionary<string, object>() {
            { "vip", true },
        },
        UnsafeMetadata = new Dictionary<string, object>() {
            { "age", 30 },
        },
        DeleteSelfEnabled = true,
        CreateOrganizationEnabled = false,
        CreatedAt = "2021-04-05T14:30:00.000Z",
    }
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `UserId`                                                                  | *string*                                                                  | :heavy_check_mark:                                                        | The ID of the user to update                                              | usr_1                                                                     |
| `RequestBody`                                                             | [UpdateUserRequestBody](../../Models/Operations/UpdateUserRequestBody.md) | :heavy_check_mark:                                                        | N/A                                                                       |                                                                           |

### Response

**[UpdateUserResponse](../../Models/Operations/UpdateUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Delete the specified user

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteUser" method="delete" path="/users/{user_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.DeleteAsync(userId: "usr_1");

// handle response
```

### Parameters

| Parameter                    | Type                         | Required                     | Description                  | Example                      |
| ---------------------------- | ---------------------------- | ---------------------------- | ---------------------------- | ---------------------------- |
| `UserId`                     | *string*                     | :heavy_check_mark:           | The ID of the user to delete | usr_1                        |

### Response

**[DeleteUserResponse](../../Models/Operations/DeleteUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Ban

Marks the given user as banned, which means that all their sessions are revoked and they are not allowed to sign in again.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="BanUser" method="post" path="/users/{user_id}/ban" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.BanAsync(userId: "user_12345");

// handle response
```

### Parameters

| Parameter                 | Type                      | Required                  | Description               | Example                   |
| ------------------------- | ------------------------- | ------------------------- | ------------------------- | ------------------------- |
| `UserId`                  | *string*                  | :heavy_check_mark:        | The ID of the user to ban | user_12345                |

### Response

**[BanUserResponse](../../Models/Operations/BanUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Unban

Removes the ban mark from the given user.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UnbanUser" method="post" path="/users/{user_id}/unban" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.UnbanAsync(userId: "user_12345");

// handle response
```

### Parameters

| Parameter                   | Type                        | Required                    | Description                 | Example                     |
| --------------------------- | --------------------------- | --------------------------- | --------------------------- | --------------------------- |
| `UserId`                    | *string*                    | :heavy_check_mark:          | The ID of the user to unban | user_12345                  |

### Response

**[UnbanUserResponse](../../Models/Operations/UnbanUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## BulkBan

Marks multiple users as banned, which means that all their sessions are revoked and they are not allowed to sign in again.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UsersBan" method="post" path="/users/ban" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

UsersBanRequestBody req = new UsersBanRequestBody() {
    UserIds = new List<string>() {
        "<value 1>",
        "<value 2>",
        "<value 3>",
    },
};

var res = await sdk.Users.BulkBanAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [UsersBanRequestBody](../../Models/Operations/UsersBanRequestBody.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[UsersBanResponse](../../Models/Operations/UsersBanResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 402                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## BulkUnban

Removes the ban mark from multiple users.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UsersUnban" method="post" path="/users/unban" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

UsersUnbanRequestBody req = new UsersUnbanRequestBody() {
    UserIds = new List<string>() {
        "<value 1>",
        "<value 2>",
        "<value 3>",
    },
};

var res = await sdk.Users.BulkUnbanAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [UsersUnbanRequestBody](../../Models/Operations/UsersUnbanRequestBody.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[UsersUnbanResponse](../../Models/Operations/UsersUnbanResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 402                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Lock

Marks the given user as locked, which means they are not allowed to sign in again until the lock expires.
Lock duration can be configured in the instance's restrictions settings.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="LockUser" method="post" path="/users/{user_id}/lock" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.LockAsync(userId: "user_123456789");

// handle response
```

### Parameters

| Parameter                  | Type                       | Required                   | Description                | Example                    |
| -------------------------- | -------------------------- | -------------------------- | -------------------------- | -------------------------- |
| `UserId`                   | *string*                   | :heavy_check_mark:         | The ID of the user to lock | user_123456789             |

### Response

**[LockUserResponse](../../Models/Operations/LockUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Unlock

Removes the lock from the given user.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UnlockUser" method="post" path="/users/{user_id}/unlock" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.UnlockAsync(userId: "user_12345");

// handle response
```

### Parameters

| Parameter                    | Type                         | Required                     | Description                  | Example                      |
| ---------------------------- | ---------------------------- | ---------------------------- | ---------------------------- | ---------------------------- |
| `UserId`                     | *string*                     | :heavy_check_mark:           | The ID of the user to unlock | user_12345                   |

### Response

**[UnlockUserResponse](../../Models/Operations/UnlockUserResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## SetProfileImage

Update a user's profile image

### Example Usage

<!-- UsageSnippet language="csharp" operationID="SetUserProfileImage" method="post" path="/users/{user_id}/profile_image" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.SetProfileImageAsync(
    userId: "usr_test123",
    requestBody: new SetUserProfileImageRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 | Example                                                                                     |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `UserId`                                                                                    | *string*                                                                                    | :heavy_check_mark:                                                                          | The ID of the user to update the profile image for                                          | usr_test123                                                                                 |
| `RequestBody`                                                                               | [SetUserProfileImageRequestBody](../../Models/Operations/SetUserProfileImageRequestBody.md) | :heavy_check_mark:                                                                          | N/A                                                                                         |                                                                                             |

### Response

**[SetUserProfileImageResponse](../../Models/Operations/SetUserProfileImageResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteProfileImage

Delete a user's profile image

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteUserProfileImage" method="delete" path="/users/{user_id}/profile_image" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.DeleteProfileImageAsync(userId: "usr_test123");

// handle response
```

### Parameters

| Parameter                                          | Type                                               | Required                                           | Description                                        | Example                                            |
| -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- |
| `UserId`                                           | *string*                                           | :heavy_check_mark:                                 | The ID of the user to delete the profile image for | usr_test123                                        |

### Response

**[DeleteUserProfileImageResponse](../../Models/Operations/DeleteUserProfileImageResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## UpdateMetadata

Update a user's metadata attributes by merging existing values with the provided parameters.

This endpoint behaves differently than the *Update a user* endpoint.
Metadata values will not be replaced entirely.
Instead, a deep merge will be performed.
Deep means that any nested JSON objects will be merged as well.

You can remove metadata keys at any level by setting their value to `null`.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateUserMetadata" method="patch" path="/users/{user_id}/metadata" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.UpdateMetadataAsync(userId: "user_123456789");

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               | Example                                                                                   |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `UserId`                                                                                  | *string*                                                                                  | :heavy_check_mark:                                                                        | The ID of the user whose metadata will be updated and merged                              | user_123456789                                                                            |
| `RequestBody`                                                                             | [UpdateUserMetadataRequestBody](../../Models/Operations/UpdateUserMetadataRequestBody.md) | :heavy_minus_sign:                                                                        | N/A                                                                                       |                                                                                           |

### Response

**[UpdateUserMetadataResponse](../../Models/Operations/UpdateUserMetadataResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetBillingSubscription

Retrieves the billing subscription for the specified user.
This includes subscription details, active plans, billing information, and payment status.
The subscription contains subscription items which represent the individual plans the user is subscribed to.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetUserBillingSubscription" method="get" path="/users/{user_id}/billing/subscription" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.GetBillingSubscriptionAsync(userId: "<id>");

// handle response
```

### Parameters

| Parameter                                         | Type                                              | Required                                          | Description                                       |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| `UserId`                                          | *string*                                          | :heavy_check_mark:                                | The ID of the user whose subscription to retrieve |

### Response

**[GetUserBillingSubscriptionResponse](../../Models/Operations/GetUserBillingSubscriptionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetOAuthAccessToken

Fetch the corresponding OAuth access token for a user that has previously authenticated with a particular OAuth provider.
For OAuth 2.0, if the access token has expired and we have a corresponding refresh token, the access token will be refreshed transparently the new one will be returned.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetOAuthAccessToken" method="get" path="/users/{user_id}/oauth_access_tokens/{provider}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetOAuthAccessTokenRequest req = new GetOAuthAccessTokenRequest() {
    UserId = "user_123",
    Provider = "oauth_google",
    Limit = 20,
    Offset = 10,
};

var res = await sdk.Users.GetOAuthAccessTokenAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [GetOAuthAccessTokenRequest](../../Models/Operations/GetOAuthAccessTokenRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[GetOAuthAccessTokenResponse](../../Models/Operations/GetOAuthAccessTokenResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetOrganizationMemberships

Retrieve a paginated list of the user's organization memberships

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UsersGetOrganizationMemberships" method="get" path="/users/{user_id}/organization_memberships" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.GetOrganizationMembershipsAsync(
    userId: "usr_1234567890",
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               | Example                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `UserId`                                                                                                                                  | *string*                                                                                                                                  | :heavy_check_mark:                                                                                                                        | The ID of the user whose organization memberships we want to retrieve                                                                     | usr_1234567890                                                                                                                            |
| `Limit`                                                                                                                                   | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     | 20                                                                                                                                        |
| `Offset`                                                                                                                                  | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. | 10                                                                                                                                        |

### Response

**[UsersGetOrganizationMembershipsResponse](../../Models/Operations/UsersGetOrganizationMembershipsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetOrganizationInvitations

Retrieve a paginated list of the user's organization invitations

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UsersGetOrganizationInvitations" method="get" path="/users/{user_id}/organization_invitations" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.GetOrganizationInvitationsAsync(
    userId: "<id>",
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               | Example                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `UserId`                                                                                                                                  | *string*                                                                                                                                  | :heavy_check_mark:                                                                                                                        | The ID of the user whose organization invitations we want to retrieve                                                                     |                                                                                                                                           |
| `Limit`                                                                                                                                   | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     | 20                                                                                                                                        |
| `Offset`                                                                                                                                  | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. | 10                                                                                                                                        |
| `Status`                                                                                                                                  | [QueryParamStatus](../../Models/Operations/QueryParamStatus.md)                                                                           | :heavy_minus_sign:                                                                                                                        | Filter organization invitations based on their status                                                                                     |                                                                                                                                           |

### Response

**[UsersGetOrganizationInvitationsResponse](../../Models/Operations/UsersGetOrganizationInvitationsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## VerifyPassword

Check that the user's password matches the supplied input.
Useful for custom auth flows and re-verification.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="VerifyPassword" method="post" path="/users/{user_id}/verify_password" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.VerifyPasswordAsync(
    userId: "user_123",
    requestBody: new VerifyPasswordRequestBody() {
        Password = "securepassword123",
    }
);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       | Example                                                                           |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `UserId`                                                                          | *string*                                                                          | :heavy_check_mark:                                                                | The ID of the user for whom to verify the password                                | user_123                                                                          |
| `RequestBody`                                                                     | [VerifyPasswordRequestBody](../../Models/Operations/VerifyPasswordRequestBody.md) | :heavy_minus_sign:                                                                | N/A                                                                               |                                                                                   |

### Response

**[VerifyPasswordResponse](../../Models/Operations/VerifyPasswordResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## VerifyTotp

Verify that the provided TOTP or backup code is valid for the user.
Verifying a backup code will result it in being consumed (i.e. it will
become invalid).
Useful for custom auth flows and re-verification.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="VerifyTOTP" method="post" path="/users/{user_id}/verify_totp" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.VerifyTotpAsync(
    userId: "usr_1a2b3c",
    requestBody: new VerifyTOTPRequestBody() {
        Code = "123456",
    }
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `UserId`                                                                  | *string*                                                                  | :heavy_check_mark:                                                        | The ID of the user for whom to verify the TOTP                            | usr_1a2b3c                                                                |
| `RequestBody`                                                             | [VerifyTOTPRequestBody](../../Models/Operations/VerifyTOTPRequestBody.md) | :heavy_minus_sign:                                                        | N/A                                                                       |                                                                           |

### Response

**[VerifyTOTPResponse](../../Models/Operations/VerifyTOTPResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DisableMfa

Disable all of a user's MFA methods (e.g. OTP sent via SMS, TOTP on their authenticator app) at once.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DisableMFA" method="delete" path="/users/{user_id}/mfa" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.DisableMfaAsync(userId: "user_123456");

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `UserId`                                                | *string*                                                | :heavy_check_mark:                                      | The ID of the user whose MFA methods are to be disabled | user_123456                                             |

### Response

**[DisableMFAResponse](../../Models/Operations/DisableMFAResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteBackupCodes

Disable all of a user's backup codes.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteBackupCode" method="delete" path="/users/{user_id}/backup_code" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.DeleteBackupCodesAsync(userId: "<id>");

// handle response
```

### Parameters

| Parameter                                                | Type                                                     | Required                                                 | Description                                              |
| -------------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------------------- |
| `UserId`                                                 | *string*                                                 | :heavy_check_mark:                                       | The ID of the user whose backup codes are to be deleted. |

### Response

**[DeleteBackupCodeResponse](../../Models/Operations/DeleteBackupCodeResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeletePasskey

Delete the passkey identification for a given user and notify them through email.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UserPasskeyDelete" method="delete" path="/users/{user_id}/passkeys/{passkey_identification_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.DeletePasskeyAsync(
    userId: "<id>",
    passkeyIdentificationId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                         | Type                                              | Required                                          | Description                                       |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| `UserId`                                          | *string*                                          | :heavy_check_mark:                                | The ID of the user that owns the passkey identity |
| `PasskeyIdentificationId`                         | *string*                                          | :heavy_check_mark:                                | The ID of the passkey identity to be deleted      |

### Response

**[UserPasskeyDeleteResponse](../../Models/Operations/UserPasskeyDeleteResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteWeb3Wallet

Delete the web3 wallet identification for a given user.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UserWeb3WalletDelete" method="delete" path="/users/{user_id}/web3_wallets/{web3_wallet_identification_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.DeleteWeb3WalletAsync(
    userId: "<id>",
    web3WalletIdentificationId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                        | Type                                             | Required                                         | Description                                      |
| ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ |
| `UserId`                                         | *string*                                         | :heavy_check_mark:                               | The ID of the user that owns the web3 wallet     |
| `Web3WalletIdentificationId`                     | *string*                                         | :heavy_check_mark:                               | The ID of the web3 wallet identity to be deleted |

### Response

**[UserWeb3WalletDeleteResponse](../../Models/Operations/UserWeb3WalletDeleteResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteTOTP

Deletes all of the user's TOTPs.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteTOTP" method="delete" path="/users/{user_id}/totp" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.DeleteTOTPAsync(userId: "<id>");

// handle response
```

### Parameters

| Parameter                                        | Type                                             | Required                                         | Description                                      |
| ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ |
| `UserId`                                         | *string*                                         | :heavy_check_mark:                               | The ID of the user whose TOTPs are to be deleted |

### Response

**[DeleteTOTPResponse](../../Models/Operations/DeleteTOTPResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## DeleteExternalAccount

Delete an external account by ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteExternalAccount" method="delete" path="/users/{user_id}/external_accounts/{external_account_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.DeleteExternalAccountAsync(
    userId: "<id>",
    externalAccountId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                | Type                                     | Required                                 | Description                              |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| `UserId`                                 | *string*                                 | :heavy_check_mark:                       | The ID of the user's external account    |
| `ExternalAccountId`                      | *string*                                 | :heavy_check_mark:                       | The ID of the external account to delete |

### Response

**[DeleteExternalAccountResponse](../../Models/Operations/DeleteExternalAccountResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## SetPasswordCompromised

Sets the given user's password as compromised. The user will be prompted to reset their password on their next sign-in.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="SetUserPasswordCompromised" method="post" path="/users/{user_id}/password/set_compromised" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.SetPasswordCompromisedAsync(userId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `UserId`                                                                                                  | *string*                                                                                                  | :heavy_check_mark:                                                                                        | The ID of the user to set the password as compromised                                                     |
| `RequestBody`                                                                                             | [SetUserPasswordCompromisedRequestBody](../../Models/Operations/SetUserPasswordCompromisedRequestBody.md) | :heavy_minus_sign:                                                                                        | N/A                                                                                                       |

### Response

**[SetUserPasswordCompromisedResponse](../../Models/Operations/SetUserPasswordCompromisedResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## UnsetPasswordCompromised

Sets the given user's password as no longer compromised. The user will no longer be prompted to reset their password on their next sign-in.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UnsetUserPasswordCompromised" method="post" path="/users/{user_id}/password/unset_compromised" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.UnsetPasswordCompromisedAsync(userId: "<id>");

// handle response
```

### Parameters

| Parameter                                              | Type                                                   | Required                                               | Description                                            |
| ------------------------------------------------------ | ------------------------------------------------------ | ------------------------------------------------------ | ------------------------------------------------------ |
| `UserId`                                               | *string*                                               | :heavy_check_mark:                                     | The ID of the user to unset the compromised status for |

### Response

**[UnsetUserPasswordCompromisedResponse](../../Models/Operations/UnsetUserPasswordCompromisedResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetInstanceOrganizationMemberships

Retrieves all organization user memberships for the given instance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="InstanceGetOrganizationMemberships" method="get" path="/organization_memberships" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Users.GetInstanceOrganizationMembershipsAsync(
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                          | Type                                                                                                                                                                                                                               | Required                                                                                                                                                                                                                           | Description                                                                                                                                                                                                                        | Example                                                                                                                                                                                                                            |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `OrderBy`                                                                                                                                                                                                                          | *string*                                                                                                                                                                                                                           | :heavy_minus_sign:                                                                                                                                                                                                                 | Sorts organizations memberships by phone_number, email_address, created_at, first_name, last_name or username.<br/>By prepending one of those values with + or -,<br/>we can choose to sort in ascending (ASC) or descending (DESC) order. |                                                                                                                                                                                                                                    |
| `Limit`                                                                                                                                                                                                                            | *long*                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                 | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                                                                                                              | 20                                                                                                                                                                                                                                 |
| `Offset`                                                                                                                                                                                                                           | *long*                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                 | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`.                                                                                  | 10                                                                                                                                                                                                                                 |

### Response

**[InstanceGetOrganizationMembershipsResponse](../../Models/Operations/InstanceGetOrganizationMembershipsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |