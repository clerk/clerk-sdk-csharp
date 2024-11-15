#nullable enable
namespace Clerk.BackendAPI.Helpers.Jwks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;


    /// <summary>
    /// Represents the reason for a TokenVerificationException or AuthenticateRequestException
    /// </summary>
    public class ErrorReason
    {
        public readonly string Id;
        public readonly string Message;

        public ErrorReason(string id, string message)
        {
            this.Id = id;
            this.Message = message;
        }
    }
}
