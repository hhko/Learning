using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage10
{
    public class Client
    {
        public void DoSomething()
        {
            Professor professor = null;
            Subject subject = null;
            Student student = null;

            // ...

            // 개선점: 
            //  - 예외 처리가 없다.
            //  - 객체 생성 전에 사전에 판단한다.
            // 문제점:
            //  - Validation function and constructor must contain the same validation logic
            //  - 유효성 검사 코드가 Alight와 ExamApplication 생성자에 중복되어 있다.
            // 개선 계획
            //  - We can wrap validation and construction into an object
            //  - 객체(Builder)에 유효성 검사와 객체 생성 역햘을 수행하게 한다.
            if (Alright(professor, subject, student))
            {
                ExamApplication appl = new ExamApplication(subject, professor, student);
                DealWith(appl); 
            }
            else
            {
                DisplayWarning();
            }
        }

        private void DealWith(ExamApplication appl)
        {
        }

        private bool Alright(Professor professor, Subject subject, Student student)
        {
            return true;
        }

        private void DisplayWarning()
        {
        }
    }

    public class ExamApplication
    {
        public ExamApplication(Subject subject, Professor admin, Student candidate)
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
