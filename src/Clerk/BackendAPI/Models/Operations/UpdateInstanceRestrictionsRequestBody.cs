//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Clerk.BackendAPI.Models.Operations
{
    using Clerk.BackendAPI.Utils;
    using Newtonsoft.Json;
    
    public class UpdateInstanceRestrictionsRequestBody
    {

        [JsonProperty("allowlist")]
        public bool? Allowlist { get; set; } = null;

        [JsonProperty("blocklist")]
        public bool? Blocklist { get; set; } = null;

        [JsonProperty("block_email_subaddresses")]
        public bool? BlockEmailSubaddresses { get; set; } = null;

        [JsonProperty("block_disposable_email_domains")]
        public bool? BlockDisposableEmailDomains { get; set; } = null;
    }
}