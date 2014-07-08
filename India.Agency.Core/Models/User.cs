// --------------------------------------------------------------------------
// <copyright file="User.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Models
{
    /// <summary>
    /// User model.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public byte Status { get; set; }
    }
}