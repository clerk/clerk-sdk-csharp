# Act

The actor chain of an access token issued by an OAuth 2.0 Token Exchange (RFC 8693 section 4.1). Omitted for other access tokens.


## Fields

| Field                                                         | Type                                                          | Required                                                      | Description                                                   |
| ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- |
| `Iss`                                                         | *string*                                                      | :heavy_minus_sign:                                            | N/A                                                           |
| `Sub`                                                         | *string*                                                      | :heavy_check_mark:                                            | N/A                                                           |
| `ActValue`                                                    | [ResponseBodyAct](../../Models/Operations/ResponseBodyAct.md) | :heavy_minus_sign:                                            | N/A                                                           |