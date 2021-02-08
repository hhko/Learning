// 객체 Lifecycle
//  > 생성 후 객체의 상태는 안전(Complete)하고 일관성(Consistent)이 있어야 한다.
// 기대효과
//  > 방어 코드가 필요없다.
// 방법
//  > 객체 생성 전에 일관성 기준을 위반하면 객체를 생성하지 않는다.
//  > THE OBJECT RULE
//    If you have the object, then it is fine.

using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage09
{
    public class Client
    {
        public void DoSomething()
        {
            // 과제
            // Constructing ExamApplication object
            //  - Student: takes the exam
            //  - Subject: in wihich the exam is taken
            //  - Professor: administers the exam
            // Rules
            //  - student != null
            //  - subject != null
            //  - professor != null
            //  - student enrolled semester of subject
            //  - student has not passed exam on subject
            //  - subject taught by professor

            // 1.1 문제점
            // We want an object, not an exception!
            // 객체를 생성할 때 예외를 기대하지는 않는다(기대값과 다르다).
            //
            // 1.2 문제점
            // 생성자는 성공 여부를 미리 알릴 수 없다(객체가 생성되기를 기대할 뿐이다).
            //  > 예외를 발생 시킨다.
            //  > NULL를 반환한다(불가능하다).
            // 1.3 문제점
            // try-catch is probably the heaviest
            // if-then-else you could ever think of
            // 객체 생성이라는 작은 행위에 예외 처리는 무거운 매커니즘을 적용하는 것이다. 
            //
            // 2. 해결책
            // 성공 여부를 미리 판단 후 객체를 생성한다.
            // 생성자는 절대 예외를 발생 시키지 않는다.
            //ExamApplication appl = new ExamApplication(student, subject, professor);
            // 
            // 1.4 문제점
            // 그 이후의 작업을 진행할 수 없다.
            //DealWith(appl); 
        }
    }

    public class ExamApplication
    {
        public ExamApplication(Student candidate, Subject subject, Professor admin)
        {
            if (candidate == null || subject == null || admin == null)
                throw new ArgumentNullException();

            //if ( <any other rule violated> )
            //    throw new ArgumentNullException();
        }
    }

    public class Student
    {

    }

    public class Subject
    {

    }

    public class Professor
    {

    }
}
