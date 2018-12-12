using System;
using static System.Math;
using System.Collections.Generic;
using System.Text;

namespace TeleprompterConsole
{
    internal class TeleprompterConfig
    {
        private object lockHandle = new object();
        public int DelayInMilliSeconds { get; private set; } = 200;

        public void UpdateDelay(int increment)
        {
            var newDelay = Min(DelayInMilliSeconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            lock (lockHandle)
            {
                DelayInMilliSeconds = newDelay;
            }
        }

        public bool Done { get; private set; }

        public void SetDone()
        {
            Done = true;
        }
    }
}
