// 목표: SideEffects 불순 함수에서 순수 함수를 발견(설계)하여 분리한다.
// - 순수 함수는 [Pure] 속성으로 명시한다.

using System;
using System.Diagnostics.Contracts;

// using static directive 
using static System.Console;        
//
// 1. 참고 URL
// https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/using-static
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-static
// 
// 2. 문법
// using static <fully-qualified-type-name>;
//
// 3. 예
// Math.PI;
//  vs.
// using static System.Math;
// PI;
//
// 4. 가치
// 순수 함수는 기본적으로 정적 함수로 개발하기 때문에 "using static directive"을 사용하면 코드가 단순해진다.
//

namespace ManagingSideEffects.Stage2
{
    public class PureDiscovery
    {
        public void SideEffects()
        {
            WriteLine("Enter your name:");

            var name = ReadLine();
            var greet = GreetingFor(name);

            WriteLine(greet);
        }

        // ===================================================
        // 순수 함수는 [Pure] 속성으로 명시한다.
        // 순수 함수의 출력은 입력만을 의존한다.
        // ===================================================
        //
        // 1. 참고 URL
        // https://docs.microsoft.com/ko-kr/dotnet/api/system.diagnostics.contracts.pureattribute?view=netframework-4.8
        //
        // 2. 개요
        // 클래스: PureAttribue
        // 네임스페이스: System.Diagnostics.Contracts
        [Pure]
        public string GreetingFor(string name) =>
            $"Hello {name}";
    }
}