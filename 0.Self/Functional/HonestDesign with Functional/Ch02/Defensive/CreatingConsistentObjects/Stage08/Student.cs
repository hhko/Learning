using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage08
{
    public abstract class Student
    {
        public string Name { get; }

        public Semester Enrolled { get; private set; }
        //private bool _comesFromExchange { get;  }

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
        //private Student(bool comesFromExchange, string name)
        //private Student(string name)
        protected Student(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
            //_comesFromExchange = comesFromExchange;
        }

        // 3. 해결책
        // Factory Method을 통해 생성 의미(함수명)를 부여한다.
        //
        // 4. 문제점(3. 해결책)
        // Multiple factory methods indicate that the class is doing more than one thing.
        // 동일한 인스턴스를 생성하기 위한 복수개 Factory Method는 한개 이상의 역할을 요구하게 된다(SRP을 준수하지 못하게 된다).
        //     인스턴스 : Factory Method = 1 : N
        //  => 인스턴스 : 책임 = 1 : N 
        //
        // Rules of Thumb
        // Define one factory function per class.
        // Have no discrete parameters(no enums, booleans, etc.)
        //public static Student Create(string name) =>
        //    new Student(false, name);

        //public static Student CreateFromExchange(string name) =>
        //    new Student(true, name);

        public void Enroll(Semester semester)
        {
            // 생성을 위해 호출된 Factory Method에 따라 다르게 수행한다.
            //if (!_comesFromExchange && semester == null || semester.Predecessor != Enrolled)
            
            if (!CanEnroll(semester))
                throw new ArgumentException(nameof(semester));

            Enrolled = semester;
        }

        public abstract bool CanEnroll(Semester semester);
    }

    // Factory Method : 파생 클래스 = 1 : 1
    // 동일한 인스턴스를 반환하는 복수 Factory Method을 상속 클래스로 변경한다.
    public class RegularStudent : Student
    {
        public RegularStudent(string name) 
            : base(name)
        {

        }
        public override bool CanEnroll(Semester semester) =>
            semester != null && semester.Predecessor == base.Enrolled;
    }

    public class ExchangeStudent : Student
    {
        public ExchangeStudent(string name)
            : base(name)
        {

        }

        // Rele of Thumb
        // Naver accept null argument value
        public override bool CanEnroll(Semester semester) =>
            semester != null;
    }

    public class Semester
    {
        public Semester Predecessor { get; }
    }
}
