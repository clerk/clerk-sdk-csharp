# Type

The type of the role set. "initial" role sets are the default for new organizations.
Only one role set can be "initial" per instance.

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Operations;

var value = Type.Initial;
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Initial` | initial   |
| `Custom`  | custom    |