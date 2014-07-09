// --------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Customer.Controllers
{
    using System.Web.Mvc;
    using India.Agency.Core.ViewModels;
    using India.Agency.Core.Web;

    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        /// <summary>
        /// Gets Index page.
        /// </summary>
        /// <param name="language">Language identification.</param>
        /// <returns>Return Index View.</returns>
        public ActionResult Index(string language = null)
        {
            language = language ?? DropdownValues.DefaultLanguage;
            this.Language = language;
            ViewBag.CurrentUrl = null;

            return View("~/Areas/Customer/Views/Home/Index.cshtml");
        }
    }
}