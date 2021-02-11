using System;

namespace Ch1.GettingStarted
{
    public class IntCalculator
    {
        public int Value { get; private set; }

        public void Subtract(int number)
        {
            Value -= number;
        }
    }
}
