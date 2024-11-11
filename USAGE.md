<!-- Start SDK Example Usage [usage] -->
```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi();

var res = await sdk.Miscellaneous.GetPublicInterstitialAsync(
    frontendApi: "<value>",
    publishableKey: "<value>"
);

// handle response
```
<!-- End SDK Example Usage [usage] -->