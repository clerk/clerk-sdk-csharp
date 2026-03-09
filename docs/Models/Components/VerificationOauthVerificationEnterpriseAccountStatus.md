# VerificationOauthVerificationEnterpriseAccountStatus

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Components;

var value = VerificationOauthVerificationEnterpriseAccountStatus.Unverified;

// Open enum: use .Of() to create instances from custom string values
var custom = VerificationOauthVerificationEnterpriseAccountStatus.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `Unverified`   | unverified     |
| `Verified`     | verified       |
| `Failed`       | failed         |
| `Expired`      | expired        |
| `Transferable` | transferable   |