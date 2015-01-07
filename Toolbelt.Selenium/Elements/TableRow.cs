using System;
using System.Collections.Generic;
using System.Linq;

namespace Toolbelt.Selenium.Elements
{
    public class TableRow : Element
    {
        public IEnumerable<TableDataCell> Cells
        {
            get
            {
                return this.Find()
                           .AllByTag<TableDataCell>("td");
            }
        }

        public override string Tag
        {
            get { return "tr"; }
        }

        public TableDataCell Cell(int index)
        {
            return this.Cells.Skip(index).FirstOrDefault();
        }
    }
}