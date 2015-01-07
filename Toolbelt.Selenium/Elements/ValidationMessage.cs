using System;

namespace Toolbelt.Selenium.Elements
{
    public class ValidationMessage : Element
    {
        public string Text
        {
            get { return this.WebElement.Text; }
        }

        public override string Tag
        {
            get { return "li"; }
        }
    }
}