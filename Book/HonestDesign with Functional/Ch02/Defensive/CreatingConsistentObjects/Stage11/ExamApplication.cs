using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage11
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
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.AdministeredBy(professor);
            builder.OnSubject(subject);
            builder.TakenBy(student);
            if (builder.CanBuild())
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

        private void DisplayWarning()
        {
        }
    }

    public class ExamApplicationBuilder
    {
        public Professor Administrator { get; private set; }
        public Subject Subject { get; private set; }
        public Student Candidate { get; private set; }

        public void AdministeredBy(Professor administrator)
        {
            Administrator = administrator;
        }

        public void OnSubject(Subject subject)
        {
            Subject = subject;
        }

        public void TakenBy(Student candidate)
        {
            Candidate = candidate;
        }

        // CanBuild is a public method.
        // It indicates whether it is safe to call Build or not
        // 유효성 검사를 객체 생성 전에 수행하여 확인할 수 있다.
        //
        // Existential Precondition
        //  > A rule which must be satisfied before an object can be constructed.
        // Reinforcing the OBJECT RULE
        //  > If you have an object, then it is fine.
        //  > 객체가 생성딘 후에는 규칙을 다시 확인할 필요가 없다(방어 코드를 구현할 필요가 없다).
        public bool CanBuild() =>
            Administrator != null &&
            Subject != null &&
            Candidate != null &&
            Candidate.Enrolled == Subject.TaughtDuring &&
            Candidate.HasPassedExm(Subject) &&
            Subject.TaughtBy == Administrator;

        public ExamApplication Build()
        {
            if (!CanBuild())
                throw new InvalidOperationException();

            return new ExamApplication(Subject, Administrator, Candidate);
        }
    }

    public class ExamApplication
    {
        public ExamApplication(Subject subject, Professor admin, Student candidate)
        {
            //if (candidate == null || subject == null || admin == null)
            //    throw new ArgumentNullException();

            //if ( <any other rule violated> )
            //    throw new ArgumentNullException();
        }
    }

    public class Student
    {
        public object Enrolled { get; private set; }

        internal bool HasPassedExm(Subject subject)
        {
            return true;
        }
    }

    public class Subject
    {
        public object TaughtDuring { get; private set; }

        public Professor TaughtBy { get; private set; }
    }

    public class Professor
    {

    }
}
