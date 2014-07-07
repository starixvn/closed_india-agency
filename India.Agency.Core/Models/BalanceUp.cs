// --------------------------------------------------------------------------
// <copyright file="BalanceUp.cs" company="Nexcel Solutions Vietnam">
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
    /// Balance up day model.
    /// </summary>
    [Serializable]
    public class BalanceUp
    {
        public DateTime BalanceUpDay { get; set; }

        public DateTime MoveBetsDay { get; set; }
    }
}