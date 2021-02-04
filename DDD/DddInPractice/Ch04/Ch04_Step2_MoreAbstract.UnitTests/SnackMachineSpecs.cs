﻿using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using static Ch04_Step2_MoreAbstract.Money;

namespace Ch04_Step2_MoreAbstract.UnitTests
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
            snackMachine.LoadSnacks(1, new SnackPile(new Snack("Some snack"), 10, 1m));

            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack(1);

            snackMachine.MoneyInTransaction.Should().Be(None);
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
    }
}
