using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage06
{
    public class Student
    {
        public string Name { get; }

        public Semester Enrolled { get; private set; }
        private bool _comesFromExchange { get;  }

        public int NameLength => 
            Name.Length;

        public char NameInitialLetter => 
            Name[0];

        // 1. 단점
        // Constructor doesn't have it's own name.
        // 생성자는 자신의 이름이 없다.
        //
        // 2. 문제점
        // Flag is not part of the public interface.
        // Why exposing it through the constructor then?
        //  > 내부 전용 변수(private)을 왜 생성자에서 주입을 받을까?
        //  > 외부에서 주입 받은 내부 전용 변수 상태에 따라 진행에 영향을 받는다(예. Enroll).
        private Student(bool comesFromExchange, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
            _comesFromExchange = comesFromExchange;
        }

        // 3. 해결책
        // Factory Method을 통해 생성 의미(함수명)를 부여한다.
        public static Student Create(string name) =>
            new Student(false, name);

        public static Student CreateFromExchange(string name) =>
            new Student(true, name);

        public void Enroll(Semester semester)
        {
            if (semester == null || (!_comesFromExchange && semester.Predecessor != Enrolled))
                throw new ArgumentException(nameof(semester));

            Enrolled = semester;
        }
    }

    public class Semester
    {
        public Semester Predecessor { get; }
    }
}
