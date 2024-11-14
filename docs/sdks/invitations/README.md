# Invitations
(*Invitations*)

## Overview

Invitations allow you to invite someone to sign up to your application, via email.
<https://clerk.com/docs/authentication/invitations>

### Available Operations

* [Create](#create) - Create an invitation
* [List](#list) - List all invitations
* [Revoke](#revoke) - Revokes an invitation

## Create

Creates a new invitation for the given email address and sends the invitation email.
Keep in mind that you cannot create an invitation if there is already one for the given email address.
Also, trying to create an invitation for an email address that already exists in your application will result to an error.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateInvitationRequestBody req = new CreateInvitationRequestBody() {
    EmailAddress = "Loyal79@yahoo.com",
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

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Invitations.ListAsync(
    limit: 10D,
    offset: 0D,
    status: Clerk.BackendAPI.Models.Operations.ListInvitationsQueryParamStatus.Expired
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `Limit`                                                                                                                                   | *double*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     |
| `Offset`                                                                                                                                  | *double*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. |
| `Status`                                                                                                                                  | [ListInvitationsQueryParamStatus](../../Models/Operations/ListInvitationsQueryParamStatus.md)                                             | :heavy_minus_sign:                                                                                                                        | Filter invitations based on their status                                                                                                  |

### Response

**[ListInvitationsResponse](../../Models/Operations/ListInvitationsResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |

## Revoke

Revokes the given invitation.
Revoking an invitation will prevent the user from using the invitation link that was sent to them.
However, it doesn't prevent the user from signing up if they follow the sign up flow.
Only active (i.e. non-revoked) invitations can be revoked.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Invitations.RevokeAsync(invitationId: "<id>");

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `InvitationId`                         | *string*                               | :heavy_check_mark:                     | The ID of the invitation to be revoked |

### Response

**[RevokeInvitationResponse](../../Models/Operations/RevokeInvitationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |