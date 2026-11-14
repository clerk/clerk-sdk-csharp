# NextPageStatus

Pagination status. "true" means more results exist, "false" means no more results, "unknown" means the query was time-windowed and more results may exist beyond the window.

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Components;

var value = NextPageStatus.True;
```


## Values

| Name      | Value     |
| --------- | --------- |
| `True`    | true      |
| `False`   | false     |
| `Unknown` | unknown   |