//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components
{
    using Newtonsoft.Json;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    using System.Collections.Generic;
    
    /// <summary>
    /// A list of SAML Connections
    /// </summary>
    public class SAMLConnections
    {

        [JsonProperty("data")]
        public List<SchemasSAMLConnection> Data { get; set; } = default!;

        /// <summary>
        /// Total number of SAML Connections<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [JsonProperty("total_count")]
        public long TotalCount { get; set; } = default!;
    }
}