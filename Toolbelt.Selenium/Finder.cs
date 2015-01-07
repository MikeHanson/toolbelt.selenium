using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Toolbelt.Selenium.Elements;

namespace Toolbelt.Selenium
{
    public class Finder
    {
        private readonly ISearchContext root;

        internal Finder(ISearchContext root)
        {
            this.root = root;
        }

        public IEnumerable<T> AllByCssSelector<T>(string cssSelector) where T: Element, new()
        {
            return this.FindAll<T>(By.CssSelector(cssSelector));
        }

        public IEnumerable<T> AllByTag<T>(string tag) where T: Element, new()
        {
            return this.FindAll<T>(By.TagName(tag));
        }

        public IEnumerable<T> AllByXPath<T>(string xpath) where T: Element, new()
        {
            return this.FindAll<T>(By.XPath(xpath));
        }

        public T ByCssSelector<T>(string cssSelector) where T: Element, new()
        {
            return this.Find<T>(By.CssSelector(cssSelector));
        }

        public T ById<T>(string id) where T: Element, new()
        {
            return this.Find<T>(By.Id(id));
        }

        public T ByName<T>(string name) where T: Element, new()
        {
            return this.Find<T>(By.Name(name));
        }

        public T ByTag<T>(string tag) where T: Element, new()
        {
            return this.Find<T>(By.TagName(tag));
        }

        public T ByXPath<T>(string xpath) where T: Element, new()
        {
            return this.Find<T>(By.XPath(xpath));
        }

        public Link ByLinkText(string linkText)
        {
            return this.Find<Link>(By.LinkText(linkText));
        }

        private T Find<T>(By by) where T: Element, new()
        {
            var element = this.root.FindElement(by);
            var result = new T();
            result.SetElement(element);
            return result;
        }

        private IEnumerable<T> FindAll<T>(By by) where T: Element, new()
        {
            var elements = this.root.FindElements(by);
            return elements == null
                       ? Enumerable.Empty<T>()
                       : elements.Select(e => new T().SetElement(e))
                                 .Cast<T>();
        }
    }
}