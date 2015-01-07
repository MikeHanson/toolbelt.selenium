using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;

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
                    return new ChromeDriver();
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
    }
}