using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;
using Toolbelt.Selenium.Configuration;

namespace Toolbelt.Selenium
{
    public abstract class SystemUnderTest<TMainPage>
        where TMainPage: Page, new()
    {
        private SystemUnderTestConfigSection configuration;
        private IWebDriver driver;
        private WaitHandler waitHandler;

        public TMainPage MainPage
        {
            get { return this.CurrentPage<TMainPage>(); }
        }

        public void Connect()
        {
            this.configuration = (SystemUnderTestConfigSection)ConfigurationManager.GetSection("systemUnderTest");
            this.driver = this.GetDriver();
            this.waitHandler = new WaitHandler(this.driver);
        }

        public void Disconnect()
        {
            this.driver.Quit();
            this.driver.Dispose();
        }

        public T CurrentPage<T>() where T: Page, new()
        {
            var page = new T();
            page.SetDriver(this.driver);
            return page;
        }

        public Page CurrentPage()
        {
            return new Page(this.driver);
        }

        public void Start()
        {
            this.driver.Navigate()
                .GoToUrl(this.configuration.Url);
        }

        public void Stop()
        {
            this.driver.Navigate()
                .GoToUrl("about:blank");
        }

        public WaitHandler Wait()
        {
            return this.waitHandler;
        }

        private IWebDriver GetDriver()
        {
            switch(this.configuration.BrowserName)
            {
                case BrowserName.Chrome:
                    return this.BuildChromeDriver();
                case BrowserName.FireFox:
                    return new FirefoxDriver();
                case BrowserName.Phantom:
                    return new PhantomJSDriver();
                case BrowserName.Safari:
                    return new SafariDriver();
                default:
                    return new InternetExplorerDriver();
            }
        }

        private IWebDriver BuildChromeDriver()
        {
            if(this.configuration.ChromeOptions == null)
            {
                return new ChromeDriver();
            }

            var chromeOptions = new ChromeOptions();

            var config = this.configuration.ChromeOptions;
            chromeOptions.BinaryLocation = config.BinaryLocation;
            chromeOptions.DebuggerAddress = config.DebuggerAddress;
            chromeOptions.LeaveBrowserRunning = config.LeaveBrowserRunning;
            if(config.Proxy != null)
            {
                chromeOptions.Proxy = config.Proxy.ToProxy();
            }

            if(config.AdditionalCapabilities != null && config.AdditionalCapabilities.Count > 0)
            {
                foreach(var name in config.AdditionalCapabilities.AllKeys)
                {
                    chromeOptions.AddAdditionalCapability(name, config.AdditionalCapabilities[name].Value);
                }
            }

            if(config.Arguments != null && config.Arguments.Count > 0)
            {
                foreach(var name in config.Arguments.AllKeys)
                {
                    chromeOptions.AddArgument(config.Arguments[name].Value);
                }
            }

            if (config.EncodedExtensions != null && config.EncodedExtensions.Count > 0)
            {
                foreach (var name in config.EncodedExtensions.AllKeys)
                {
                    chromeOptions.AddEncodedExtension(config.EncodedExtensions[name].Value);
                }
            }

            if (config.ExcludedArguments != null && config.ExcludedArguments.Count > 0)
            {
                foreach (var name in config.ExcludedArguments.AllKeys)
                {
                    chromeOptions.AddExcludedArgument(config.ExcludedArguments[name].Value);
                }
            }

            if (config.ExtensionPaths != null && config.ExtensionPaths.Count > 0)
            {
                foreach (var name in config.ExtensionPaths.AllKeys)
                {
                    chromeOptions.AddExtension(config.ExtensionPaths[name].Value);
                }
            }

            if (config.LocalStatePreferences != null && config.LocalStatePreferences.Count > 0)
            {
                foreach (var name in config.LocalStatePreferences.AllKeys)
                {
                    chromeOptions.AddLocalStatePreference(name, config.LocalStatePreferences[name].Value);
                }
            }

            if (config.UserProfilePreferences != null && config.UserProfilePreferences.Count > 0)
            {
                foreach (var name in config.UserProfilePreferences.AllKeys)
                {
                    chromeOptions.AddUserProfilePreference(name, config.UserProfilePreferences[name].Value);
                }
            }

            return new ChromeDriver(chromeOptions);
        }
    }
}