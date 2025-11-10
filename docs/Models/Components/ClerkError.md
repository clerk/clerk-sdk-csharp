# ClerkError


## Fields

| Field                                                     | Type                                                      | Required                                                  | Description                                               | Example                                                   |
| --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| `Message`                                                 | *string*                                                  | :heavy_check_mark:                                        | N/A                                                       | Invalid input                                             |
| `LongMessage`                                             | *string*                                                  | :heavy_check_mark:                                        | N/A                                                       | The input provided does not meet the requirements.        |
| `Code`                                                    | *string*                                                  | :heavy_check_mark:                                        | N/A                                                       | 400_bad_request                                           |
| `Meta`                                                    | [Models.Components.Meta](../../Models/Components/Meta.md) | :heavy_minus_sign:                                        | N/A                                                       | {}                                                        |