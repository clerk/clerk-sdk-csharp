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
    
    public class VerificationSamlErrorClerkError
    {

        [JsonProperty("message")]
        public string Message { get; set; } = default!;

        [JsonProperty("long_message")]
        public string LongMessage { get; set; } = default!;

        [JsonProperty("code")]
        public string Code { get; set; } = default!;

        [JsonProperty("meta")]
        public ClerkErrorErrorSAMLAccountMeta? Meta { get; set; }

        [JsonProperty("clerk_trace_id")]
        public string? ClerkTraceId { get; set; }
    }
}