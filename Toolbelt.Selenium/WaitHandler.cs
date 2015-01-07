using System;
using System.Timers;
using OpenQA.Selenium;

namespace Toolbelt.Selenium
{
    public class WaitHandler
    {
        private readonly Timer timer;
        private bool isWaiting;
        private readonly WaitUntil waitUntil;

        public WaitHandler(IWebDriver driver)
        {
            this.timer = new Timer();
            this.timer.Elapsed += this.TimerElapsed;
            this.waitUntil = new WaitUntil(driver);
        }

        public bool For(Func<bool> condition, TimeSpan timeOut)
        {
            var result = false;
            this.isWaiting = true;
            this.timer.Interval = timeOut.TotalMilliseconds;
            this.timer.Start();
            do
            {
                result = condition();
            } while(!result || !this.isWaiting);

            return result;
        }

        public bool For(Func<bool> condition)
        {
            return this.For(condition, TimeSpan.FromSeconds(5));
        }

        private void TimerElapsed(object sender, ElapsedEventArgs eventArgs)
        {
            this.isWaiting = false;
            this.timer.Stop();
        }

        public WaitUntil Until()
        {
            return this.waitUntil;
        }
    }
}