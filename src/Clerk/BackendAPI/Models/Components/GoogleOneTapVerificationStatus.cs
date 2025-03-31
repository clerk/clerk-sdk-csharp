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
    using Clerk.BackendAPI.Utils;
    using Newtonsoft.Json;
    using System;
    
    public enum GoogleOneTapVerificationStatus
    {
        [JsonProperty("unverified")]
        Unverified,
        [JsonProperty("verified")]
        Verified,
    }

    public static class GoogleOneTapVerificationStatusExtension
    {
        public static string Value(this GoogleOneTapVerificationStatus value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static GoogleOneTapVerificationStatus ToEnum(this string value)
        {
            foreach(var field in typeof(GoogleOneTapVerificationStatus).GetFields())
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

                    if (enumVal is GoogleOneTapVerificationStatus)
                    {
                        return (GoogleOneTapVerificationStatus)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum GoogleOneTapVerificationStatus");
        }
    }

}