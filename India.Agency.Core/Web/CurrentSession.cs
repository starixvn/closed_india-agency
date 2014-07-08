// --------------------------------------------------------------------------
// <copyright file="CurrentSession.cs" company="Nexcel Solutions Vietnam">
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
    using India.Agency.Core.Utilities;

    /// <summary>
    ///  It contains all properties of an authenticated user.
    ///  The implementation is applied when user config is state server mode.
    /// </summary>
    [Serializable]
    public class CurrentSession : ICurrentSession
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentSession"/> class.
        /// Agent direct login.
        /// </summary>
        /// <param name="agent">The agent information.</param>
        /// <param name="checkinOnUserId">The check-in on user identifier.</param>
        /// <param name="language">The language.</param>
        public CurrentSession(Agent agent, int checkinOnUserId, string language = LanguageManager.UsLanguageCode)
            : this(agent.AgentId, agent.UserName, AccountType.Agent, LoginType.AgentSite, checkinOnUserId, language)
        {
            Agent = agent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentSession" /> class.
        /// Agent indirect login.
        /// </summary>
        /// <param name="agent">The agent information.</param>
        /// <param name="internalLogin">The internal login information.</param>
        public CurrentSession(Agent agent, InternalLogin internalLogin)
            : this(
            internalLogin.LoginUserId,
            internalLogin.LoginUserName,
            internalLogin.LoginAccountType,
            internalLogin.LoginType,
            internalLogin.OnLoginUserId,
            internalLogin.Language)
        {
            Agent = agent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentSession"/> class.
        /// CSD/IT direct login.
        /// </summary>
        /// <param name="admin">The admin information.</param>
        /// <param name="checkinOnUserId">The check-in on user identifier.</param>
        /// <param name="language">The language.</param>
        public CurrentSession(Admin admin, int checkinOnUserId, string language = LanguageManager.UsLanguageCode)
            : this(admin.UserId, admin.Username, AccountType.CSD_IT, LoginType.AdminSite, checkinOnUserId, language)
        {
            Admin = admin;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentSession"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <param name="accountType">Type of the account.</param>
        /// <param name="loginType">Type of the login.</param>
        /// <param name="checkinOnUserId">The check-in on user identifier.</param>
        /// <param name="language">The language.</param>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when the login account is not a CSD/IT or agent.
        /// </exception>
        protected CurrentSession(int userId, string username, AccountType accountType, LoginType loginType, int checkinOnUserId, string language)
        {
            if (accountType != AccountType.CSD_IT && accountType != AccountType.Agent)
            {
                throw new InvalidOperationException(string.Format("Invalid account type {0}", accountType));
            }

            UserId = userId;
            Username = username;
            AccountType = accountType;
            LoginType = loginType;
            OnUserId = checkinOnUserId;
            Language = language;
        }

        /// <summary>
        /// Gets the admin account information after login.
        /// </summary>
        /// <value>
        /// The admin information.
        /// </value>
        public Admin Admin { get; private set; }

        /// <summary>
        /// Gets the agent account information after login or internal login.
        /// </summary>
        /// <value>
        /// The agent information.
        /// </value>
        public Agent Agent { get; private set; }

        /// <summary>
        /// Gets the type of the account who created session.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public AccountType AccountType { get; private set; }

        /// <summary>
        /// Gets the login type.
        /// </summary>
        /// <value>
        /// The type of the login.
        /// </value>
        public LoginType LoginType { get; private set; }

        public string Language { get; set; }

        public int UserId { get; private set; }

        public string Username { get; private set; }

        public int OnUserId { get; private set; }
    }
}