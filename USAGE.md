<!-- Start SDK Example Usage [usage] -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi();

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(
    frontendApi: "<value>",
    publishableKey: "<value>"
);

// handle response
```
<!-- End SDK Example Usage [usage] -->