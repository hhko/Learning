using System;
using System.Collections.Generic;
using System.Text;

namespace Ch02._05
{
    public class Student
    {
        private readonly PersonalName _name;

        public Student(PersonalName name)
        {
            _name = name;
        }

        //public string NameInitial =>
        //    Name.Substring(0, char.IsSurrogate(Name[0]) ? 2 : 1);

        // Case 1. : PersonalName의 연산 결과 얻기
        public string NameInitial =>
            _name.Initial;

        //// Case 2. : PersonalName의 Raw 데이터로 연산하기
        //public string NameInitial =>
        //    _name.Value.Substring(0, char.IsSurrogate(_name.Value[0]) ? 2 : 1);
    }
}
