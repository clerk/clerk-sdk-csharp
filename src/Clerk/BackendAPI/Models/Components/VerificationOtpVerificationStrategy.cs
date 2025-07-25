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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    [JsonConverter(typeof(OpenEnumConverter))]
    public class VerificationOtpVerificationStrategy : IEquatable<VerificationOtpVerificationStrategy>
    {
        public static readonly VerificationOtpVerificationStrategy PhoneCode = new VerificationOtpVerificationStrategy("phone_code");
        public static readonly VerificationOtpVerificationStrategy EmailCode = new VerificationOtpVerificationStrategy("email_code");
        public static readonly VerificationOtpVerificationStrategy ResetPasswordEmailCode = new VerificationOtpVerificationStrategy("reset_password_email_code");

        private static readonly Dictionary <string, VerificationOtpVerificationStrategy> _knownValues =
            new Dictionary <string, VerificationOtpVerificationStrategy> ()
            {
                ["phone_code"] = PhoneCode,
                ["email_code"] = EmailCode,
                ["reset_password_email_code"] = ResetPasswordEmailCode
            };

        private static readonly ConcurrentDictionary<string, VerificationOtpVerificationStrategy> _values =
            new ConcurrentDictionary<string, VerificationOtpVerificationStrategy>(_knownValues);

        private VerificationOtpVerificationStrategy(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            Value = value;
        }

        public string Value { get; }

        public static VerificationOtpVerificationStrategy Of(string value)
        {
            return _values.GetOrAdd(value, _ => new VerificationOtpVerificationStrategy(value));
        }

        public static implicit operator VerificationOtpVerificationStrategy(string value) => Of(value);
        public static implicit operator string(VerificationOtpVerificationStrategy verificationotpverificationstrategy) => verificationotpverificationstrategy.Value;

        public static VerificationOtpVerificationStrategy[] Values()
        {
            return _values.Values.ToArray();
        }

        public override string ToString() => Value.ToString();

        public bool IsKnown()
        {
            return _knownValues.ContainsKey(Value);
        }

        public override bool Equals(object? obj) => Equals(obj as VerificationOtpVerificationStrategy);

        public bool Equals(VerificationOtpVerificationStrategy? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Value, other.Value);
        }

        public override int GetHashCode() => Value.GetHashCode();
    }

}