using System;
using OpenQA.Selenium;

namespace Toolbelt.Selenium
{
    public class Page : FindContext
    {
        protected IWebDriver WebDriver { get; private set; }
        
        protected Page(){}

        internal Page(IWebDriver driver)
        {
            this.SetDriver(driver);
        }

        internal void SetDriver(IWebDriver driver)
        {
            this.WebDriver = driver;
            this.SetFindRoot(this.WebDriver);
        }

        public string Title
        {
            get { return this.WebDriver.Title; }
        }

        public string Location
        {
            get { return this.WebDriver.Url; }
        }
    }
}