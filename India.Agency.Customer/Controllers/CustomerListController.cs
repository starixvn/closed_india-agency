// --------------------------------------------------------------------------
// <copyright file="CustomerListController.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.9">Created.</change>
// </history>

namespace India.Agency.Customer.Controllers
{
    using System.Web.Mvc;
    using India.Agency.Core.Web;

    /// <summary>
    /// Customer list controller.
    /// </summary>
    public class CustomerListController : BaseController
    {
        public CustomerListController()
        {
        }

        /// <summary>
        /// Gets Dashboard view.
        /// </summary>
        /// <returns>Return Dashboard View.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
