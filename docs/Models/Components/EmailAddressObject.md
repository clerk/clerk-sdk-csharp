# EmailAddressObject

String representing the object's type. Objects of the same type share the same value.


## Example Usage

```csharp
using Clerk.BackendAPI.Models.Components;

var value = EmailAddressObject.EmailAddress;

// Open enum: use .Of() to create instances from custom string values
var custom = EmailAddressObject.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `EmailAddress` | email_address  |