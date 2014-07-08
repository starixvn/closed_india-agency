// --------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Websites
{
    using System.Web.Optimization;

    /// <summary>
    /// Bundle Configuration.
    /// </summary>
    public static class BundleConfig
    {
        /// <summary>
        /// Registers the JavaScript, LESS and CSS bundles.
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterCommonBundles(bundles);
        }

        /// <summary>
        /// Bundles common JavaScript and LESS files.
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        public static void RegisterCommonBundles(BundleCollection bundles)
        {
            bundles.AddAndInclude(
                "~/styles/common",
                "~/Content/Bootstrap/CSS/bootstrap.css",
                "~/Content/Fanex.Grid/Fanex.Grid.css",
                "~/Content/Fanex.Grid/Fanex.Pagination.css",
                "~/Content/Themes/custom.less",
                "~/Content/Themes/style.less");

            bundles.AddAndInclude(
                "~/styles/dashboard",
                "~/Areas/Main/Resources/Home/dashboard.less");

            bundles.Add(new ScriptBundle("~/scripts/headjs").Include(
                "~/Scripts/HeadJs/head.min.js",
                "~/Scripts/RespondJs/respond.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/common").Include(
                "~/Scripts/jQuery/jQuery.js",
                "~/Scripts/Bootstrap/bootstrap.js",
                "~/Scripts/Fanex.Grid/Fanex.Grid.js",
                "~/Scripts/Fanex.Grid/Fanex.Pagination.js"));
        }
    }
}