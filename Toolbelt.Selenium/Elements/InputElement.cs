using System;

namespace Toolbelt.Selenium.Elements
{
    public abstract class InputElement : Element
    {
        public override string Tag
        {
            get { return "input"; }
        }

        public string Value
        {
            get { return this.WebElement.GetAttribute("value"); }
        }
    }
}