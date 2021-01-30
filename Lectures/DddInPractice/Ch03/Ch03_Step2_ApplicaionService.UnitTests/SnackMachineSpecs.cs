using FluentAssertions;
using System;
using Xunit;
using static Ch03_Step2_ApplicaionService.Money;

namespace Ch03_Step2_ApplicaionService.UnitTests
{
    public class SnackMachineSpecs
    {
        #region InsertMoney 규칙
        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(Cent);
            snackMachine.InsertMoney(Dollar);

            snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
        }

        [Fact]
        public void Cannot_insert_more_than_one_coin_or_note_at_a_time()
        {
            var snackMachine = new SnackMachine();
            var twoCent = Cent + Cent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            action.Should().Throw<InvalidOperationException>();
        }
        #endregion

        #region ReturnMoney 규칙
        [Fact]
        public void Return_money_empties_money_in_transaction()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
        }
        #endregion

        #region BuySnack 규칙
        [Fact]
        public void Money_in_transaction_goes_to_money_inside_after_purchase()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Should().Be(None);
            snackMachine.MoneyInside.Amount.Should().Be(2m);
        }
        #endregion
    }
}
