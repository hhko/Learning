using FluentAssertions;
using System;
using Xunit;

namespace Step_03_HasBehavior.UnitTests
{
    public class MoneySpecs
    {
        [Fact]
        public void ThrowExceptionDiffentCurrency()
        {
            var krw = new Money(1000, "KRW");
            var usd = new Money(10, "USD");

            Func<Money> act = () => krw.Add(usd);

            act.Should().ThrowExactly<ArgumentException>();
        }
    }
}
