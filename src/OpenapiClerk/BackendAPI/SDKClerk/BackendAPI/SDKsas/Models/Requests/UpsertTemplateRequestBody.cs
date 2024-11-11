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
    
    public class UpsertTemplateRequestBody
    {

        /// <summary>
        /// The user-friendly name of the template
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The email subject.<br/>
        /// 
        /// <remarks>
        /// Applicable only to email templates.
        /// </remarks>
        /// </summary>
        [JsonProperty("subject")]
        public string? Subject { get; set; } = null;

        /// <summary>
        /// The editor markup used to generate the body of the template
        /// </summary>
        [JsonProperty("markup")]
        public string? Markup { get; set; } = null;

        /// <summary>
        /// The template body before variable interpolation
        /// </summary>
        [JsonProperty("body")]
        public string? Body { get; set; }

        /// <summary>
        /// Whether Clerk should deliver emails or SMS messages based on the current template
        /// </summary>
        [JsonProperty("delivered_by_clerk")]
        public bool? DeliveredByClerk { get; set; } = null;

        /// <summary>
        /// The local part of the From email address that will be used for emails.<br/>
        /// 
        /// <remarks>
        /// For example, in the address &apos;hello@example.com&apos;, the local part is &apos;hello&apos;.<br/>
        /// Applicable only to email templates.
        /// </remarks>
        /// </summary>
        [JsonProperty("from_email_name")]
        public string? FromEmailName { get; set; }

        /// <summary>
        /// The local part of the Reply To email address that will be used for emails.<br/>
        /// 
        /// <remarks>
        /// For example, in the address &apos;hello@example.com&apos;, the local part is &apos;hello&apos;.<br/>
        /// Applicable only to email templates.
        /// </remarks>
        /// </summary>
        [JsonProperty("reply_to_email_name")]
        public string? ReplyToEmailName { get; set; }
    }
}