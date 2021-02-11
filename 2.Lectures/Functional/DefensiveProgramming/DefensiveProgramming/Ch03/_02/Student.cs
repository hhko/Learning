using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._02
{
    public class Student
    {
        // 읽기 전용
        public string Name { get; }

        // 명시적 생성자
        public Student(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }

        // 방어 코드 제거로 인한 더 많은 코드 간결화 기회(C# 최신 언어 스펙)
        public int NameLength =>
            Name.Length;

        public char NameInitialLetter =>
            Name[0];
    }
}
