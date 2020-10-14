using System;
using System.Collections.Generic;
using System.Text;

namespace Ch02._02
{
    public class Student
    {
        private string _name;
        public string Name 
        { 
            get { return _name; }
            set
            {
                // 유효성 검사
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(nameof(value));

                if (char.IsHighSurrogate(value[value.Length - 1]))
                    throw new ArgumentException();

                _name = value;
            }
        }

        // 상태를 변경 시키는 Setter와 메서드는 유효성 검사를 뿔뿔이 흩어지게 한다.
        public Student(string name)
        {
            Name = name;
        }

        public string NameInitial =>
            Name.Substring(0, char.IsSurrogate(Name[0]) ? 2 : 1);
    }
}
