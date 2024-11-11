# Domain


## Fields

| Field                                                       | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `Object`                                                    | [DomainObject](../../Models/Components/DomainObject.md)     | :heavy_check_mark:                                          | N/A                                                         |
| `Id`                                                        | *string*                                                    | :heavy_check_mark:                                          | N/A                                                         |
| `Name`                                                      | *string*                                                    | :heavy_check_mark:                                          | N/A                                                         |
| `IsSatellite`                                               | *bool*                                                      | :heavy_check_mark:                                          | N/A                                                         |
| `FrontendApiUrl`                                            | *string*                                                    | :heavy_check_mark:                                          | N/A                                                         |
| `AccountsPortalUrl`                                         | *string*                                                    | :heavy_minus_sign:                                          | Null for satellite domains.<br/>                            |
| `ProxyUrl`                                                  | *string*                                                    | :heavy_minus_sign:                                          | N/A                                                         |
| `DevelopmentOrigin`                                         | *string*                                                    | :heavy_check_mark:                                          | N/A                                                         |
| `CnameTargets`                                              | List<[CNameTarget](../../Models/Components/CNameTarget.md)> | :heavy_minus_sign:                                          | N/A                                                         |