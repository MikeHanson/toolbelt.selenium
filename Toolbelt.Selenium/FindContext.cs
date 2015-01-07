using System;
using OpenQA.Selenium;

namespace Toolbelt.Selenium
{
    public abstract class FindContext
    {
        private Finder finder;

        public Finder Find()
        {
            return this.finder;
        }

        internal void SetFindRoot(ISearchContext root)
        {
            this.finder = new Finder(root);
        }
    }
}