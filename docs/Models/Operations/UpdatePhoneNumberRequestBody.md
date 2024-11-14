# UpdatePhoneNumberRequestBody


## Fields

| Field                                                                                                                                                                                                                | Type                                                                                                                                                                                                                 | Required                                                                                                                                                                                                             | Description                                                                                                                                                                                                          |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Verified`                                                                                                                                                                                                           | *bool*                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                   | The phone number will be marked as verified.                                                                                                                                                                         |
| `Primary`                                                                                                                                                                                                            | *bool*                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                   | Set this phone number as the primary phone number for the user.                                                                                                                                                      |
| `ReservedForSecondFactor`                                                                                                                                                                                            | *bool*                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                   | Set this phone number as reserved for multi-factor authentication.<br/>The phone number must also be verified.<br/>If there are no other reserved second factors, the phone number will be set as the default second factor. |