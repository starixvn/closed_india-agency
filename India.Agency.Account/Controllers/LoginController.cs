// --------------------------------------------------------------------------
// <copyright file="LoginController.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.10">Created.</change>
// </history>

namespace India.Agency.Account.Controllers
{
    using System.Web.Mvc;
    using India.Agency.Account.ViewModels.Login;
    using India.Agency.Core.Web;

    /// <summary>
    /// Login controller.
    /// </summary>
    public class LoginController : BaseController
    {
        public LoginController()
        {
        }

        /// <summary>
        /// Goes to Login page.
        /// </summary>
        /// <returns>Return Login View.</returns>
        public ActionResult Index(LoginInfo loginInfo = null)
        {
            loginInfo = loginInfo ?? new LoginInfo();

            return View(loginInfo);
        }
    }
}