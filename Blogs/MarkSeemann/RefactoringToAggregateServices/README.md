# Refactoring to Aggregate Services
- https://blog.ploeh.dk/2010/02/02/RefactoringtoAggregateServices/

## 목차
1. **[Stage 1:  Constructor over-injection](#stage-1-constructor-over-injection)**
1. **[Stage 2: Facade Service 패턴](#stage-2-facade-service-패턴)**
1. **[정리](#정리)**

## Stage 1: Constructor over-injection
- 문제점: 많은 의존성(5개)을 주입 받는다.
- 예
  ```cs
  public OrderProcessor(IOrderValidator validator,
                IOrderShipper shipper,
                IAccountsReceivable receivable,
                IRateExchange exchange,
                IUserContext userContext)
   ```
- 개선 방향: Collect 메서드는 주입 받은 3개 의존성(```IAccountsReceivable(_receivable)```, ```IRateExchange(_exchange)```, ```IUserContext(_userContext)``` )으로 캡슐화할 수 있다.
  ```cs
  private void Collect(Order order)
  {
      User user = _userContext.GetCurrentUser();
      Price price = order.GetPrice(_exchange, _userContext);
      _receivable.Collect(user, price);
  }					  
  ```

## Stage 2: Facade Service 패턴
- 문제점: 많은 의존성(5개)을 주입 받는다.
- 개선점: 통합할 수 있는 의존성(IAccountsReceivable, IRateExchange, IUserContext)을 줄인다(IOrderCollector, Facade Service 패턴).
- Facade Service 패턴?
  - Facade Service 패턴 vs. Parameter Object 패턴
    - Parameter Object only moves the parameters to a common root, 
    - Facade Service hides the aggregate behavior(3개 의존성) behind a new abstraction(1개 의존성).  
      While the Facade Service may start its life as a result of a pure mechanistic refactoring,   
      it often turns out that the extracted behavior represents a Domain Concept in its own right.  
  - Facade Service 패턴은 비즈니스 관련성이 높은 의존성을 통합시켜 비즈니스 함수를 노출한다.  
    - 통합: 3개(IAccountsReceivable, IRateExchange, IUserContext) -> 1개(IOrderCollector)
    - 비즈니스 함수: Collect
- 예: 의존성 주입 줄이기
  ```cs		
  private readonly IOrderCollector _collector;

  public OrderProcessor(IOrderValidator validator,
                IOrderShipper shipper,
                IOrderCollector collector)		
  
  private void Collect(Order order)
  {
      // 통합된 의존성에게 위임한다.
      _collector.Collect(order);
  }		
  ```
- 예: 위임하기		
  ```cs
  public interface IOrderCollector
  {
      void Collect(Order order);
  }		
  ```
- 통합 의존성(```IOrderCollector```) 구현(Facade Service 패턴)
  ```cs
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
  ```

## 정리
- Facade Service 패턴으로 도메인 중심으로 의존성을 통합 시킬 수 있다.
- 많은 의존성을 주입 받고 있는 ```OrderProcessor```가 많은 책임을 갖고 있을 수 있다. ```OrderProcessor```을 분리 시키는 것도 고민해야 한다(SRP: Single Responsibility Principle).