# LogDeviceContext

Device information for the log event.


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `IpAddress`                                                         | *string*                                                            | :heavy_minus_sign:                                                  | The IP address of the client.                                       |
| `UserAgent`                                                         | *string*                                                            | :heavy_minus_sign:                                                  | The user agent string of the client.                                |
| `Browser`                                                           | [LogBrowserContext](../../Models/Components/LogBrowserContext.md)   | :heavy_minus_sign:                                                  | Browser information.                                                |
| `DeviceType`                                                        | *string*                                                            | :heavy_minus_sign:                                                  | The type of device (e.g., "desktop", "mobile", "tablet").           |
| `IsMobile`                                                          | *bool*                                                              | :heavy_minus_sign:                                                  | Whether the device is a mobile device.                              |
| `Location`                                                          | [LogLocationContext](../../Models/Components/LogLocationContext.md) | :heavy_minus_sign:                                                  | Geographic location information.                                    |
| `ClerkJsVersion`                                                    | *string*                                                            | :heavy_minus_sign:                                                  | The version of Clerk.js used by the client.                         |
| `IsNative`                                                          | *bool*                                                              | :heavy_minus_sign:                                                  | Whether the client is a native application.                         |