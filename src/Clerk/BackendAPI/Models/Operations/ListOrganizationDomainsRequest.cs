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
    using Clerk.BackendAPI.Utils;
    
    public class ListOrganizationDomainsRequest
    {

        /// <summary>
        /// The organization ID.
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=organization_id")]
        public string OrganizationId { get; set; } = default!;

        /// <summary>
        /// Applies a limit to the number of results returned.<br/>
        /// 
        /// <remarks>
        /// Can be used for paginating the results together with `offset`.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=limit")]
        public double? Limit { get; set; } = 10D;

        /// <summary>
        /// Skip the first `offset` results when paginating.<br/>
        /// 
        /// <remarks>
        /// Needs to be an integer greater or equal to zero.<br/>
        /// To be used in conjunction with `limit`.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=offset")]
        public double? Offset { get; set; } = 0D;

        /// <summary>
        /// Filter domains by their verification status. `true` or `false`
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=verified")]
        public string? Verified { get; set; }

        /// <summary>
        /// Filter domains by their enrollment mode
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=enrollment_mode")]
        public string? EnrollmentMode { get; set; }
    }
}