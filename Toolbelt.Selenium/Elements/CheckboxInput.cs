using System;

namespace Toolbelt.Selenium.Elements
{
    public class CheckboxInput : InputElement
    {
        public bool IsChecked { get { return this.WebElement.Selected; }}

        public void Check()
        {
            if(this.IsChecked)
            {
                return;
            }
            this.WebElement.Click();
        }

        public void Uncheck()
        {
            if(!this.IsChecked)
            {
                return;
            }
            this.WebElement.Click();
        }
    }
}