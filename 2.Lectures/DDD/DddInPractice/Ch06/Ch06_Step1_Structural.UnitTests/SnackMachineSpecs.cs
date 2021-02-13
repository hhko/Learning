using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using static Ch06_Step1_Structural.SharedKernel.Money;
using static Ch06_Step1_Structural.Snack;

namespace Ch06_Step1_Structural.UnitTests
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

            //snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
            snackMachine.MoneyInTransaction.Should().Be(1.01m);
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

            //snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
            snackMachine.MoneyInTransaction.Should().Be(0m);
        }
        #endregion

        #region BuySnack 규칙
        [Fact]
        //public void Money_in_transaction_goes_to_money_inside_after_purchase()
        //{
        //    var snackMachine = new SnackMachine();
        //    snackMachine.InsertMoney(Dollar);
        //    snackMachine.InsertMoney(Dollar);
        //
        //    snackMachine.BuySnack();
        //
        //    snackMachine.MoneyInTransaction.Should().Be(None);
        //    snackMachine.MoneyInside.Amount.Should().Be(2m);
        //}

        public void BuySnack_trades_inserted_money_for_a_snack()
        {
            var snackMachine = new SnackMachine();
            //snackMachine.LoadSnacks(1, new Snack("Some snack"), 10, 1m);
            //snackMachine.LoadSnacks(1, new SnackPile(new Snack("Some snack"), 10, 1m));
            snackMachine.LoadSnacks(1, new SnackPile(Chocolate, 10, 1m));

            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack(1);

            //snackMachine.MoneyInTransaction.Should().Be(None);
            snackMachine.MoneyInTransaction.Should().Be(0);
            snackMachine.MoneyInside.Amount.Should().Be(1m);

            // 에러 : Aggregate Root에서 Slots 엔티티를 직접 접근할 수 없어 에러가 발생한다.
            //snackMachine.Slots.Single(x => x.Position == 1).Quantity.Should().Be(9);

            // 문제점 : Aggregate Root에서 Slots 엔티티를 간접 접근하기 위해 개별 메서드를 만들어야 한다.
            //snackMachine.GetQuantityOfSnacksInSlot(1).Should().Be(9);
            //snackMachine.GetSnacksInSlot(1).Should().Be(9);
            //snackMachine.GetPriceInSlot(1).Should().Be(9);

            // 
            // SnackPile 값 객체를 노출한다.
            //
            snackMachine.GetSnackPile(1).Quantity.Should().Be(9);
        }
        #endregion

        // 구매할 수 있는 Snack이 있어야 한다.  
        [Fact]
        public void Cannot_make_purchage_when_there_is_no_snacks()
        {
            var snackMachine = new SnackMachine();

            //
            // slot.SnackPile = slot.SnackPile.SubtractOne();
            // Quantity가 음수가되어 생성자에서 예외가 발생한다.
            //
            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        // 스낵 구매를 위한 충분한 돈이 투입되어야 한다.  
        [Fact]
        public void Cannot_make_purchase_if_not_enough_money_inserted()
        {
            var snackMachine = new SnackMachine();
            //snackMachine.LoadSnacks(1, new SnackPile(new Snack("Some snack"), 1, 2m));
            snackMachine.LoadSnacks(1, new SnackPile(Chocolate, 1, 2m));
            snackMachine.InsertMoney(Dollar);
            
            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        // 스낵을 구매한 후 잔액을 반환할 수 있다.  
        [Fact]
        public void Snack_machine_returns_money_with_highest_denomination_first()
        {
            SnackMachine snackMachine = new SnackMachine();
            snackMachine.LoadMoney(Dollar);

            snackMachine.InsertMoney(Quarter);
            snackMachine.InsertMoney(Quarter);
            snackMachine.InsertMoney(Quarter);
            snackMachine.InsertMoney(Quarter);
            snackMachine.ReturnMoney();

            snackMachine.MoneyInside.QuarterCount.Should().Be(4);
            snackMachine.MoneyInside.OneDollarCount.Should().Be(0);
        }

        [Fact]
        public void After_purchase_change_is_returned()
        {
            var snackMachine = new SnackMachine();
            //snackMachine.LoadSnacks(1, new SnackPile(new Snack("Some snack"), 1, 0.5m));
            snackMachine.LoadSnacks(1, new SnackPile(Chocolate, 1, 0.5m));

            //snackMachine.LoadMoney(new Money(0, 10, 0, 0, 0, 0));   // 1.00(잔액)
            snackMachine.LoadMoney(TenCent * 10);   // 1.00(잔액)

            snackMachine.InsertMoney(Dollar);                       // 1.00(잔액) + 1.00(투입 금액) = 2.00
            snackMachine.BuySnack(1);                               // 2.00 - 0.50 = 1.50

            snackMachine.MoneyInside.Amount.Should().Be(1.5m);
            snackMachine.MoneyInTransaction.Should().Be(0m);
        }

        [Fact]
        public void Cannot_buy_snack_if_not_enough_change()
        {
            var snackMachine = new SnackMachine();

            //                반환해야할 잔액
            //  0.01  0개  -> 50개(0.50)
            //  0.10  0개  ->  5개(0.50)
            //  0.25  0개  ->  2개(0.50)
            //  1.00  1개
            //  5.00  0개
            // 20.00  0개
            // --------------------------------
            //                잔액이 없다.
            //snackMachine.LoadSnacks(1, new SnackPile(new Snack("Some snack"), 1, 0.5m));
            snackMachine.LoadSnacks(1, new SnackPile(Chocolate, 1, 0.5m));
            snackMachine.InsertMoney(Dollar);

            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
