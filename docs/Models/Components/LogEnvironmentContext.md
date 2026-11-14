# LogEnvironmentContext

Environment context for the log event.


## Fields

| Field                                                                     | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `Type`                                                                    | *string*                                                                  | :heavy_minus_sign:                                                        | The environment type (e.g., "development", "production").                 |
| `Application`                                                             | [LogApplicationContext](../../Models/Components/LogApplicationContext.md) | :heavy_minus_sign:                                                        | Application context information.                                          |
| `Domain`                                                                  | [LogDomainContext](../../Models/Components/LogDomainContext.md)           | :heavy_minus_sign:                                                        | Domain context information.                                               |
| `PrimaryDomain`                                                           | [LogDomainContext](../../Models/Components/LogDomainContext.md)           | :heavy_minus_sign:                                                        | Domain context information.                                               |