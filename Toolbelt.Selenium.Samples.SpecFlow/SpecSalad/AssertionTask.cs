using System;
using System.Collections.Generic;
using NUnit.Framework;
using SpecSalad;

namespace Toolbelt.Selenium.Samples.SpecFlow.SpecSalad
{
    public abstract class AssertionTask : ApplicationTask
    {
        protected override object Perform_Task_With(IDictionary<string, string> details)
        {
            this.TestCondition();
            return null;
        }

        private void TestCondition()
        {
            Assert.True(this.Condition());
        }

        protected abstract bool Condition();
    }
}