using System;
using OpenQA.Selenium;

namespace Toolbelt.Selenium
{
    public abstract class Element : FindContext
    {
        public string Class
        {
            get { return this.WebElement.GetAttribute("class"); }
        }

        public string Id
        {
            get { return this.WebElement.GetAttribute("id"); }
        }

        public bool IsDisplayed
        {
            get { return this.WebElement.Displayed; }
        }

        public string Name
        {
            get { return this.WebElement.GetAttribute("name"); }
        }

        public abstract string Tag { get; }

        public string Text
        {
            get { return this.WebElement.Text; }
        }

        protected IWebElement WebElement { get; set; }

        internal virtual Element SetElement(IWebElement element)
        {
            if(string.Compare(element.TagName, this.Tag, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                throw (new TagMismatchException(this.GetType()
                                                    .Name,
                                                element.TagName,
                                                this.Tag));
            }
            this.WebElement = element;
            this.SetFindRoot(this.WebElement);
            return this;
        }

        public bool IsStale()
        {
            try
            {
                var tagName = this.WebElement.TagName;
                return false;
            }
            catch(StaleElementReferenceException)
            {
                return true;
            }
        }
    }
}