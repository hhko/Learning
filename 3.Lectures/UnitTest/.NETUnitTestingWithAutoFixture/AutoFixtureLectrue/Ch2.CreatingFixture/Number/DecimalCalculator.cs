using System;
using System.Collections.Generic;
using System.Text;

namespace Ch2.CreatingFixture
{
    public class DecimalCalculator
    {
        public decimal Value { get; private set; }

        public void Subtract(decimal number)
        {
            Value -= number;
        }
    }
}
