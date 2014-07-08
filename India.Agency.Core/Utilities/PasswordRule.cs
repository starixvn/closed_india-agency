// --------------------------------------------------------------------------
// <copyright file="PasswordRule.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Utilities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using India.Agency.Core.Enumerations;
    using India.Agency.Core.Models;
    using India.Agency.Resources;

    /// <summary>
    /// Password rules: Password must be at least 8 characters (maximum = 24 characters)
    /// without white space and contain at least 3 of the following:
    /// Uppercase letter [A-Z].
    /// Lowercase leader [a-z].
    /// Numeric [0-9].
    /// Special character (!,@,#,etc..).
    /// </summary>
    [Serializable]
    public static class PasswordRule
    {
        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules", "SP2100:CodeLineMustNotBeLongerThan", Justification = "Reviewed")]
        public const string PasswordPattern = @"(?=^.{8,24}$)(?!.*\s)(?=^[\x00-\x7F]+$)((?=.*\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*";

        /// <summary>
        /// Duration which a password will be available.
        /// </summary>
        public const int AvailableDuration = 60;

        /// <summary>
        /// Gets the password status.
        /// </summary>
        /// <param name="agent">The agent information.</param>
        /// <returns>Password status of passed agent.</returns>
        public static PasswordStatus GetPasswordStatus(Agent agent)
        {
            return GetPasswordStatus(agent, null);
        }

        /// <summary>
        /// Gets the password status.
        /// </summary>
        /// <param name="agent">The agent information.</param>
        /// <param name="lastLoginTime">The last login time.</param>
        /// <returns>Password status.</returns>
        public static PasswordStatus GetPasswordStatus(Agent agent, DateTime? lastLoginTime)
        {
            DateTime today = DateTime.Today;

            if (agent.IsFirstLogin)
            {
                return PasswordStatus.FirstLogin;
            }

            if (today > agent.PwdExpiry)
            {
                return PasswordStatus.Expired;
            }

            if (lastLoginTime != null)
            {
                // User will be notified 3 times: 2 weeks, 1 week, 1 day in advance of password expiration date.
                DateTime lastLoginTimeValue = lastLoginTime.Value;
                double availableDays = agent.PwdExpiry.Subtract(today).TotalDays;
                double loginTotalDays = agent.PwdExpiry.Subtract(lastLoginTimeValue).TotalDays;

                if (availableDays <= 14)
                {
                    if (availableDays > 7)
                    {
                        if (loginTotalDays > 14)
                        {
                            return PasswordStatus.Alert;
                        }
                    }
                    else if (availableDays > 1)
                    {
                        if (loginTotalDays > 7)
                        {
                            return PasswordStatus.Alert;
                        }
                    }
                    else
                    {
                        if (loginTotalDays > 1)
                        {
                            return PasswordStatus.Alert;
                        }
                    }
                }
            }

            return PasswordStatus.Normal;
        }

        /// <summary>
        /// Gets the status message.
        /// </summary>
        /// <param name="agentInfo">The agent information.</param>
        /// <returns>Message associates with the password status.</returns>
        public static string GetStatusMessage(Agent agentInfo)
        {
            PasswordStatus passwordStatus = GetPasswordStatus(agentInfo);

            return GetStatusMessage(passwordStatus, agentInfo.PwdExpiry);
        }

        /// <summary>
        /// Gets the status message.
        /// </summary>
        /// <param name="passwordStatus">The password status.</param>
        /// <param name="pwdExpiredDate">The password expired date.</param>
        /// <returns>Returns message.</returns>
        public static string GetStatusMessage(PasswordStatus passwordStatus, DateTime pwdExpiredDate)
        {
            var message = string.Empty;

            switch (passwordStatus)
            {
                case PasswordStatus.FirstLogin:
                    message = Messages.PasswordFirstUse;
                    break;

                case PasswordStatus.Expired:
                    message = string.Format(Messages.PasswordExpired, pwdExpiredDate.ToShortDateString());
                    break;

                case PasswordStatus.Alert:
                    message = string.Format(Messages.PasswordWillExpired, pwdExpiredDate.ToShortDateString());
                    break;
            }

            return message;
        }
    }
}