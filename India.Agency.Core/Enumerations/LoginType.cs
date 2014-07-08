// --------------------------------------------------------------------------
// <copyright file="LoginType.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.8">Created.</change>
// </history>

namespace India.Agency.Core.Enumerations
{
    /// <summary>
    /// Identifies login type: redirect from India CM or directly from agent site.
    /// </summary>
    public enum LoginType
    {
        /// <summary>
        /// Login from admin site.
        /// </summary>
        AdminSite,

        /// <summary>
        /// Login from agent site.
        /// </summary>
        AgentSite
    }
}