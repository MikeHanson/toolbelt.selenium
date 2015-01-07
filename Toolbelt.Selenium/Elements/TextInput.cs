using System;

namespace Toolbelt.Selenium.Elements
{
    public class TextInput : InputElement
    {
        public TextInput ClearText()
        {
            this.WebElement.Clear();
            return this;
        }

        public TextInput ReplaceText(string inputText)
        {
            return this.ClearText().TypeText(inputText);
        }

        public TextInput TypeText(string inputText)
        {
            this.WebElement.SendKeys(inputText);
            return this;
        }
    }
}