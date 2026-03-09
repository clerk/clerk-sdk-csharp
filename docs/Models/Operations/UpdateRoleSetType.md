# UpdateRoleSetType

Set to "initial" to make this the default role set for new organizations.
Only one role set can be "initial" per instance; setting this will change any existing initial role set to "custom".

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Operations;

var value = UpdateRoleSetType.Initial;
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Initial` | initial   |