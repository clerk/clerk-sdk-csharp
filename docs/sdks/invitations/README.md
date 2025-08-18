# Invitations
(*Invitations*)

## Overview

### Available Operations

* [Create](#create) - Create an invitation
* [List](#list) - List all invitations
* [BulkCreate](#bulkcreate) - Create multiple invitations
* [Revoke](#revoke) - Revokes an invitation

## Create

Creates a new invitation for the given email address and sends the invitation email.
Keep in mind that you cannot create an invitation if there is already one for the given email address.
Also, trying to create an invitation for an email address that already exists in your application will result to an error.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateInvitation" method="post" path="/invitations" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateInvitationRequestBody req = new CreateInvitationRequestBody() {
    EmailAddress = "user@example.com",
    PublicMetadata = new Dictionary<string, object>() {

    },
    RedirectUrl = "https://example.com/welcome",
};

var res = await sdk.Invitations.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [CreateInvitationRequestBody](../../Models/Operations/CreateInvitationRequestBody.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[CreateInvitationResponse](../../Models/Operations/CreateInvitationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## List

Returns all non-revoked invitations for your application, sorted by creation date

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListInvitations" method="get" path="/invitations" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListInvitationsRequest req = new ListInvitationsRequest() {
    OrderBy = "pending",
    Limit = 20,
    Offset = 10,
};

var res = await sdk.Invitations.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `request`                                                                   | [ListInvitationsRequest](../../Models/Operations/ListInvitationsRequest.md) | :heavy_check_mark:                                                          | The request object to use for the request.                                  |

### Response

**[ListInvitationsResponse](../../Models/Operations/ListInvitationsResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |

## BulkCreate

Use this API operation to create multiple invitations for the provided email addresses. You can choose to send the
invitations as emails by setting the `notify` parameter to `true`. There cannot be an existing invitation for any
of the email addresses you provide unless you set `ignore_existing` to `true` for specific email addresses. Please
note that there must be no existing user for any of the email addresses you provide, and this rule cannot be bypassed.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateBulkInvitations" method="post" path="/invitations/bulk" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

List<RequestBody>? req = null;

var res = await sdk.Invitations.BulkCreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `request`                                                   | List<[RequestBody](../../Models/Operations/RequestBody.md)> | :heavy_check_mark:                                          | The request object to use for the request.                  |

### Response

**[CreateBulkInvitationsResponse](../../Models/Operations/CreateBulkInvitationsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Revoke

Revokes the given invitation.
Revoking an invitation will prevent the user from using the invitation link that was sent to them.
However, it doesn't prevent the user from signing up if they follow the sign up flow.
Only active (i.e. non-revoked) invitations can be revoked.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RevokeInvitation" method="post" path="/invitations/{invitation_id}/revoke" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Invitations.RevokeAsync(invitationId: "inv_123");

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            | Example                                |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `InvitationId`                         | *string*                               | :heavy_check_mark:                     | The ID of the invitation to be revoked | inv_123                                |

### Response

**[RevokeInvitationResponse](../../Models/Operations/RevokeInvitationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |