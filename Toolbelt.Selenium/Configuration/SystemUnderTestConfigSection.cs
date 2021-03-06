﻿using System;
using System.Configuration;

namespace Toolbelt.Selenium.Configuration
{
    public class SystemUnderTestConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("browserName", DefaultValue = "InternetExplorer", IsRequired = true)]
        public BrowserName BrowserName
        {
            get { return (BrowserName)this["browserName"]; }
            set { this["browserName"] = value; }
        }

        [ConfigurationProperty("url", DefaultValue = "http://testpossessed.com", IsRequired = true)]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("chromeOptions")]
        public ChromeOptionsConfigurationElement ChromeOptions
        {
            get { return (ChromeOptionsConfigurationElement)this["chromeOptions"]; }
        }
    }
}