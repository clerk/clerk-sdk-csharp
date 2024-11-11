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
    using System;
    
    /// <summary>
    /// The type of templates to retrieve (email or SMS)
    /// </summary>
    public enum PathParamTemplateType
    {
        [JsonProperty("email")]
        Email,
        [JsonProperty("sms")]
        Sms,
    }

    public static class PathParamTemplateTypeExtension
    {
        public static string Value(this PathParamTemplateType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static PathParamTemplateType ToEnum(this string value)
        {
            foreach(var field in typeof(PathParamTemplateType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    var enumVal = field.GetValue(null);

                    if (enumVal is PathParamTemplateType)
                    {
                        return (PathParamTemplateType)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum PathParamTemplateType");
        }
    }

}