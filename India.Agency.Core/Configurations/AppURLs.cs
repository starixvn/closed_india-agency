// --------------------------------------------------------------------------
// <copyright file="AppUrls.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.7.7">Created.</change>
// </history>

namespace India.Agency.Core.Configurations
{
    using System.Configuration;

    /// <summary>
    /// Custom URLs for application.
    /// </summary>
    public class AppUrls : ConfigurationSection
    {
        private static AppUrls settings = ConfigurationManager.GetSection("IndiaAgency.AppURLs") as AppUrls;

        public static AppUrls Urls
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty("AccessDenied", IsRequired = true)]
        public string AccessDenied
        {
            get { return (string)this["AccessDenied"]; }
            set { this["AccessDenied"] = value; }
        }

        [ConfigurationProperty("Error", IsRequired = true)]
        public string Error
        {
            get { return (string)this["Error"]; }
            set { this["Error"] = value; }
        }

        [ConfigurationProperty("Unauthorized", IsRequired = true)]
        public string Unauthorized
        {
            get { return (string)this["Unauthorized"]; }
            set { this["Unauthorized"] = value; }
        }

        [ConfigurationProperty("UnderMaintenance", IsRequired = true)]
        public string UnderMaintenance
        {
            get { return (string)this["UnderMaintenance"]; }
            set { this["UnderMaintenance"] = value; }
        }

        [ConfigurationProperty("SignOut", IsRequired = true)]
        public string SignOut
        {
            get { return (string)this["SignOut"]; }
            set { this["SignOut"] = value; }
        }
    }
}