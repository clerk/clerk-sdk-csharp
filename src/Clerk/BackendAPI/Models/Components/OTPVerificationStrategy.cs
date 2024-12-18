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
    
    public enum OTPVerificationStrategy
    {
        [JsonProperty("phone_code")]
        PhoneCode,
        [JsonProperty("email_code")]
        EmailCode,
        [JsonProperty("email_link")]
        EmailLink,
        [JsonProperty("reset_password_email_code")]
        ResetPasswordEmailCode,
        [JsonProperty("from_oauth_discord")]
        FromOauthDiscord,
        [JsonProperty("from_oauth_google")]
        FromOauthGoogle,
        [JsonProperty("from_oauth_apple")]
        FromOauthApple,
        [JsonProperty("from_oauth_microsoft")]
        FromOauthMicrosoft,
        [JsonProperty("from_oauth_github")]
        FromOauthGithub,
        [JsonProperty("ticket")]
        Ticket,
    }

    public static class OTPVerificationStrategyExtension
    {
        public static string Value(this OTPVerificationStrategy value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static OTPVerificationStrategy ToEnum(this string value)
        {
            foreach(var field in typeof(OTPVerificationStrategy).GetFields())
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

                    if (enumVal is OTPVerificationStrategy)
                    {
                        return (OTPVerificationStrategy)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum OTPVerificationStrategy");
        }
    }

}