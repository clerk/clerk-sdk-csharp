# OrganizationInvitations
(*OrganizationInvitations*)

## Overview

### Available Operations

* [ListForInstance](#listforinstance) - Get a list of organization invitations for the current instance
* [Create](#create) - Create and send an organization invitation
* [List](#list) - Get a list of organization invitations
* [CreateBulk](#createbulk) - Bulk create and send organization invitations
* [~~ListPending~~](#listpending) - Get a list of pending organization invitations :warning: **Deprecated**
* [Get](#get) - Retrieve an organization invitation by ID
* [Revoke](#revoke) - Revoke a pending organization invitation

## ListForInstance

This request returns the list of organization invitations for the instance.
Results can be paginated using the optional `limit` and `offset` query parameters.
You can filter them by providing the 'status' query parameter, that accepts multiple values.
You can change the order by providing the 'order' query parameter, that accepts multiple values.
You can filter by the invited user email address providing the `query` query parameter.
The organization invitations are ordered by descending creation date by default.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListInstanceOrganizationInvitationsRequest req = new ListInstanceOrganizationInvitationsRequest() {};

var res = await sdk.OrganizationInvitations.ListForInstanceAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                           | Type                                                                                                                | Required                                                                                                            | Description                                                                                                         |
| ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                           | [ListInstanceOrganizationInvitationsRequest](../../Models/Operations/ListInstanceOrganizationInvitationsRequest.md) | :heavy_check_mark:                                                                                                  | The request object to use for the request.                                                                          |

### Response

**[ListInstanceOrganizationInvitationsResponse](../../Models/Operations/ListInstanceOrganizationInvitationsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 422, 500                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Create

Creates a new organization invitation and sends an email to the provided `email_address` with a link to accept the invitation and join the organization.
You can specify the `role` for the invited organization member.

New organization invitations get a "pending" status until they are revoked by an organization administrator or accepted by the invitee.

The request body supports passing an optional `redirect_url` parameter.
When the invited user clicks the link to accept the invitation, they will be redirected to the URL provided.
Use this parameter to implement a custom invitation acceptance flow.

You can specify the ID of the user that will send the invitation with the `inviter_user_id` parameter.
That user must be a member with administrator privileges in the organization.
Only "admin" members can create organization invitations.

You can optionally provide public and private metadata for the organization invitation.
The public metadata are visible by both the Frontend and the Backend whereas the private ones only by the Backend.
When the organization invitation is accepted, the metadata will be transferred to the newly created organization membership.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationInvitations.CreateAsync(
    organizationId: "<id>",
    requestBody: new CreateOrganizationInvitationRequestBody() {
        EmailAddress = "Loyal79@yahoo.com",
        Role = "<value>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                              | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The ID of the organization for which to send the invitation                                                   |
| `RequestBody`                                                                                                 | [CreateOrganizationInvitationRequestBody](../../Models/Operations/CreateOrganizationInvitationRequestBody.md) | :heavy_check_mark:                                                                                            | N/A                                                                                                           |

### Response

**[CreateOrganizationInvitationResponse](../../Models/Operations/CreateOrganizationInvitationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## List

This request returns the list of organization invitations.
Results can be paginated using the optional `limit` and `offset` query parameters.
You can filter them by providing the 'status' query parameter, that accepts multiple values.
The organization invitations are ordered by descending creation date.
Most recent invitations will be returned first.
Any invitations created as a result of an Organization Domain are not included in the results.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationInvitations.ListAsync(
    organizationId: "<id>",
    limit: 10D,
    offset: 0D,
    status: Clerk.BackendAPI.Models.Operations.ListOrganizationInvitationsQueryParamStatus.Revoked
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                                                          | *string*                                                                                                                                  | :heavy_check_mark:                                                                                                                        | The organization ID.                                                                                                                      |
| `Limit`                                                                                                                                   | *double*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     |
| `Offset`                                                                                                                                  | *double*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. |
| `Status`                                                                                                                                  | [ListOrganizationInvitationsQueryParamStatus](../../Models/Operations/ListOrganizationInvitationsQueryParamStatus.md)                     | :heavy_minus_sign:                                                                                                                        | Filter organization invitations based on their status                                                                                     |

### Response

**[ListOrganizationInvitationsResponse](../../Models/Operations/ListOrganizationInvitationsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreateBulk

Creates new organization invitations in bulk and sends out emails to the provided email addresses with a link to accept the invitation and join the organization.
You can specify a different `role` for each invited organization member.
New organization invitations get a "pending" status until they are revoked by an organization administrator or accepted by the invitee.
The request body supports passing an optional `redirect_url` parameter for each invitation.
When the invited user clicks the link to accept the invitation, they will be redirected to the provided URL.
Use this parameter to implement a custom invitation acceptance flow.
You can specify the ID of the user that will send the invitation with the `inviter_user_id` parameter. Each invitation
can have a different inviter user.
Inviter users must be members with administrator privileges in the organization.
Only "admin" members can create organization invitations.
You can optionally provide public and private metadata for each organization invitation. The public metadata are visible
by both the Frontend and the Backend, whereas the private metadata are only visible by the Backend.
When the organization invitation is accepted, the metadata will be transferred to the newly created organization membership.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using System.Collections.Generic;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationInvitations.CreateBulkAsync(
    organizationId: "<id>",
    requestBody: new List<RequestBody>() {
        new RequestBody() {
            EmailAddress = "Suzanne.Mills71@yahoo.com",
            Role = "<value>",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `OrganizationId`                                            | *string*                                                    | :heavy_check_mark:                                          | The organization ID.                                        |
| `RequestBody`                                               | List<[RequestBody](../../Models/Operations/RequestBody.md)> | :heavy_check_mark:                                          | N/A                                                         |

### Response

**[CreateOrganizationInvitationBulkResponse](../../Models/Operations/CreateOrganizationInvitationBulkResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ~~ListPending~~

This request returns the list of organization invitations with "pending" status.
These are the organization invitations that can still be used to join the organization, but have not been accepted by the invited user yet.
Results can be paginated using the optional `limit` and `offset` query parameters.
The organization invitations are ordered by descending creation date.
Most recent invitations will be returned first.
Any invitations created as a result of an Organization Domain are not included in the results.

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationInvitations.ListPendingAsync(
    organizationId: "<id>",
    limit: 10D,
    offset: 0D
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                                                          | *string*                                                                                                                                  | :heavy_check_mark:                                                                                                                        | The organization ID.                                                                                                                      |
| `Limit`                                                                                                                                   | *double*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     |
| `Offset`                                                                                                                                  | *double*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. |

### Response

**[ListPendingOrganizationInvitationsResponse](../../Models/Operations/ListPendingOrganizationInvitationsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Use this request to get an existing organization invitation by ID.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationInvitations.GetAsync(
    organizationId: "<id>",
    invitationId: "<id>"
);

// handle response
```

### Parameters

| Parameter                       | Type                            | Required                        | Description                     |
| ------------------------------- | ------------------------------- | ------------------------------- | ------------------------------- |
| `OrganizationId`                | *string*                        | :heavy_check_mark:              | The organization ID.            |
| `InvitationId`                  | *string*                        | :heavy_check_mark:              | The organization invitation ID. |

### Response

**[GetOrganizationInvitationResponse](../../Models/Operations/GetOrganizationInvitationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Revoke

Use this request to revoke a previously issued organization invitation.
Revoking an organization invitation makes it invalid; the invited user will no longer be able to join the organization with the revoked invitation.
Only organization invitations with "pending" status can be revoked.
The request accepts the `requesting_user_id` parameter to specify the user which revokes the invitation.
Only users with "admin" role can revoke invitations.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.OrganizationInvitations.RevokeAsync(
    organizationId: "<id>",
    invitationId: "<id>",
    requestBody: new RevokeOrganizationInvitationRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `OrganizationId`                                                                                              | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The organization ID.                                                                                          |
| `InvitationId`                                                                                                | *string*                                                                                                      | :heavy_check_mark:                                                                                            | The organization invitation ID.                                                                               |
| `RequestBody`                                                                                                 | [RevokeOrganizationInvitationRequestBody](../../Models/Operations/RevokeOrganizationInvitationRequestBody.md) | :heavy_minus_sign:                                                                                            | N/A                                                                                                           |

### Response

**[RevokeOrganizationInvitationResponse](../../Models/Operations/RevokeOrganizationInvitationResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 403, 404                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |