//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests
{
    using Newtonsoft.Json;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    
    public class VerifyTOTPRequestBody
    {

        /// <summary>
        /// The TOTP or backup code to verify
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = default!;
    }
}