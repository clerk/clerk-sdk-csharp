# IdentificationStatus

Controls the status of the replacement email address. Defaults to `verified`. Set to
`reserved` to create it reserved (unverified but usable for sign-in and locked)
instead of verified.

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Operations;

var value = IdentificationStatus.Verified;
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Verified` | verified   |
| `Reserved` | reserved   |