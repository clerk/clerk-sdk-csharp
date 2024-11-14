# GetTemplateRequest


## Fields

| Field                                                                     | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `TemplateType`                                                            | [PathParamTemplateType](../../Models/Operations/PathParamTemplateType.md) | :heavy_check_mark:                                                        | The type of templates to retrieve (email or SMS)                          | email                                                                     |
| `Slug`                                                                    | *string*                                                                  | :heavy_check_mark:                                                        | The slug (i.e. machine-friendly name) of the template to retrieve         | welcome-email                                                             |