// --------------------------------------------------------------------------
// <copyright file="AccountType.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Enumerations
{
    /// <summary>
    /// List of account types of India Agency site.
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// Used in Authorization.
        /// </summary>
        All,

        /// <summary>
        /// Admin of the system.
        /// </summary>
        Admin,

        /// <summary>
        /// CSD or IT login from India CMS.
        /// </summary>
        CSD_IT,

        /// <summary>
        /// The agent of any level.
        /// </summary>
        Agent,

        /// <summary>
        /// The agent who belongs to level 0.
        /// </summary>
        AgentLevel0,

        /// <summary>
        /// The agent who belongs to level 1.
        /// </summary>
        AgentLevel1,

        /// <summary>
        /// The agent who belongs to level k.
        /// </summary>
        AgentLevelk,

        /// <summary>
        /// The agent at the lowest level.
        /// </summary>
        AgentLeveln,

        /// <summary>
        /// Sub-account of an agent.
        /// </summary>
        SubAccount
    }
}