// 목표
// - 타입으로 로직을 단순화 시킨다.
// - 메서드 Signature로 메서드 역할을 더 명확히 표현한다.
// - 예. 메서드 정직성(Honesty) 크기
//   Risk CalculateRiskProfile(dynamic age) 
//    <  Risk CalculateRiskProfile(int age) 
//    <  Risk CalculateRiskProfile(Age age) 
//    <= Risk CalculateRiskProfile(Option<Age> age)
//

using System;

namespace PrimitiveObsession
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stage 1: dynamic 타입
            // - Risk CalculateRiskProfile(dynamic age)
            // - 문제점: Runtime에 RuntimeBinderException이 발생한다.
            {
                Stage1.Calculate.CalculateRiskProfile(30);
                Stage1.Calculate.CalculateRiskProfile(70);

                // 예상한 타입이 아니므로 RuntimeBinderException 예외가 발생한다.
                // Stage1.Calculate.CalculateRiskProfile("Hello");
            }

            // Stage 2: int 타입
            // - Risk CalculateRiskProfile(int age)
            // - 개선점: Runtime에 RuntimeBinderException 발생을 Compile-time 에러로 처리했다(배포 전에 확인할 수 있다).
            // - 문제점: 유요성 검사가 실패할 때 Runtime에 ArgumentException가 발생한다.

            {
                Stage2.Calculate.CalculateRiskProfile(30);
                Stage2.Calculate.CalculateRiskProfile(70);

                // Runtime RuntimeBinderException -> Compile Error
                // Error CS1503  Argument 1: cannot convert from 'string' to 'int'
                //
                //Stage2.Calculate.CalculateRiskProfile("Hello");

                // 유요성 검사 실패로 ArgumentException 예외가 발생한다.
                //Stage2.Calculate.CalculateRiskProfile(10000);
            }

            // Stage 3: Age 타입
            // - Risk CalculateRiskProfile(Age age)
            // - 개선점: int 타입을 Age 타입으로 변경하여 메서드 Signature로 메서드 역할을 더 명확히 표현하였다.
            // - 문제점: 유효성 검사가 실패하면 여전히 Runtime에 ArgumentException이 발생한다.
            {
                Stage3.Calculate.CalculateRiskProfile(new Stage3.Age(30));
                Stage3.Calculate.CalculateRiskProfile(new Stage3.Age(70));

                // 유요성 검사 실패로 ArgumentException 예외가 발생한다.
                //Stage3.Calculate.CalculateRiskProfile(new Stage3.Age(10000));
            }

            // Stage 4: Age 타입 개선
            // - Risk CalculateRiskProfile(Age age)
            // - 개선점: 연산자 재정의를 통해 구조적으로 데이터에 접근하는 습관을 차단 시킨다.
            // - 문제점: 유효성 검사가 실패하면 여전히 Runtime에 ArgumentException이 발생한다.
            {
                // public int Value { get; } -> 제거한다(연산자 재정의)

                // Operator overloading
                // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-o
                //
                // private int Value { get; }
                // public static bool operator <(Age l, int r) => ...;
            }

            // Stage 5: Option<Age> 타입
            // - Risk CalculateRiskProfile(Option<Age> age)
            // - 개선점: 유효성 검사 실패일 때 기본 값으로 처리한다.
            // - 질문: "예외 처리 vs. 기본 값 처리" 차이점은 ?
            //   - "예외 처리"는 호출자가 처리해할 로직 흐름을 증가 시킨다(로직 복잡도가 무한해 진다).
            //   - "기본 값 처리"는 성공과 동일한 타입이기 때문에 로직 흐름이 증가되지 않는다(로직 복잡도가 유한해 진다: 컴파일 타임에 결정된다).
            //   - 예.
            //        string msg = val.Match(
            //                 Some: _ => $"Hello {_}",
            //                 None: () => "Hi");         // 실패도 string 타입을 반환한다.
            // - 문제점: 실패일 때 기본 값이 아닌 처리는 할 수 없나 ? (있다.배움은 늘 기다림을 요구한다. 개선 방법은 다음에.)
            {
                Stage5.Calculate.CalculateRiskProfile(Stage5.Age.Of(30));
                Stage5.Calculate.CalculateRiskProfile(Stage5.Age.Of(70));

                // 유요성 검사 실패 ArgumentException을 기본 값으로 처리한다.
                Stage5.Calculate.CalculateRiskProfile(Stage5.Age.Of(10000));
            }
        }
    }
}
