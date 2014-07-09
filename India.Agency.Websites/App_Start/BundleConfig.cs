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
            RegisterLayoutBundles(bundles);
            RegisterCommonBundles(bundles);
            RegisterCustomerBundles(bundles);
        }

        /// <summary>
        /// Bundles JavaScript and LESS files for layout.
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        public static void RegisterLayoutBundles(BundleCollection bundles)
        {
            bundles.AddAndInclude(
                "~/styles/layout",
                "~/Content/Bootstrap/CSS/bootstrap.css",
                "~/Content/Themes/icon.less",
                "~/Content/Themes/common.less",
                "~/Content/Themes/layout.less");

            bundles.Add(new ScriptBundle("~/scripts/headjs").Include(
                "~/Scripts/HeadJs/head.min.js",
                "~/Scripts/RespondJs/respond.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/layout").Include(
                "~/Scripts/jQuery/jQuery.js",
                "~/Scripts/Bootstrap/bootstrap.js",
                "~/Scripts/MomentJs/moment-langues.js",
                "~/Scripts/Namespace/namespace.js",
                "~/Scripts/extensions.js",
                "~/Scripts/core.js",
                "~/Areas/Customer/Resources/Home/layout.js"));
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
                "~/Content/Select2/select2.css",
                "~/Content/Themes/icon.less",
                "~/Content/Fanex.Grid/Fanex.Grid.css",
                "~/Content/Fanex.Grid/Fanex.Pagination.css",
                "~/Content/Themes/common.less",
                "~/Content/Themes/content.less");

            bundles.AddAndInclude(
                "~/styles/dashboard",
                "~/Areas/Customer/Resources/Dashboard/dashboard.less");

            bundles.Add(new ScriptBundle("~/scripts/common").Include(
                "~/Scripts/jQuery/jQuery.js",
                "~/Scripts/Bootstrap/bootstrap.js",
                "~/Scripts/Select2/select2.js",
                "~/Scripts/MomentJs/moment-langues.js",
                "~/Scripts/NumeralJs/numeral.js",
                "~/Scripts/NiceScroll/jquery.nicescroll.min.js",
                "~/Scripts/Mutate/mutate.events.js",
                "~/Scripts/Mutate/mutate.min.js",
                "~/Scripts/Fanex.Grid/Fanex.Grid.js",
                "~/Scripts/Fanex.Grid/Fanex.Pagination.js",
                "~/Scripts/Namespace/namespace.js",
                "~/Scripts/extensions.js",
                "~/Scripts/core.js"));
        }

        /// <summary>
        /// Bundles JavaScript and LESS files for Customer area.
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        public static void RegisterCustomerBundles(BundleCollection bundles)
        {
            bundles.AddAndInclude(
                "~/styles/dashboard",
                "~/Areas/Customer/Resources/Dashboard/dashboard.less");

            bundles.Add(new ScriptBundle("~/scripts/customerList").Include(
                "~/Areas/Customer/Resources/CustomerList/customerList.js"));
        }
    }
}