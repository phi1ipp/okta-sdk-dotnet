﻿// <copyright file="GroupClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Provides methods that manipulate Group resources, by communicating with the Okta Groups API.
    /// </summary>
    public sealed partial class GroupClient : OktaClient, IGroupClient, IAsyncEnumerable<Group>
    {
        /// <inheritdoc/>
        public IAsyncEnumerator<Group> GetEnumerator() => ListGroups().GetEnumerator();
    }
}