# Strategy

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Components;

var value = Strategy.PhoneCode;

// Open enum: use .Of() to create instances from custom string values
var custom = Strategy.Of("custom_value");
```


## Values

| Name                      | Value                     |
| ------------------------- | ------------------------- |
| `PhoneCode`               | phone_code                |
| `EmailCode`               | email_code                |
| `ResetPasswordEmailCode`  | reset_password_email_code |