using System;

namespace Toolbelt.Selenium.Samples.PageModel
{
    public class Sut : SystemUnderTest<MainPage>
    {
        private static Sut current;

        public static Sut Current
        {
            get { return current ?? (current = new Sut()); }
        }
    }
}