# MachineScope

Machine scope created successfully for a machine


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `Object`                                                            | [MachineScopeObject](../../Models/Components/MachineScopeObject.md) | :heavy_check_mark:                                                  | N/A                                                                 |
| `FromMachineId`                                                     | *string*                                                            | :heavy_check_mark:                                                  | The ID of the machine that has access to the target machine.        |
| `ToMachineId`                                                       | *string*                                                            | :heavy_check_mark:                                                  | The ID of the machine that is being accessed.                       |
| `CreatedAt`                                                         | *long*                                                              | :heavy_check_mark:                                                  | Unix timestamp of creation.                                         |