// --------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.8">Created.</change>
// </history>

namespace India.Agency.Core.Web
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using India.Agency.Core.Configurations;
    using India.Agency.Core.Utilities;
    using India.Agency.Core.ViewModels;

    /// <summary>
    /// This class override OnActionExecuting to check authentication, authorization, duplicated login.
    /// All non-anonymous controller MUST inherit from this base controller.
    /// </summary>
    public class BaseController : Controller
    {
        protected static ICurrentSession CurrentSession
        {
            get
            {
                return SessionManager.CurrentSession;
            }
        }

        protected string Language
        {
            get
            {
                string language = DropdownValues.DefaultLanguage;

                // Current session is only existed when user is authenticated.
                if (CurrentSession != null)
                {
                    language = CurrentSession.Language;
                }
                else
                {
                    HttpCookie languageCookie = Request.Cookies[Constants.AppCookieLanguage];

                    if (languageCookie != null)
                    {
                        string cookieValue = languageCookie.Value;

                        if (DropdownValues.Languages.Where(x => x.Value == cookieValue).Any())
                        {
                            language = cookieValue;
                        }
                    }
                }

                return language;
            }

            set
            {
                string language = value;
                SelectListItem selectedLanguage = DropdownValues.Languages.Where(x => x.Value == value).FirstOrDefault();
                HttpCookie languageCookie = null;

                language = selectedLanguage != null ? selectedLanguage.Value : DropdownValues.DefaultLanguage;

                if (!string.IsNullOrEmpty(language))
                {
                    if (CurrentSession != null)
                    {
                        CurrentSession.Language = language;
                    }

                    languageCookie = new HttpCookie(Constants.AppCookieLanguage, language);
                    languageCookie.Expires = DateTime.Now.AddDays(30);
                    Response.SetCookie(languageCookie);
                }
            }
        }

        /// <summary>
        /// Invokes the action in the current controller context.
        /// </summary>
        protected override void ExecuteCore()
        {
            LanguageManager.Language = Language;
            base.ExecuteCore();
        }
    }
}