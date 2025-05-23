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
    
    public class GoogleOneTap
    {

        [JsonProperty("status")]
        public GoogleOneTapVerificationStatus Status { get; set; } = default!;

        [JsonProperty("strategy")]
        public GoogleOneTapVerificationStrategy Strategy { get; set; } = default!;

        [JsonProperty("expire_at", NullValueHandling = NullValueHandling.Include)]
        public long? ExpireAt { get; set; }

        [JsonProperty("attempts", NullValueHandling = NullValueHandling.Include)]
        public long? Attempts { get; set; }

        [JsonProperty("verified_at_client")]
        public string? VerifiedAtClient { get; set; } = null;

        [JsonProperty("error")]
        public GoogleOneTapVerificationError? Error { get; set; } = null;
    }
}