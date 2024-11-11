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
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    using System;
    
    public enum ActorTokenObject
    {
        [JsonProperty("actor_token")]
        ActorToken,
    }

    public static class ActorTokenObjectExtension
    {
        public static string Value(this ActorTokenObject value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static ActorTokenObject ToEnum(this string value)
        {
            foreach(var field in typeof(ActorTokenObject).GetFields())
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

                    if (enumVal is ActorTokenObject)
                    {
                        return (ActorTokenObject)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum ActorTokenObject");
        }
    }

}