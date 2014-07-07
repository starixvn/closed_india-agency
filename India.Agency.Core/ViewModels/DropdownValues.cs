// --------------------------------------------------------------------------
// <copyright file="DropdownValues.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Configure values of common drop-down lists.
    /// </summary>
    public static class DropdownValues
    {
        private static readonly List<SelectListItem> SupportedLanguages = new List<SelectListItem>
        {
            new SelectListItem { Text = "English", Value = "en-US" },
            new SelectListItem { Text = "हिन्दी", Value = "hi-IN" }
        };

        public static string DefaultLanguage
        {
            get
            {
                return SupportedLanguages.First().Value;
            }
        }

        public static IList<SelectListItem> Languages
        {
            get
            {
                return SupportedLanguages;
            }
        }
    }
}