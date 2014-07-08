// --------------------------------------------------------------------------
// <copyright file="InternalLogin.cs" company="Nexcel Solutions Vietnam">
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

    /// <summary>
    /// Internal login information.
    /// </summary>
    [Serializable]
    public class InternalLogin
    {
        public InternalLogin()
        {
            Timeout = DateTime.Now.AddMinutes(3);
        }

        public DateTime Timeout { get; private set; }

        public AccountType LoginAccountType { get; set; }

        public int LoginUserId { get; set; }

        public string LoginUserName { get; set; }

        public LoginType LoginType { get; set; }

        public int OnLoginUserId { get; set; }

        public string Language { get; set; }

        public bool IsExpired
        {
            get
            {
                return DateTime.Now > Timeout;
            }
        }
    }
}