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
    using System;
    using System.Collections.Generic;
    
    public class GetUserListRequest
    {

        /// <summary>
        /// Returns users with the specified email addresses.<br/>
        /// 
        /// <remarks>
        /// Accepts up to 100 email addresses.<br/>
        /// Any email addresses not found are ignored.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=email_address")]
        public List<string>? EmailAddress { get; set; }

        /// <summary>
        /// Returns users with the specified phone numbers.<br/>
        /// 
        /// <remarks>
        /// Accepts up to 100 phone numbers.<br/>
        /// Any phone numbers not found are ignored.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=phone_number")]
        public List<string>? PhoneNumber { get; set; }

        /// <summary>
        /// Returns users with the specified external ids.<br/>
        /// 
        /// <remarks>
        /// For each external id, the `+` and `-` can be<br/>
        /// prepended to the id, which denote whether the<br/>
        /// respective external id should be included or<br/>
        /// excluded from the result set.<br/>
        /// Accepts up to 100 external ids.<br/>
        /// Any external ids not found are ignored.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=external_id")]
        public List<string>? ExternalId { get; set; }

        /// <summary>
        /// Returns users with the specified usernames.<br/>
        /// 
        /// <remarks>
        /// Accepts up to 100 usernames.<br/>
        /// Any usernames not found are ignored.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=username")]
        public List<string>? Username { get; set; }

        /// <summary>
        /// Returns users with the specified web3 wallet addresses.<br/>
        /// 
        /// <remarks>
        /// Accepts up to 100 web3 wallet addresses.<br/>
        /// Any web3 wallet addressed not found are ignored.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=web3_wallet")]
        public List<string>? Web3Wallet { get; set; }

        /// <summary>
        /// Returns users with the user ids specified.<br/>
        /// 
        /// <remarks>
        /// For each user id, the `+` and `-` can be<br/>
        /// prepended to the id, which denote whether the<br/>
        /// respective user id should be included or<br/>
        /// excluded from the result set.<br/>
        /// Accepts up to 100 user ids.<br/>
        /// Any user ids not found are ignored.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=user_id")]
        public List<string>? UserId { get; set; }

        /// <summary>
        /// Returns users that have memberships to the<br/>
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

        /// <summary>
        /// Returns users that match the given query.<br/>
        /// 
        /// <remarks>
        /// For possible matches, we check the email addresses, phone numbers, usernames, web3 wallets, user ids, first and last names.<br/>
        /// The query value doesn&apos;t need to match the exact value you are looking for, it is capable of partial matches as well.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=query")]
        public string? Query { get; set; }

        /// <summary>
        /// Returns users with emails that match the given query, via case-insensitive partial match.<br/>
        /// 
        /// <remarks>
        /// For example, `email_address_query=ello` will match a user with the email `HELLO@example.com`.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=email_address_query")]
        public string? EmailAddressQuery { get; set; }

        /// <summary>
        /// Returns users with phone numbers that match the given query, via case-insensitive partial match.<br/>
        /// 
        /// <remarks>
        /// For example, `phone_number_query=555` will match a user with the phone number `+1555xxxxxxx`.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=phone_number_query")]
        public string? PhoneNumberQuery { get; set; }

        /// <summary>
        /// Returns users with usernames that match the given query, via case-insensitive partial match.<br/>
        /// 
        /// <remarks>
        /// For example, `username_query=CoolUser` will match a user with the username `SomeCoolUser`.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=username_query")]
        public string? UsernameQuery { get; set; }

        /// <summary>
        /// Returns users with names that match the given query, via case-insensitive partial match.
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=name_query")]
        public string? NameQuery { get; set; }

        /// <summary>
        /// Returns users which are either banned (`banned=true`) or not banned (`banned=false`).
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=banned")]
        public bool? Banned { get; set; }

        /// <summary>
        /// Returns users whose last session activity was before the given date (with millisecond precision).<br/>
        /// 
        /// <remarks>
        /// Example: use 1700690400000 to retrieve users whose last session activity was before 2023-11-23.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=last_active_at_before")]
        public long? LastActiveAtBefore { get; set; }

        /// <summary>
        /// Returns users whose last session activity was after the given date (with millisecond precision).<br/>
        /// 
        /// <remarks>
        /// Example: use 1700690400000 to retrieve users whose last session activity was after 2023-11-23.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=last_active_at_after")]
        public long? LastActiveAtAfter { get; set; }

        /// <summary>
        /// Returns users that had session activity since the given date.<br/>
        /// 
        /// <remarks>
        /// Example: use 1700690400000 to retrieve users that had session activity from 2023-11-23 until the current day.<br/>
        /// Deprecated in favor of `last_active_at_after`.
        /// </remarks>
        /// </summary>
        [Obsolete("This field will be removed in a future release, please migrate away from it as soon as possible")]
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=last_active_at_since")]
        public long? LastActiveAtSince { get; set; }

        /// <summary>
        /// Returns users who have been created before the given date (with millisecond precision).<br/>
        /// 
        /// <remarks>
        /// Example: use 1730160000000 to retrieve users who have been created before 2024-10-29.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=created_at_before")]
        public long? CreatedAtBefore { get; set; }

        /// <summary>
        /// Returns users who have been created after the given date (with millisecond precision).<br/>
        /// 
        /// <remarks>
        /// Example: use 1730160000000 to retrieve users who have been created after 2024-10-29.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=created_at_after")]
        public long? CreatedAtAfter { get; set; }

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
        /// Allows to return users in a particular order.<br/>
        /// 
        /// <remarks>
        /// At the moment, you can order the returned users by their `created_at`,`updated_at`,`email_address`,`web3wallet`,`first_name`,`last_name`,`phone_number`,`username`,`last_active_at`,`last_sign_in_at`.<br/>
        /// In order to specify the direction, you can use the `+/-` symbols prepended in the property to order by.<br/>
        /// For example, if you want users to be returned in descending order according to their `created_at` property, you can use `-created_at`.<br/>
        /// If you don&apos;t use `+` or `-`, then `+` is implied. We only support one `order_by` parameter, and if multiple `order_by` parameters are provided, we will only keep the first one. For example,<br/>
        /// if you pass `order_by=username&amp;order_by=created_at`, we will consider only the first `order_by` parameter, which is `username`. The `created_at` parameter will be ignored in this case.
        /// </remarks>
        /// </summary>
        [SpeakeasyMetadata("queryParam:style=form,explode=true,name=order_by")]
        public string? OrderBy { get; set; } = "-created_at";
    }
}