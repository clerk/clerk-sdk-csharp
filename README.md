<div align="center">
  <a href="https://clerk.com?utm_source=github&utm_medium=clerk_javascript" target="_blank" rel="noopener noreferrer">
    <picture>
      <source media="(prefers-color-scheme: dark)" srcset="https://images.clerk.com/static/logo-dark-mode-400x400.png">
      <img src="https://images.clerk.com/static/logo-light-mode-400x400.png" height="100">
    </picture>
  </a>
   <p>The most comprehensive User Management Platform</p>
   <a href="https://clerk.com/docs/reference/backend-api"><img src="https://img.shields.io/static/v1?label=Docs&message=API Ref&color=000000&style=for-the-badge" /></a>
  <a href="https://opensource.org/licenses/MIT"><img src="https://img.shields.io/badge/License-MIT-blue.svg?style=for-the-badge" /></a>
</div>
<br /><br />

<!-- Start Summary [summary] -->
## Summary

Clerk Backend API: The Clerk REST Backend API, meant to be accessed by backend servers.

### Versions

When the API changes in a way that isn't compatible with older versions, a new version is released.
Each version is identified by its release date, e.g. `2024-10-01`. For more information, please see [Clerk API Versions](https://clerk.com/docs/versioning/available-versions).

Please see https://clerk.com/docs for more information.

More information about the API can be found at https://clerk.com/docs
<!-- End Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents
<!-- $toc-max-depth=2 -->
  * [SDK Installation](#sdk-installation)
  * [SDK Example Usage](#sdk-example-usage)
  * [Authentication](#authentication)
  * [Request Authentication](#request-authentication)
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Retries](#retries)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)
* [Development](#development)
  * [Maturity](#maturity)
  * [Contributions](#contributions)

<!-- End Table of Contents [toc] -->

<!-- Start SDK Installation [installation] -->
## SDK Installation

### NuGet

To add the [NuGet](https://www.nuget.org/) package to a .NET project:
```bash
dotnet add package Clerk.BackendAPI
```

### Locally

To add a reference to a local instance of the SDK in a .NET project:
```bash
dotnet add reference src/Clerk/BackendAPI/Clerk.BackendAPI.csproj
```
<!-- End SDK Installation [installation] -->

<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.EmailAddresses.GetAsync(emailAddressId: "email_address_id_example");

// handle response
```
<!-- End SDK Example Usage [usage] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security scheme globally:

| Name         | Type | Scheme      |
| ------------ | ---- | ----------- |
| `BearerAuth` | http | HTTP Bearer |

To authenticate with the API the `BearerAuth` parameter must be set when initializing the SDK client instance. For example:
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(req);

// handle response
```
<!-- End Authentication [security] -->

## Request Authentication

Use the [AuthenticateRequestAsync](https://github.com/clerk/clerk-sdk-csharp/blob/main/src/Clerk/BackendAPI/Helpers/AuthenticateRequest.cs) method to authenticate a request from your app's frontend (when using a Clerk frontend SDK) to Clerk's Backend API. For example the following utility function checks if the user is effectively signed in:

```csharp
using Clerk.BackendAPI.Helpers.Jwks;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class UserAuthentication
{
    public static async Task<bool> IsSignedInAsync(HttpRequestMessage request)
    {
        var options = new AuthenticateRequestOptions(
            secretKey: Environment.GetEnvironmentVariable("CLERK_SECRET_KEY"),
            authorizedParties: new string[] { "https://example.com" }
        );

        var requestState = await AuthenticateRequest.AuthenticateRequestAsync(request, options);

        return requestState.isSignedIn();
    }
}
```

If the request is correctly authenticated, the token's claims are made available in `requestState.Claims`. Otherwise the reason for the token verification failure is given by `requestState.ErrorReason`.


<!-- Start Available Resources and Operations [operations] -->
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

### [ActorTokens](docs/sdks/actortokens/README.md)

* [Create](docs/sdks/actortokens/README.md#create) - Create actor token
* [Revoke](docs/sdks/actortokens/README.md#revoke) - Revoke actor token

### [AllowlistIdentifiers](docs/sdks/allowlistidentifiers/README.md)

* [List](docs/sdks/allowlistidentifiers/README.md#list) - List all identifiers on the allow-list
* [Create](docs/sdks/allowlistidentifiers/README.md#create) - Add identifier to the allow-list
* [Delete](docs/sdks/allowlistidentifiers/README.md#delete) - Delete identifier from allow-list

### [BetaFeatures](docs/sdks/betafeatures/README.md)

* [UpdateInstanceSettings](docs/sdks/betafeatures/README.md#updateinstancesettings) - Update instance settings
* [~~UpdateProductionInstanceDomain~~](docs/sdks/betafeatures/README.md#updateproductioninstancedomain) - Update production instance domain :warning: **Deprecated**

### [BlocklistIdentifiers](docs/sdks/blocklistidentifiers/README.md)

* [List](docs/sdks/blocklistidentifiers/README.md#list) - List all identifiers on the block-list
* [Create](docs/sdks/blocklistidentifiers/README.md#create) - Add identifier to the block-list
* [Delete](docs/sdks/blocklistidentifiers/README.md#delete) - Delete identifier from block-list


### [Clients](docs/sdks/clients/README.md)

* [~~List~~](docs/sdks/clients/README.md#list) - List all clients :warning: **Deprecated**
* [Verify](docs/sdks/clients/README.md#verify) - Verify a client
* [Get](docs/sdks/clients/README.md#get) - Get a client

### [Domains](docs/sdks/domains/README.md)

* [List](docs/sdks/domains/README.md#list) - List all instance domains
* [Add](docs/sdks/domains/README.md#add) - Add a domain
* [Delete](docs/sdks/domains/README.md#delete) - Delete a satellite domain
* [Update](docs/sdks/domains/README.md#update) - Update a domain

### [EmailAddresses](docs/sdks/emailaddresses/README.md)

* [Create](docs/sdks/emailaddresses/README.md#create) - Create an email address
* [Get](docs/sdks/emailaddresses/README.md#get) - Retrieve an email address
* [Delete](docs/sdks/emailaddresses/README.md#delete) - Delete an email address
* [Update](docs/sdks/emailaddresses/README.md#update) - Update an email address

### [~~EmailAndSmsTemplates~~](docs/sdks/emailandsmstemplates/README.md)

* [~~Upsert~~](docs/sdks/emailandsmstemplates/README.md#upsert) - Update a template for a given type and slug :warning: **Deprecated**

### [~~EmailSMSTemplates~~](docs/sdks/emailsmstemplates/README.md)

* [~~List~~](docs/sdks/emailsmstemplates/README.md#list) - List all templates :warning: **Deprecated**
* [~~Get~~](docs/sdks/emailsmstemplates/README.md#get) - Retrieve a template :warning: **Deprecated**
* [~~Revert~~](docs/sdks/emailsmstemplates/README.md#revert) - Revert a template :warning: **Deprecated**
* [~~ToggleTemplateDelivery~~](docs/sdks/emailsmstemplates/README.md#toggletemplatedelivery) - Toggle the delivery by Clerk for a template of a given type and slug :warning: **Deprecated**

### [ExperimentalAccountlessApplications](docs/sdks/experimentalaccountlessapplications/README.md)

* [Create](docs/sdks/experimentalaccountlessapplications/README.md#create) - Create an accountless application [EXPERIMENTAL]
* [Complete](docs/sdks/experimentalaccountlessapplications/README.md#complete) - Complete an accountless application [EXPERIMENTAL]

### [InstanceSettings](docs/sdks/instancesettings/README.md)

* [Get](docs/sdks/instancesettings/README.md#get) - Fetch the current instance
* [Update](docs/sdks/instancesettings/README.md#update) - Update instance settings
* [UpdateRestrictions](docs/sdks/instancesettings/README.md#updaterestrictions) - Update instance restrictions
* [ChangeDomain](docs/sdks/instancesettings/README.md#changedomain) - Update production instance domain
* [UpdateOrganizationSettings](docs/sdks/instancesettings/README.md#updateorganizationsettings) - Update instance organization settings

### [Invitations](docs/sdks/invitations/README.md)

* [Create](docs/sdks/invitations/README.md#create) - Create an invitation
* [List](docs/sdks/invitations/README.md#list) - List all invitations
* [BulkCreate](docs/sdks/invitations/README.md#bulkcreate) - Create multiple invitations
* [Revoke](docs/sdks/invitations/README.md#revoke) - Revokes an invitation

### [Jwks](docs/sdks/jwks/README.md)

* [GetJWKS](docs/sdks/jwks/README.md#getjwks) - Retrieve the JSON Web Key Set of the instance

### [JwtTemplates](docs/sdks/jwttemplates/README.md)

* [List](docs/sdks/jwttemplates/README.md#list) - List all templates
* [Create](docs/sdks/jwttemplates/README.md#create) - Create a JWT template
* [Get](docs/sdks/jwttemplates/README.md#get) - Retrieve a template
* [Update](docs/sdks/jwttemplates/README.md#update) - Update a JWT template
* [Delete](docs/sdks/jwttemplates/README.md#delete) - Delete a Template

### [Miscellaneous](docs/sdks/miscellaneous/README.md)

* [GetPublicInterstitial](docs/sdks/miscellaneous/README.md#getpublicinterstitial) - Returns the markup for the interstitial page

### [OauthApplications](docs/sdks/oauthapplications/README.md)

* [List](docs/sdks/oauthapplications/README.md#list) - Get a list of OAuth applications for an instance
* [Create](docs/sdks/oauthapplications/README.md#create) - Create an OAuth application
* [Get](docs/sdks/oauthapplications/README.md#get) - Retrieve an OAuth application by ID
* [Update](docs/sdks/oauthapplications/README.md#update) - Update an OAuth application
* [Delete](docs/sdks/oauthapplications/README.md#delete) - Delete an OAuth application
* [RotateSecret](docs/sdks/oauthapplications/README.md#rotatesecret) - Rotate the client secret of the given OAuth application

### [OrganizationDomains](docs/sdks/organizationdomains/README.md)

* [Create](docs/sdks/organizationdomains/README.md#create) - Create a new organization domain.
* [List](docs/sdks/organizationdomains/README.md#list) - Get a list of all domains of an organization.
* [Update](docs/sdks/organizationdomains/README.md#update) - Update an organization domain.
* [Delete](docs/sdks/organizationdomains/README.md#delete) - Remove a domain from an organization.

### [OrganizationInvitations](docs/sdks/organizationinvitations/README.md)

* [GetAll](docs/sdks/organizationinvitations/README.md#getall) - Get a list of organization invitations for the current instance
* [Create](docs/sdks/organizationinvitations/README.md#create) - Create and send an organization invitation
* [List](docs/sdks/organizationinvitations/README.md#list) - Get a list of organization invitations
* [BulkCreate](docs/sdks/organizationinvitations/README.md#bulkcreate) - Bulk create and send organization invitations
* [~~ListPending~~](docs/sdks/organizationinvitations/README.md#listpending) - Get a list of pending organization invitations :warning: **Deprecated**
* [Get](docs/sdks/organizationinvitations/README.md#get) - Retrieve an organization invitation by ID
* [Revoke](docs/sdks/organizationinvitations/README.md#revoke) - Revoke a pending organization invitation

### [OrganizationMemberships](docs/sdks/organizationmemberships/README.md)

* [Create](docs/sdks/organizationmemberships/README.md#create) - Create a new organization membership
* [List](docs/sdks/organizationmemberships/README.md#list) - Get a list of all members of an organization
* [Update](docs/sdks/organizationmemberships/README.md#update) - Update an organization membership
* [Delete](docs/sdks/organizationmemberships/README.md#delete) - Remove a member from an organization
* [UpdateMetadata](docs/sdks/organizationmemberships/README.md#updatemetadata) - Merge and update organization membership metadata

### [Organizations](docs/sdks/organizations/README.md)

* [List](docs/sdks/organizations/README.md#list) - Get a list of organizations for an instance
* [Create](docs/sdks/organizations/README.md#create) - Create an organization
* [Get](docs/sdks/organizations/README.md#get) - Retrieve an organization by ID or slug
* [Update](docs/sdks/organizations/README.md#update) - Update an organization
* [Delete](docs/sdks/organizations/README.md#delete) - Delete an organization
* [MergeMetadata](docs/sdks/organizations/README.md#mergemetadata) - Merge and update metadata for an organization
* [UploadLogo](docs/sdks/organizations/README.md#uploadlogo) - Upload a logo for the organization
* [DeleteLogo](docs/sdks/organizations/README.md#deletelogo) - Delete the organization's logo.

### [PhoneNumbers](docs/sdks/phonenumbers/README.md)

* [Create](docs/sdks/phonenumbers/README.md#create) - Create a phone number
* [Get](docs/sdks/phonenumbers/README.md#get) - Retrieve a phone number
* [Delete](docs/sdks/phonenumbers/README.md#delete) - Delete a phone number
* [Update](docs/sdks/phonenumbers/README.md#update) - Update a phone number

### [ProxyChecks](docs/sdks/proxychecks/README.md)

* [Verify](docs/sdks/proxychecks/README.md#verify) - Verify the proxy configuration for your domain

### [RedirectUrls](docs/sdks/redirecturls/README.md)

* [List](docs/sdks/redirecturls/README.md#list) - List all redirect URLs
* [Create](docs/sdks/redirecturls/README.md#create) - Create a redirect URL
* [Get](docs/sdks/redirecturls/README.md#get) - Retrieve a redirect URL
* [Delete](docs/sdks/redirecturls/README.md#delete) - Delete a redirect URL

### [SamlConnections](docs/sdks/samlconnections/README.md)

* [List](docs/sdks/samlconnections/README.md#list) - Get a list of SAML Connections for an instance
* [Create](docs/sdks/samlconnections/README.md#create) - Create a SAML Connection
* [Get](docs/sdks/samlconnections/README.md#get) - Retrieve a SAML Connection by ID
* [Update](docs/sdks/samlconnections/README.md#update) - Update a SAML Connection
* [Delete](docs/sdks/samlconnections/README.md#delete) - Delete a SAML Connection

### [Sessions](docs/sdks/sessions/README.md)

* [List](docs/sdks/sessions/README.md#list) - List all sessions
* [Create](docs/sdks/sessions/README.md#create) - Create a new active session
* [Get](docs/sdks/sessions/README.md#get) - Retrieve a session
* [Refresh](docs/sdks/sessions/README.md#refresh) - Refresh a session
* [Revoke](docs/sdks/sessions/README.md#revoke) - Revoke a session
* [~~Verify~~](docs/sdks/sessions/README.md#verify) - Verify a session :warning: **Deprecated**
* [CreateToken](docs/sdks/sessions/README.md#createtoken) - Create a session token
* [CreateTokenFromTemplate](docs/sdks/sessions/README.md#createtokenfromtemplate) - Create a session token from a jwt template

### [SignInTokens](docs/sdks/signintokens/README.md)

* [Create](docs/sdks/signintokens/README.md#create) - Create sign-in token
* [Revoke](docs/sdks/signintokens/README.md#revoke) - Revoke the given sign-in token

### [SignUps](docs/sdks/signups/README.md)

* [Get](docs/sdks/signups/README.md#get) - Retrieve a sign-up by ID
* [Update](docs/sdks/signups/README.md#update) - Update a sign-up

### [~~Templates~~](docs/sdks/templates/README.md)

* [~~Preview~~](docs/sdks/templates/README.md#preview) - Preview changes to a template :warning: **Deprecated**

### [TestingTokens](docs/sdks/testingtokens/README.md)

* [Create](docs/sdks/testingtokens/README.md#create) - Retrieve a new testing token

### [Users](docs/sdks/users/README.md)

* [List](docs/sdks/users/README.md#list) - List all users
* [Create](docs/sdks/users/README.md#create) - Create a new user
* [Count](docs/sdks/users/README.md#count) - Count users
* [Get](docs/sdks/users/README.md#get) - Retrieve a user
* [Update](docs/sdks/users/README.md#update) - Update a user
* [Delete](docs/sdks/users/README.md#delete) - Delete a user
* [Ban](docs/sdks/users/README.md#ban) - Ban a user
* [Unban](docs/sdks/users/README.md#unban) - Unban a user
* [Lock](docs/sdks/users/README.md#lock) - Lock a user
* [Unlock](docs/sdks/users/README.md#unlock) - Unlock a user
* [SetProfileImage](docs/sdks/users/README.md#setprofileimage) - Set user profile image
* [DeleteProfileImage](docs/sdks/users/README.md#deleteprofileimage) - Delete user profile image
* [UpdateMetadata](docs/sdks/users/README.md#updatemetadata) - Merge and update a user's metadata
* [GetOAuthAccessToken](docs/sdks/users/README.md#getoauthaccesstoken) - Retrieve the OAuth access token of a user
* [GetOrganizationMemberships](docs/sdks/users/README.md#getorganizationmemberships) - Retrieve all memberships for a user
* [GetOrganizationInvitations](docs/sdks/users/README.md#getorganizationinvitations) - Retrieve all invitations for a user
* [VerifyPassword](docs/sdks/users/README.md#verifypassword) - Verify the password of a user
* [VerifyTotp](docs/sdks/users/README.md#verifytotp) - Verify a TOTP or backup code for a user
* [DisableMfa](docs/sdks/users/README.md#disablemfa) - Disable a user's MFA methods
* [DeleteBackupCodes](docs/sdks/users/README.md#deletebackupcodes) - Disable all user's Backup codes
* [DeletePasskey](docs/sdks/users/README.md#deletepasskey) - Delete a user passkey
* [DeleteWeb3Wallet](docs/sdks/users/README.md#deleteweb3wallet) - Delete a user web3 wallet
* [DeleteTOTP](docs/sdks/users/README.md#deletetotp) - Delete all the user's TOTPs
* [DeleteExternalAccount](docs/sdks/users/README.md#deleteexternalaccount) - Delete External Account
* [GetInstanceOrganizationMemberships](docs/sdks/users/README.md#getinstanceorganizationmemberships) - Get a list of all organization memberships within an instance.

### [WaitlistEntries](docs/sdks/waitlistentries/README.md)

* [List](docs/sdks/waitlistentries/README.md#list) - List all waitlist entries
* [Create](docs/sdks/waitlistentries/README.md#create) - Create a waitlist entry

### [Webhooks](docs/sdks/webhooks/README.md)

* [CreateSvixApp](docs/sdks/webhooks/README.md#createsvixapp) - Create a Svix app
* [DeleteSvixApp](docs/sdks/webhooks/README.md#deletesvixapp) - Delete a Svix app
* [GenerateSvixAuthURL](docs/sdks/webhooks/README.md#generatesvixauthurl) - Create a Svix Dashboard URL

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Retries [retries] -->
## Retries

Some of the endpoints in this SDK support retries. If you use the SDK without any configuration, it will fall back to the default retry strategy provided by the API. However, the default retry strategy can be overridden on a per-operation basis, or across the entire SDK.

To change the default retry strategy for a single API call, simply pass a `RetryConfig` to the call:
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi();

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(
    retryConfig: new RetryConfig(
        strategy: RetryConfig.RetryStrategy.BACKOFF,
        backoff: new BackoffStrategy(
            initialIntervalMs: 1L,
            maxIntervalMs: 50L,
            maxElapsedTimeMs: 100L,
            exponent: 1.1
        ),
        retryConnectionErrors: false
    ),
    request: req
);

// handle response
```

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when intitializing the SDK:
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(retryConfig: new RetryConfig(
    strategy: RetryConfig.RetryStrategy.BACKOFF,
    backoff: new BackoffStrategy(
        initialIntervalMs: 1L,
        maxIntervalMs: 50L,
        maxElapsedTimeMs: 100L,
        exponent: 1.1
    ),
    retryConnectionErrors: false
));

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(req);

// handle response
```
<!-- End Retries [retries] -->

<!-- Start Error Handling [errors] -->
## Error Handling

Handling errors in this SDK should largely match your expectations. All operations return a response object or throw an exception.

By default, an API error will raise a `Clerk.BackendAPI.Models.Errors.SDKError` exception, which has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | The error message     |
| `Request`     | *HttpRequestMessage*  | The HTTP request      |
| `Response`    | *HttpResponseMessage* | The HTTP response     |

When custom error responses are specified for an operation, the SDK may also throw their associated exceptions. You can refer to respective *Errors* tables in SDK docs for more details on possible exception types for each operation. For example, the `VerifyAsync` method throws the following exceptions:

| Error Type                                 | Status Code   | Content Type     |
| ------------------------------------------ | ------------- | ---------------- |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404 | application/json |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX      | \*/\*            |

### Example

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Errors;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

try
{
    VerifyClientRequestBody req = new VerifyClientRequestBody() {
        Token = "jwt_token_example",
    };

    var res = await sdk.Clients.VerifyAsync(req);

    // handle response
}
catch (Exception ex)
{
    if (ex is ClerkErrors)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Clerk.BackendAPI.Models.Errors.SDKError)
    {
        // Handle default exception
        throw;
    }
}
```
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Override Server URL Per-Client

The default server can be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(serverUrl: "https://api.clerk.com/v1");

GetPublicInterstitialRequest req = new GetPublicInterstitialRequest() {
    FrontendApiQueryParameter1 = "pub_1a2b3c4d",
};

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(req);

// handle response
```
<!-- End Server Selection [server] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->

# Development

## Maturity

This SDK is in beta, and there may be breaking changes between versions without a major version update. Therefore, we recommend pinning usage
to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally
looking for the latest version.

## Contributions

While we value open-source contributions to this SDK, this library is generated programmatically. Any manual changes added to internal files will be overwritten on the next generation. 
We look forward to hearing your feedback. Feel free to open a PR or an issue with a proof of concept and we'll do our best to include it in a future release. 

### SDK Created by [Speakeasy](https://www.speakeasy.com/?utm_source=openapi-clerk-backend-api-sdk-clerk-backend-api-sd-ksas&utm_campaign=csharp)
