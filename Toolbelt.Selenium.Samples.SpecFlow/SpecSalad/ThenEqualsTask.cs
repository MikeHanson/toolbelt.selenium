using System;
using System.Collections.Generic;
using SpecSalad;

namespace Toolbelt.Selenium.Samples.SpecFlow.SpecSalad
{
    public abstract class ThenEqualsTask : ApplicationTask
    {
        protected override object Perform_Task_With(IDictionary<string, string> details)
        {
            return this.Answer(details);
        }

        protected abstract object Answer(IDictionary<string, string> details);
    }
}