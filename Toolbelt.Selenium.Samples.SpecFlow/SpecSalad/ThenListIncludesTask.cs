using System;
using System.Collections.Generic;
using SpecSalad;

namespace Toolbelt.Selenium.Samples.SpecFlow.SpecSalad
{
    public abstract class ThenListIncludesTask : ApplicationTask
    {
        protected override object Perform_Task_With(IDictionary<string, string> details)
        {
            return this.Actual();
        }

        public abstract List<string> Actual();
    }
}