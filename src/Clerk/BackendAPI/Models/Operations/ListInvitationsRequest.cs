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
    using Clerk.BackendAPI.Models.Operations;
    using Clerk.BackendAPI.Utils;
    
    public class ListInvitationsRequest
    {

        /// <summary>
        /// Applies a limit to the number of results returned.<br/>
        /// 
        /// <remarks>
        /// Can be used for paginating the results together with `offset`.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; } = 10;

        /// <summary>
        /// Skip the first `offset` results when paginating.<br/>
        /// 
        /// <remarks>
        /// Needs to be an integer greater or equal to zero.<br/>
        /// To be used in conjunction with `limit`.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=offset")]
        public long? Offset { get; set; } = 0;

        /// <summary>
        /// Filter invitations based on their status
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=status")]
        public ListInvitationsQueryParamStatus? Status { get; set; }

        /// <summary>
        /// Filter invitations based on their `email_address` or `id`
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=query")]
        public string? Query { get; set; }
    }
}