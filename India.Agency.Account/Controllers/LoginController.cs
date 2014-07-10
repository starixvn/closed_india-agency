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
        [HttpGet]
        public ActionResult Index(LoginInfo loginInfo = null)
        {
            if (loginInfo != null)
            {
                if (this.Language != loginInfo.SelectedLanguage)
                {
                    this.Language = loginInfo.SelectedLanguage;
                }
            }
            else
            {
                loginInfo = new LoginInfo();
                loginInfo.SelectedLanguage = this.Language;
            }

            return View(loginInfo);
        }
    }
}