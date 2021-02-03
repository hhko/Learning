using System;
using System.Collections.Generic;
using System.Text;

namespace Ch02._01
{
    public class Student
    {
        public string Name { get; }

        // 모든 메서드의 유효성 검사는 생성자가 책임한다.
        public Student(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            if (char.IsHighSurrogate(name[name.Length - 1]))
                throw new ArgumentException();

            Name = name;
        }

        //// 방어 코드를 추가할 필요가 없다.
        //// 유효성 검사 1. : if (string.IsNullOrEmpty(name))
        //public char NameInitial =>
        //    Name[0];

        //// 유효성 검사 1. : if (string.IsNullOrEmpty(name))
        //// 유효성 검사 2. : if (char.IsHighSurrogate(name[name.Length - 1]))
        public string NameInitial =>
            Name.Substring(0, char.IsSurrogate(Name[0]) ? 2 : 1);
    }
}
