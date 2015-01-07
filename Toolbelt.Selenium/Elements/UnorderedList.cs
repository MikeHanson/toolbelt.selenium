using System;
using System.Collections.Generic;

namespace Toolbelt.Selenium.Elements
{
    public class UnorderedList : Element
    {
        public override string Tag
        {
            get { return "ul"; }
        }

        public IEnumerable<UnorderedListItem> ListItems
        {
            get
            {
                return this.Find()
                           .AllByTag<UnorderedListItem>("li");
            }
        }
    }
}