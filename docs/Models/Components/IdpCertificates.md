# IdpCertificates


## Fields

| Field                                                | Type                                                 | Required                                             | Description                                          |
| ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| `Certificate`                                        | *string*                                             | :heavy_check_mark:                                   | The X.509 certificate, base64 DER without PEM armor  |
| `IssuedAt`                                           | *long*                                               | :heavy_check_mark:                                   | Unix timestamp (milliseconds) of the X.509 NotBefore |
| `ExpiresAt`                                          | *long*                                               | :heavy_check_mark:                                   | Unix timestamp (milliseconds) of the X.509 NotAfter  |