# GetTemplateRequest


## Fields

| Field                                                                   | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `TemplateType`                                                          | [PathParamTemplateType](../../Models/Requests/PathParamTemplateType.md) | :heavy_check_mark:                                                      | The type of templates to retrieve (email or SMS)                        |
| `Slug`                                                                  | *string*                                                                | :heavy_check_mark:                                                      | The slug (i.e. machine-friendly name) of the template to retrieve       |