using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage02
{
    public class Student
    {
        // 질문
        //  - 빈 문자열일 때?
        //  - NULL 객체일 때?
        //
        // 객체의 내부 상태가 일관성이 없을 때?
        // Object's Internal Operation
        //  - what will happen to the object if its state is inconsistent?
        //  - 상태가 일관성이 없으면 개체는 어떻게됩니까?
        //    > State error will cause execution error.
        //    > Defensive code is mandatory.
        public string Name { get; set; }

        // There is plenty of defensive code here
        public int NameLength
        {
            get
            {
                if (Name != null)           // defensive code
                    return Name.Length;
                else
                    return 0;
            }
        }

        public char NameInitialLetter
        {
            get
            {
                if (Name != null && Name.Length > 0)    // defensive code
                    return Name[0];
                else
                    return 'A';
            }
        }
        public Student()
        {
            // 기본 생성자
            //  - Implicit parameterless constructor is 
            //    the bulit-in factory function.
            //  - Sets numeric fields to zero, Booleans to False,
            //    references to null.
            //  - Implicit constructor will set 
            //    the Name property to null.
            //  - This null reference incurs defensive code.
            Name = null;    
        }
    }
}
