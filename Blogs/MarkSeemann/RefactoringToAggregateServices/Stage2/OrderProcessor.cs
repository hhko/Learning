using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringToAggregateServices.Stage2
{
    public class OrderProcessor
    {
        private readonly IOrderValidator _validator;
        private readonly IOrderShipper _shipper;

        // Stage 2: Facade Service 패턴
        // - 문제점: 많은 의존성(5개)을 주입 받는다.
        // - 개선점: 통합할 수 있는 의존성(IAccountsReceivable, IRateExchange, IUserContext)을 줄인다(IOrderCollector, Facade Service 패턴).
        // - Facade Service 패턴?
        //   - Facade Service 패턴 vs. Parameter Object 패턴
        //     - Parameter Object only moves the parameters to a common root, 
        //     - Facade Service hides the aggregate behavior(3개 의존성) behind a new abstraction(1개 의존성).
        //       While the Facade Service may start its life as a result of a pure mechanistic refactoring, 
        //       it often turns out that the extracted behavior represents a Domain Concept in its own right.
        //   - Facade Service 패턴은 비즈니스 관련성이 높은 의존성을 통합시켜 비즈니스 함수를 노출한다.
        //     - 통합: 3개(IAccountsReceivable, IRateExchange, IUserContext) -> 1개(IOrderCollector)
        //     - 비즈니스 함수: Collect
        private readonly IOrderCollector _collector;
        //private readonly IAccountsReceivable _receivable;
        //private readonly IRateExchange _exchange;
        //private readonly IUserContext _userContext;

        public OrderProcessor(IOrderValidator validator,
                      IOrderShipper shipper,
                      IOrderCollector collector)
                      //IAccountsReceivable receivable,
                      //IRateExchange exchange,
                      //IUserContext userContext)
        {
            _validator = validator;
            _shipper = shipper;

            _collector = collector;
            //_receivable = receivable;
            //_exchange = exchange;
            //_userContext = userContext;
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
            // 통합된 의존성에게 위임한다.
            _collector.Collect(order);
            //User user = _userContext.GetCurrentUser();
            //Price price = order.GetPrice(_exchange, _userContext);
            //_receivable.Collect(user, price);
        }

        private SuccessResult CreateStatus(bool isValid)
        {
            return null;
        }
    }

    public interface IOrderCollector
    {
        void Collect(Order order);
    }

    public class OrderCollector : IOrderCollector
    {
        // 의존성을 통합 시킨다.
        private readonly IAccountsReceivable _receivable;
        private readonly IRateExchange _exchange;
        private readonly IUserContext _userContext;

        public OrderCollector(IAccountsReceivable receivable,
                      IRateExchange exchange,
                      IUserContext userContext)
        {
            _receivable = receivable;
            _exchange = exchange;
            _userContext = userContext;
        }

        public void Collect(Order order)
        {
            // 통합된 의존성을 수행한다.
            User user = _userContext.GetCurrentUser();
            Price price = order.GetPrice(_exchange, _userContext);
            _receivable.Collect(user, price);
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
