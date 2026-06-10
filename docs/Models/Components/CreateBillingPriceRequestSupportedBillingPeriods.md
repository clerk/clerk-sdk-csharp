# CreateBillingPriceRequestSupportedBillingPeriods

Which billing periods this price supports. Inferred from amounts if omitted.

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Components;

var value = CreateBillingPriceRequestSupportedBillingPeriods.Month;
```


## Values

| Name     | Value    |
| -------- | -------- |
| `Month`  | month    |
| `Annual` | annual   |
| `Both`   | both     |