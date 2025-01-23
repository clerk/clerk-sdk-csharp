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
    using System.Collections.Generic;
    
    /// <summary>
    /// Success
    /// </summary>
    public class Instance
    {

        /// <summary>
        /// String representing the object&apos;s type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public InstanceObject? Object { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("environment_type")]
        public string? EnvironmentType { get; set; }

        [JsonProperty("allowed_origins")]
        public List<string>? AllowedOrigins { get; set; } = null;
    }
}