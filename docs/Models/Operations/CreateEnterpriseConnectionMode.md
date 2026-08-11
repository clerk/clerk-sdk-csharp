# CreateEnterpriseConnectionMode

Controls the login_hint sent to the IdP on SSO sign-in

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Operations;

var value = CreateEnterpriseConnectionMode.EmailAddress;
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `EmailAddress`    | email_address     |
| `CustomAttribute` | custom_attribute  |
| `Off`             | off               |