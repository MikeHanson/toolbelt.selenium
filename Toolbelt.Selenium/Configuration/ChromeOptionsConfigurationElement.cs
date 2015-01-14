using System;
using System.Configuration;

namespace Toolbelt.Selenium.Configuration
{
    public class ChromeOptionsConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("binaryLocation")]
        public string BinaryLocation
        {
            get { return (string)this["binaryLocation"]; }
            set { this["binaryLocation"] = value; }
        }

        [ConfigurationProperty("leaveBrowserRunning")]
        public bool LeaveBrowserRunning
        {
            get { return (bool)this["leaveBrowserRunning"]; }
            set { this["leaveBrowserRunning"] = value; }
        }

        [ConfigurationProperty("proxy")]
        public ProxyConfigurationElement Proxy
        {
            get { return (ProxyConfigurationElement)this["proxy"]; }
            set { this["proxy"] = value; }
        }

        [ConfigurationProperty("debuggerAddress")]
        public string DebuggerAddress
        {
            get { return (string)this["debuggerAddress"]; }
            set { this["debuggerAddress"] = value; }
        }

        [ConfigurationProperty("minidumpPath")]
        public string MinidumpPath
        {
            get { return (string)this["minidumpPath"]; }
            set { this["minidumpPath"] = value; }
        }

        [ConfigurationProperty("arguments")]
        public NameValueConfigurationCollection Arguments
        {
            get { return (NameValueConfigurationCollection)this["arguments"]; }
            set { this["arguments"] = value; }
        }

        [ConfigurationProperty("excludedArguments")]
        public NameValueConfigurationCollection ExcludedArguments
        {
            get { return (NameValueConfigurationCollection)this["excludedArguments"]; }
            set { this["excludedArguments"] = value; }
        }

        [ConfigurationProperty("extensionPaths")]
        public NameValueConfigurationCollection ExtensionPaths
        {
            get { return (NameValueConfigurationCollection)this["extensionPaths"]; }
            set { this["extensionPaths"] = value; }
        }

        [ConfigurationProperty("encodedExtensions")]
        public NameValueConfigurationCollection EncodedExtensions
        {
            get { return (NameValueConfigurationCollection)this["encodedExtensions"]; }
            set { this["encodedExtensions"] = value; }
        }

        [ConfigurationProperty("userProfilePreferences")]
        public NameValueConfigurationCollection UserProfilePreferences
        {
            get { return (NameValueConfigurationCollection)this["userProfilePreferences"]; }
            set { this["userProfilePreferences"] = value; }
        }

        [ConfigurationProperty("localStatePreferences")]
        public NameValueConfigurationCollection LocalStatePreferences
        {
            get { return (NameValueConfigurationCollection)this["localStatePreferences"]; }
            set { this["localStatePreferences"] = value; }
        }

        [ConfigurationProperty("additionalCapabilities")]
        public NameValueConfigurationCollection AdditionalCapabilities
        {
            get { return (NameValueConfigurationCollection)this["additionalCapabilities"]; }
            set { this["additionalCapabilities"] = value; }
        }
    }
}