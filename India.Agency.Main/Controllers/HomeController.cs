// --------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Main.Controllers
{
    using System.Web.Mvc;
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
        /// <returns>Return Index View.</returns>
        public ActionResult Index()
        {
            return View("~/Areas/Main/Views/Home/Index.cshtml");
        }

        /// <summary>
        /// Gets dashboard page.
        /// </summary>
        /// <returns>Return dashboard View.</returns>
        public ActionResult Dashboard()
        {
            return View("~/Areas/Main/Views/Home/Dashboard.cshtml");
        }
    }
}