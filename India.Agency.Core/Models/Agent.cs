// --------------------------------------------------------------------------
// <copyright file="Agent.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Models
{
    using System;
    using India.Agency.Core.Enumerations;
    using India.Agency.Core.Utilities;

    /// <summary>
    /// Agent model.
    /// </summary>
    [Serializable]
    public class Agent
    {
        public int AgentId { get; set; }

        public string UserName { get; set; }

        public short AgentLevel { get; set; }

        public short NumberOfLevel { get; set; }

        public bool IsFirstLogin { get; set; }

        public DateTime PwdExpiry { get; set; }

        public DateTime LastChangedPwdDate { get; set; }

        public DateTime LastLoggedTime { get; set; }

        public bool IsLowestLevel
        {
            get
            {
                return AgentLevel == NumberOfLevel;
            }
        }

        public PasswordStatus PasswordStatus
        {
            get
            {
                return PasswordRule.GetPasswordStatus(this, LastLoggedTime);
            }
        }
    }
}