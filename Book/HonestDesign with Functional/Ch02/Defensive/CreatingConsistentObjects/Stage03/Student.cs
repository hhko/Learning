using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage03
{
    public class Student
    {
        public string Name { get; }

        // No need to defined when accessing internal state.
        // 더 이상 내부 상태를 접근하기 위한 방어 코드가 필요없다.
        public int NameLength
        {
            get
            {
                return Name.Length;
            }
        }

        public char NameInitialLetter
        {
            get
            {
                return Name[0];
            }
        }

        public Student(string name)
        {
            // There is only defensive code here
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }
    }
}
