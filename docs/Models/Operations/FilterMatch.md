# FilterMatch

Controls how `subject`, `type`, `actor`, `user_id`, `identifier`,
`trace_id`, `client_id`, `session_id`, `impersonator_user_id`,
`ip_address`, and `payload_filter` entries
are combined: `all` (default) requires every supplied filter to
match; `any` returns events that match at least one of the
supplied filters. `event_time_after`, `event_time_before`, and
`end_user_facing_only` are always ANDed with the (possibly OR-ed)
string filter group.

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Operations;

var value = FilterMatch.All;
```


## Values

| Name  | Value |
| ----- | ----- |
| `All` | all   |
| `Any` | any   |