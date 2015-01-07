using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Toolbelt.Selenium.Elements
{
    public class List : Element
    {
        private SelectElement selectElement;

        public bool CanSelectMultiple
        {
            get { return this.selectElement.IsMultiple; }
        }

        public IList<ListItem> Items
        {
            get
            {
                if(this.selectElement.Options == null || this.selectElement.Options.Count == 0)
                {
                    return Enumerable.Empty<ListItem>()
                                     .ToList();
                }

                return this.selectElement.Options.Select(i => new ListItem(i))
                           .ToList();
            }
        }

        public ListItem SelectedItem
        {
            get { return this.selectElement.SelectedOption == null? null: new ListItem(this.selectElement.SelectedOption); }
        }

        public IList<ListItem> SelectedItems
        {
            get
            {
                if(this.selectElement.AllSelectedOptions == null || this.selectElement.AllSelectedOptions.Count == 0)
                {
                    return Enumerable.Empty<ListItem>()
                                     .ToList();
                }

                return this.selectElement.AllSelectedOptions.Select(i => new ListItem(i))
                           .ToList();
            }
        }

        public override string Tag
        {
            get { return "select"; }
        }

        public void DeselectAll()
        {
            this.selectElement.DeselectAll();
        }

        public void DeselectByIndex(int index)
        {
            this.selectElement.DeselectByIndex(index);
        }

        public void DeselectByText(string text)
        {
            this.selectElement.DeselectByText(text);
        }

        public void DeselectByValue(string value)
        {
            this.selectElement.DeselectByValue(value);
        }

        public void SelectItemByIndex(int index)
        {
            this.selectElement.SelectByIndex(index);
        }

        public void SelectItemByText(string text)
        {
            this.selectElement.SelectByText(text);
        }

        public void SelectItemByValue(string value)
        {
            this.selectElement.SelectByValue(value);
        }

        internal override Element SetElement(IWebElement element)
        {
            this.selectElement = new SelectElement(element);
            return base.SetElement(element);
        }
    }
}