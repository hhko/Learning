// 목표
// - SideEffects 함수는 불순(Impure) 함수임을 확인한다.
//   > 파일 시스템에 의존하기(영향을 받기) 때문이다.

using System;
using static System.Console;

namespace ManagingSideEffects.Stage1
{
    public class Impure
    {
        public void SideEffects()
        {
            WriteLine("Enter your name:");
            var name = ReadLine();
            WriteLine($"Hello {name}");
        }
    }
}