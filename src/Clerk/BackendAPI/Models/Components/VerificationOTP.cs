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
    
    public class VerificationOTP
    {

        [JsonProperty("status")]
        public OTPVerificationStatus Status { get; set; } = default!;

        [JsonProperty("strategy")]
        public OTPVerificationStrategy Strategy { get; set; } = default!;

        [JsonProperty("attempts", NullValueHandling = NullValueHandling.Include)]
        public long? Attempts { get; set; }

        [JsonProperty("expire_at", NullValueHandling = NullValueHandling.Include)]
        public long? ExpireAt { get; set; }

        [JsonProperty("verified_at_client")]
        public string? VerifiedAtClient { get; set; } = null;
    }
}