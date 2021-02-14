using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using static Ch07_Step1_DomainEvent.SharedKernel.Money;

namespace Ch07_Step1_DomainEvent.UnitTests
{
    public class AtmSpecs
    {
        //
        // 요구사항
        // - ATM | 요청한 현금을 제공한다.
        //   - Dispense cash
        // - ATM | 수수료 1%을 부과한다.
        //   - Charge the user's bank card
        //

        [Fact]
        public void Take_money_exchanges_money_with_commission()
        {
            var atm = new Atm();
            atm.LoadMoney(Dollar);

            atm.TakeMoney(1m);

            atm.MoneyInside.Amount.Should().Be(0m);
            atm.MoneyCharged.Should().Be(1.01m);
        }

        // 최소 수수료 단위(Cent : % 0.01m)
        // 예. 0.0001 -> 0.01
        [Fact]
        public void Commission_is_at_least_one_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Cent);

            atm.TakeMoney(0.01m);

            atm.MoneyCharged.Should().Be(0.02m);
        }

        // 수수료 반올림(절상, + 0.01m)
        // 예. 0.011 -> 0.02
        [Fact]
        public void Commission_is_rounded_up_to_the_next_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Dollar + TenCent);

            atm.TakeMoney(1.1m);

            atm.MoneyCharged.Should().Be(1.12m);
        }
    }
}
