// <copyright file="IOktaClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    /// <summary>
    /// A client that communicates with the Okta Management API.
    /// </summary>
    public interface IOktaClient : IBaseOktaClient
    {
        /// <summary>
        /// Gets a <see cref="IUsersClient">UsersClient</see> that interacts with the Okta Users API.
        /// </summary>
        /// <value>
        /// A <see cref="IUsersClient">UsersClient</see> that interacts with the Okta Users API.
        /// </value>
        IUsersClient Users { get; }

        /// <summary>
        /// Gets a <see cref="IApplicationsClient">ApplicationsClient</see> that interacts with the Okta Applications API.
        /// </summary>
        /// <value>
        /// A <see cref="IApplicationsClient">ApplicationsClient</see> that interacts with the Okta Applications API.
        /// </value>
        IApplicationsClient Applications { get; }

        /// <summary>
        /// Gets a <see cref="ISessionsClient">SessionsClient</see> that interacts with the Okta Sessions API.
        /// </summary>i
        /// <value>
        /// A <see cref="ISessionsClient">SessionsClient</see> that interacts with the Okta Sessions API.
        /// </value>
        ISessionsClient Sessions { get; }

        /// <summary>
        /// Gets a <see cref="ILogsClient">LogsClient</see> that interacts with the Okta Logs API.
        /// </summary>i
        /// <value>
        /// A <see cref="ILogsClient">LogsClient</see> that interacts with the Okta Logs API.
        /// </value>
        ILogsClient Logs { get; }

        /// <summary>
        /// Gets a <see cref="IUserFactorsClient">UserFactorsClient</see> that interacts with the Okta Factors API.
        /// </summary>
        /// <value>
        /// A <see cref="IUserFactorsClient">UserFactorsClient</see> that interacts with the Okta Factors API.
        /// </value>
        IUserFactorsClient UserFactors { get; }

        /// <summary>
        /// Gets a <see cref="IGroupsClient">GroupsClient</see> that interacts with the Okta Groups API.
        /// </summary>
        /// <value>
        /// A <see cref="IGroupsClient">GroupsClient</see> that interacts with the Okta Groups API.
        /// </value>
        IGroupsClient Groups { get; }
    }
}
