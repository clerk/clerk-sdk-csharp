# ProxyChecks

## Overview

### Available Operations

* [Verify](#verify) - Verify the proxy configuration for your domain

## Verify

This endpoint can be used to validate that a proxy-enabled domain is operational.
It tries to verify that the proxy URL provided in the parameters maps to a functional proxy that can reach the Clerk Frontend API.

You can use this endpoint before you set a proxy URL for a domain. This way you can ensure that switching to proxy-based
configuration will not lead to downtime for your instance.

The `proxy_url` parameter allows for testing proxy configurations for domains that don't have a proxy URL yet, or operate on
a different proxy URL than the one provided. It can also be used to re-validate a domain that is already configured to work with a proxy.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="VerifyDomainProxy" method="post" path="/proxy_checks" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

VerifyDomainProxyRequestBody req = new VerifyDomainProxyRequestBody() {
    DomainId = "domain_32hfu3e",
    ProxyUrl = "https://example.com/__clerk",
};

var res = await sdk.ProxyChecks.VerifyAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [VerifyDomainProxyRequestBody](../../Models/Operations/VerifyDomainProxyRequestBody.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[VerifyDomainProxyResponse](../../Models/Operations/VerifyDomainProxyResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |