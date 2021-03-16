# Microsoft.Extensions.DependencyInjection Tutorial

### 1. 의존성 등록 방법
1. 인터페이스와 구현 클래스    
   - `IServiceCollection AddTransient<TService, TImplementation>()`
1. 구현 클래스
   - `IServiceCollection AddTransient<TService>()`
1. 중복 
1. 인터페이스와 팩토리
   - `IServiceCollection AddTransient<TService>(Func<IServiceProvider, TService> implementationFactory)`
1. 인터페이스와 팩토리 with Builder 패턴
   ```cs
   services.TryAddTransient<IMembershipAdvertBuilder, MembershipAdvertBuilder>();
   services.TryAddScoped<IMembershipAdvert>(sp =>
   {
       var builder = sp.GetService<IMembershipAdvertBuilder>();
   
       builder.WithDiscount(10m);
   
       return builder.Build();
   });

   public interface IMembershipAdvertBuilder
   {
       MembershipAdvert Build();
       MembershipAdvertBuilder WithDiscount(decimal discount);
   }
   
   public class MembershipAdvert : IMembershipAdvert
   {
       public MembershipAdvert(decimal offerPrice, decimal discount)
       {
           OfferPrice = offerPrice;
           Saving = discount;
       }
   
       public decimal OfferPrice { get; }
   
       public decimal Saving { get; }
   }
   ```

### 2. 복수 의존성s 등록 방법
- `Try`

### x. 복수 인터페이스 구현(단일 객체)

### x. Generic <T>
- `typeof`

### x. Builder 패턴

### x. IOption 통합

### x. 코드 정리
- `namespace Microsoft.Extensions.DependencyInjection`

### x. 주입
1. 생성자
1. Action Injection
1. Middleware Injection

### x. Scope
1. Main -> Singleton 방지

