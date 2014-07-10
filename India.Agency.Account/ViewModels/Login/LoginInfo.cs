// --------------------------------------------------------------------------
// <copyright file="LoginInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.10">Created.</change>
// </history>

namespace India.Agency.Account.ViewModels.Login
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using India.Agency.Core.ViewModels;

    /// <summary>
    /// Login information view model.
    /// </summary>
    public class LoginInfo
    {
        public LoginInfo()
        {
            this.Languages = DropdownValues.Languages;
            this.SelectedLanguage = DropdownValues.DefaultLanguage;
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Captchar { get; set; }

        public string SelectedLanguage { get; set; }

        public List<SelectListItem> Languages { get; private set; }
    }
}