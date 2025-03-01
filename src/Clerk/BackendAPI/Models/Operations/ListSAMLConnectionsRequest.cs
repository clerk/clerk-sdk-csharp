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
    using System.Collections.Generic;
    
    public class ListSAMLConnectionsRequest
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
        /// Returns SAML connections that have an associated organization ID to the<br/>
        /// 
        /// <remarks>
        /// given organizations.<br/>
        /// For each organization id, the `+` and `-` can be<br/>
        /// prepended to the id, which denote whether the<br/>
        /// respective organization should be included or<br/>
        /// excluded from the result set.<br/>
        /// Accepts up to 100 organization ids.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=organization_id")]
        public List<string>? OrganizationId { get; set; }
    }
}