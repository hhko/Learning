using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._04
{
    public class Student
    {
        public PersonalName Name { get; }

        public Student(PersonalName name)
        {
            // 유효성 검사 책임은 PersonalName 클래스로 이동한다.
            //if (string.IsNullOrEmpty(name))
            //    throw new ArgumentException(nameof(name));

            //if (char.IsHighSurrogate(name[name.Length - 1]))
            //    throw new ArgumentException();

            if (name == null)
                throw new ArgumentException(nameof(name));

            Name = name;
        }

        // Name이 노출되어 있기 때문에 NameInitial 역시 PersonalName 클래스로 이동한다.
        //public string NameInitial =>
        //    Name.Substring(0, char.IsSurrogate(Name[0]) ? 2 : 1);
    }
}
