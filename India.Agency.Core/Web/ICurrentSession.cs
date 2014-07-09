// --------------------------------------------------------------------------
// <copyright file="ICurrentSession.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Web
{
    using System;
    using India.Agency.Core.Enumerations;
    using India.Agency.Core.Models;

    public interface ICurrentSession
    {
        Admin Admin { get; }

        Agent Agent { get; }

        AccountType AccountType { get; }

        LoginType LoginType { get; }

        int UserId { get; }

        string Username { get; }

        string Language { get; set; }

        int OnUserId { get; }

        Uri CurrentUrl { get; set; }
    }
}