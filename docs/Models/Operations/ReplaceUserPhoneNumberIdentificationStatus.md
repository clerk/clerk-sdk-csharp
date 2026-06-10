# ReplaceUserPhoneNumberIdentificationStatus

Controls the status of the replacement phone number. Defaults to `verified`. Set to
`reserved` to create it reserved (unverified but usable for sign-in and locked)
instead of verified.

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Operations;

var value = ReplaceUserPhoneNumberIdentificationStatus.Verified;
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Verified` | verified   |
| `Reserved` | reserved   |