# Role


## Fields

| Field                                                            | Type                                                             | Required                                                         | Description                                                      |
| ---------------------------------------------------------------- | ---------------------------------------------------------------- | ---------------------------------------------------------------- | ---------------------------------------------------------------- |
| `Object`                                                         | [RoleObject](../../Models/Components/RoleObject.md)              | :heavy_check_mark:                                               | N/A                                                              |
| `Id`                                                             | *string*                                                         | :heavy_check_mark:                                               | N/A                                                              |
| `Name`                                                           | *string*                                                         | :heavy_check_mark:                                               | N/A                                                              |
| `Key`                                                            | *string*                                                         | :heavy_check_mark:                                               | N/A                                                              |
| `Description`                                                    | *string*                                                         | :heavy_check_mark:                                               | N/A                                                              |
| `IsCreatorEligible`                                              | *bool*                                                           | :heavy_check_mark:                                               | Whether this role is eligible to be an organization creator role |
| `Permissions`                                                    | List<[Permission](../../Models/Components/Permission.md)>        | :heavy_check_mark:                                               | N/A                                                              |
| `CreatedAt`                                                      | *long*                                                           | :heavy_check_mark:                                               | Unix timestamp of creation.<br/>                                 |
| `UpdatedAt`                                                      | *long*                                                           | :heavy_check_mark:                                               | Unix timestamp of last update.<br/>                              |