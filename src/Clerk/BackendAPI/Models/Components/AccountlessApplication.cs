//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Clerk.BackendAPI.Models.Components
{
    using Clerk.BackendAPI.Models.Components;
    using Clerk.BackendAPI.Utils;
    using Newtonsoft.Json;
    
    /// <summary>
    /// Success
    /// </summary>
    public class AccountlessApplication
    {

        [JsonProperty("object")]
        public AccountlessApplicationObject Object { get; set; } = default!;

        [JsonProperty("publishable_key")]
        public string PublishableKey { get; set; } = default!;

        [JsonProperty("secret_key")]
        public string? SecretKey { get; set; }

        [JsonProperty("claim_url")]
        public string? ClaimUrl { get; set; }

        [JsonProperty("api_keys_url")]
        public string? ApiKeysUrl { get; set; }
    }
}