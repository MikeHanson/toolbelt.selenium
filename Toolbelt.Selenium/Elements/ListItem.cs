using System;
using OpenQA.Selenium;

namespace Toolbelt.Selenium.Elements
{
    public class ListItem: Element
    {
        public ListItem()
        {
        }

        internal ListItem(IWebElement element)
        {
            base.SetElement(element);
        }
        
        public bool IsSelected { get { return this.WebElement.Selected; } }

        public override string Tag
        {
            get { return "option"; }
        }

        public string Value { get { return this.WebElement.GetAttribute("value"); } }
    }
}