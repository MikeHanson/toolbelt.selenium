using System;

namespace Toolbelt.Selenium.Elements
{
    public class Link : Element
    {
        public override string Tag
        {
            get { return "a"; }
        }

        public void Click()
        {
            this.WebElement.Click();
        }
    }
}