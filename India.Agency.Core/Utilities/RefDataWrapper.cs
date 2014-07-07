// --------------------------------------------------------------------------
// <copyright file="RefDataWrapper.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Utilities
{
    using RemotingRef;

    /// <summary>
    /// Wraps RefData with extend functions.
    /// </summary>
    public static class RefDataWrapper
    {
        private static string RefLanguageCode
        {
            get
            {
                var languageCode = LanguageManager.Language;

                switch (languageCode)
                {
                    case "en-US": return "en"; // English.
                    case "zh-TW": return "ch"; // Traditional Chinese.
                    case "zh-CN": return "cs"; // Simplified Chinese.
                    case "ja-JP": return "jp"; // Japanese.
                    case "th-TH": return "th"; // Thai.
                    case "hi-IN": return "hi"; // Hindi.
                    default: return "en";
                }
            }
        }

        /// <summary>
        /// Gets bet type name.
        /// </summary>
        /// <param name="betTypeId">Bet type ID.</param>
        /// <returns>Bet type name.</returns>
        public static string GetBetType(object betTypeId)
        {
            return GetBetType(betTypeId, null);
        }

        /// <summary>
        /// Gets bet type name by bet type ID and bet ID.
        /// </summary>
        /// <param name="betTypeId">Bet type ID.</param>
        /// <param name="betId">Bet ID value.</param>
        /// <returns>Bet type name.</returns>
        public static string GetBetType(object betTypeId, object betId)
        {
            // resourceId remove first character
            string resourceId = string.Empty;
            if (betId != null && betId.ToString().Length > 1)
            {
                resourceId = betId.ToString().Substring(1);
            }

            return RefData.GetBetTypeName(betTypeId.ToString(), RefLanguageCode, string.Empty, resourceId);
        }

        /// <summary>
        /// Gets sport name by ID.
        /// </summary>
        /// <param name="sportId">Sport ID value.</param>
        /// <returns>Sport name.</returns>
        public static string GetSportName(object sportId)
        {
            return RefData.GetSportName(sportId.ToString(), RefLanguageCode, string.Empty);
        }

        /// <summary>
        /// Gets team name.
        /// </summary>
        /// <param name="teamId">Team ID value.</param>
        /// <returns>Team name.</returns>
        public static string GetTeamName(object teamId)
        {
            return RefData.GetTeamName(teamId.ToString(), RefLanguageCode, string.Empty);
        }

        /// <summary>
        /// Gets league name by ID.
        /// </summary>
        /// <param name="leagueId">League ID.</param>
        /// <returns>League name.</returns>
        public static string GetLeagueName(object leagueId)
        {
            return RefData.GetLeagueName(leagueId.ToString(), RefLanguageCode, string.Empty);
        }

        /// <summary>
        /// Gets odd type name.
        /// </summary>
        /// <param name="oddsType">Odd type ID.</param>
        /// <returns>Odd type name.</returns>
        public static string GetOddsTypeName(object oddsType)
        {
            return RefData.GetOddsTypeName(oddsType.ToString(), RefLanguageCode);
        }

        /// <summary>
        /// Gets the name of the country.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The country name.</returns>
        public static string GetCountryName(string countryCode)
        {
            return RefData.GetCountryName(countryCode, RefLanguageCode);
        }
    }
}