using System;
using System.Collections.Generic;
using SpecSalad;

namespace Toolbelt.Selenium.Samples.SpecFlow.SpecSalad
{
    public abstract class GivenWhenTask : ApplicationTask
    {
        protected override object Perform_Task_With(IDictionary<string, string> details)
        {
            this.Run(details);
            return null;
        }

        protected abstract void Run(IDictionary<string, string> details);
    }
}