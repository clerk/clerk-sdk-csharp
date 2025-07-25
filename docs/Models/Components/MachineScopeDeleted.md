# MachineScopeDeleted

Machine scope deleted successfully for a machine


## Fields

| Field                                                                             | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `Object`                                                                          | [MachineScopeDeletedObject](../../Models/Components/MachineScopeDeletedObject.md) | :heavy_check_mark:                                                                | String representing the object's type.                                            |
| `FromMachineId`                                                                   | *string*                                                                          | :heavy_check_mark:                                                                | The ID of the machine that had access to the target machine                       |
| `ToMachineId`                                                                     | *string*                                                                          | :heavy_check_mark:                                                                | The ID of the machine that was being accessed                                     |
| `Deleted`                                                                         | *bool*                                                                            | :heavy_check_mark:                                                                | Whether the machine scope was successfully deleted                                |