using System;
using System.Collections.Generic;
using System.Linq;

namespace Toolbelt.Selenium.Elements
{
    public class Table : Element
    {
        public IEnumerable<TableRow> Rows
        {
            get
            {
                return this.Find()
                           .AllByXPath<TableRow>("tbody/tr");
            }
        }

        public override string Tag
        {
            get { return "table"; }
        }

        public bool ContainsRowWithText(string expected)
        {
            return this.Rows.Any(r => r.Text == expected);
        }
    }
}