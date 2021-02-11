using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringToAggregateServices.Stage1
{
    public class OrderProcessor
    {
        private readonly IOrderValidator _validator;
        private readonly IOrderShipper _shipper;
        private readonly IAccountsReceivable _receivable;
        private readonly IRateExchange _exchange;
        private readonly IUserContext _userContext;

        // Stage 1: Constructor over-injection
        // 문제점: 많은 의존성(5개)을 주입 받는다.
        public OrderProcessor(IOrderValidator validator,
                      IOrderShipper shipper,
                      IAccountsReceivable receivable,
                      IRateExchange exchange,
                      IUserContext userContext)
        {
            _validator = validator;
            _shipper = shipper;
            _receivable = receivable;
            _exchange = exchange;
            _userContext = userContext;
        }

        public SuccessResult Process(Order order)
        {
            bool isValid = _validator.Validate(order);
            if (isValid)
            {
                Collect(order);
                _shipper.Ship(order);
            }

            return CreateStatus(isValid);
        }

        private void Collect(Order order)
        {
            User user = _userContext.GetCurrentUser();
            Price price = order.GetPrice(_exchange, _userContext);
            _receivable.Collect(user, price);
        }

        private SuccessResult CreateStatus(bool isValid)
        {
            return null;
        }
    }

    #region 기본 코드(리팩토링 대상 아님)
    public interface IOrderValidator
    {
        bool Validate(Order order);
    }

    public interface IOrderShipper
    {
        void Ship(Order order);
    }

    public interface IAccountsReceivable
    {
        void Collect(User user, Price price);
    }

    public interface IRateExchange
    { }

    public interface IUserContext
    {
        User GetCurrentUser();
    }

    public class SuccessResult
    { }

    public class Order
    {
        public Price GetPrice(IRateExchange exchange, IUserContext userContext)
        {
            return null;
        }
    }

    public class User
    { }

    public class Price
    { }
    #endregion
}
