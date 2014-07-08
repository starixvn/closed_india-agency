// --------------------------------------------------------------------------
// <copyright file="Admin.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Models
{
    using System;

    /// <summary>
    /// CSD/IT sign-in information.
    /// </summary>
    [Serializable]
    public class Admin
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string UserRole { get; set; }
    }
}