# VerificationOauthVerificationStatus

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Components;

var value = VerificationOauthVerificationStatus.Unverified;

// Open enum: use .Of() to create instances from custom string values
var custom = VerificationOauthVerificationStatus.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `Unverified`   | unverified     |
| `Verified`     | verified       |
| `Failed`       | failed         |
| `Expired`      | expired        |
| `Transferable` | transferable   |