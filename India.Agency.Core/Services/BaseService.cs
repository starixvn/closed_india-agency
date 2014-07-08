// --------------------------------------------------------------------------
// <copyright file="BaseService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Services
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Fanex.Data.Repository;
    using India.Agency.Core.Criteria;
    using India.Agency.Core.Models;
    using India.Agency.Core.Utilities;

    /// <summary>
    /// Base service.
    /// </summary>
    public class BaseService
    {
        private const string BalanceUpCacheKey = "India.Agency.BalanceUpDay";
        private static DynamicRepository _repository = new DynamicRepository();

        public static DynamicRepository Repository
        {
            get
            {
                return _repository;
            }
        }

        /// <summary>
        /// Gets the balance up day.
        /// </summary>
        /// <returns>BalanceUp object contains balance up date and move bets day.</returns>
        public BalanceUp GetBalanceUpDay()
        {
            BalanceUp balanceUp = CacheManager.Get<BalanceUp>(BalanceUpCacheKey);

            if (balanceUp == null)
            {
                var criteria = new GetBalanceUpDayCriteria();

                balanceUp = Repository.Get<BalanceUp>(criteria);
                CacheManager.Set<BalanceUp>(BalanceUpCacheKey, balanceUp, new TimeSpan(0, 0, 5, 0));
            }

            return balanceUp;
        }
    }
}