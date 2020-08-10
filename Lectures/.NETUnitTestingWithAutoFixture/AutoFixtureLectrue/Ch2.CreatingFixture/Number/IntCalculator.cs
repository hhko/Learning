using System;

namespace Ch2.CreatingFixture
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
