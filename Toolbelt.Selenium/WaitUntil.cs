using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Toolbelt.Selenium
{
    public class WaitUntil
    {
        private const int DefaultWaitTimeout = 5;
        private readonly IWebDriver driver;

        public WaitUntil(IWebDriver driver)
        {
            this.driver = driver;
        }

        public T ExistsById<T>(string id, double timeoutSeconds = DefaultWaitTimeout)
            where T: Element, new()
        {
            return this.Wait<T>(ExpectedConditions.ElementExists(By.Id(id)), timeoutSeconds);
        }

        public T ExistsByName<T>(string name, double timeoutSeconds = DefaultWaitTimeout)
            where T: Element, new()
        {
            return this.Wait<T>(ExpectedConditions.ElementExists(By.Name(name)), timeoutSeconds);
        }

        public T ExistsByXPath<T>(string xpath, double timeoutSeconds = DefaultWaitTimeout)
            where T: Element, new()
        {
            return this.Wait<T>(ExpectedConditions.ElementExists(By.XPath(xpath)), timeoutSeconds);
        }

        public bool NotExistsById(string id, double timeoutSeconds = DefaultWaitTimeout)
        {
            return this.WaitUntilNotPresent(By.Id(id), timeoutSeconds);
        }

        public bool NotExistsByName(string name, double timeoutSeconds = DefaultWaitTimeout)
        {
            return this.WaitUntilNotPresent(By.Name(name), timeoutSeconds);
        }

        public bool NotExistsByXPath(string xpath, double timeoutSeconds = DefaultWaitTimeout)
        {
            return this.WaitUntilNotPresent(By.XPath(xpath), timeoutSeconds);
        }

        public bool TitleContains(string title, double timeoutSeconds = DefaultWaitTimeout)
        {
            return this.Wait(ExpectedConditions.TitleContains(title), timeoutSeconds);
        }

        public bool TitleIs(string title, double timeoutSeconds = DefaultWaitTimeout)
        {
            return this.Wait(ExpectedConditions.TitleIs(title), timeoutSeconds);
        }

        public T VisibleById<T>(string id, double timeoutSeconds = DefaultWaitTimeout)
            where T: Element, new()
        {
            return this.Wait<T>(ExpectedConditions.ElementIsVisible(By.Id(id)), timeoutSeconds);
        }

        public T VisibleByName<T>(string name, double timeoutSeconds = DefaultWaitTimeout)
            where T: Element, new()
        {
            return this.Wait<T>(ExpectedConditions.ElementIsVisible(By.Name(name)), timeoutSeconds);
        }

        private bool Wait(Func<IWebDriver, bool> condition, double timeoutSeconds)
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(condition);
        }

        private T Wait<T>(Func<IWebDriver, IWebElement> condition, double timeoutSeconds)
            where T: Element, new()
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeoutSeconds));
            var element = wait.Until(condition);
            var isValidElement = false;
            while(!isValidElement)
            {
                try
                {
                    var tag = element.TagName;
                    isValidElement = true;
                }
                catch(StaleElementReferenceException)
                {
                    element = wait.Until(condition);
                }
            }

            var result = new T();
            result.SetElement(element);
            return result;
        }

        private bool WaitUntilNotPresent(By matchBy, double timeoutSeconds = DefaultWaitTimeout)
        {
            var endTime = DateTime.Now.AddSeconds(timeoutSeconds);
            while(DateTime.Now < endTime)
            {
                try
                {
                    this.driver.FindElement(matchBy);
                }
                catch(NoSuchElementException)
                {
                    return true;
                }
            }

            return false;
        }
    }
}