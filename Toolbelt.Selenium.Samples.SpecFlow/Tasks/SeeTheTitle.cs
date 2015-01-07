using System;
using System.Collections.Generic;
using Toolbelt.Selenium.Samples.PageModel;
using Toolbelt.Selenium.Samples.SpecFlow.SpecSalad;

namespace Toolbelt.Selenium.Samples.SpecFlow.Tasks
{
    public class SeeTheTitle : ThenEqualsTask
    {
        protected override object Answer(IDictionary<string, string> details)
        {
            return Sut.Current.CurrentPage()
                      .Title;
        }
    }
}