using System;
using System.Collections.Generic;
using SpecSalad;
using TechTalk.SpecFlow;

namespace Toolbelt.Selenium.Samples.SpecFlow.SpecSalad
{
    public abstract class ThenTableIncludes : ApplicationTask
    {
        protected override object Perform_Task_With(IDictionary<string, string> details)
        {
            return this.Actual();
        }

        public abstract Table Actual();
    }
}