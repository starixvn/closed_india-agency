// --------------------------------------------------------------------------
// <copyright file="GetBalanceUpDayCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created</change>
// </history>

namespace India.Agency.Core.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Getting balance up daye and move bets day.
    /// </summary>
    public class GetBalanceUpDayCriteria : CriteriaBase
    {
        /// <summary>
        /// Gets the setting key.
        /// </summary>
        /// <returns>The setting key.</returns>
        public override string GetSettingKey()
        {
            return "SelBalanceUpDay";
        }

        /// <summary>
        /// Determines whether this criteria is valid.
        /// </summary>
        /// <returns>Whether this criteria is valid or not.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}