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
    
    public class CreatePhoneNumberRequestBody
    {

        /// <summary>
        /// The ID representing the user
        /// </summary>
        [JsonProperty("user_id")]
        public string? UserId { get; set; }

        /// <summary>
        /// The new phone number. Must adhere to the E.164 standard for phone number format.
        /// </summary>
        [JsonProperty("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// When created, the phone number will be marked as verified.
        /// </summary>
        [JsonProperty("verified")]
        public bool? Verified { get; set; } = null;

        /// <summary>
        /// Create this phone number as the primary phone number for the user.<br/>
        /// 
        /// <remarks>
        /// Default: false, unless it is the first phone number.
        /// </remarks>
        /// </summary>
        [JsonProperty("primary")]
        public bool? Primary { get; set; } = null;

        /// <summary>
        /// Create this phone number as reserved for multi-factor authentication.<br/>
        /// 
        /// <remarks>
        /// The phone number must also be verified.<br/>
        /// If there are no other reserved second factors, the phone number will be set as the default second factor.
        /// </remarks>
        /// </summary>
        [JsonProperty("reserved_for_second_factor")]
        public bool? ReservedForSecondFactor { get; set; } = null;
    }
}