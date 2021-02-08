using CreatingConsistentObjects.Stage12.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage12
{
    public class Client
    {
        public void DoSomething()
        {
            Professor professor = null;
            Subject subject = null;
            Student student = null;

            // ...

            // 문제점
            //  > new ExamApplication
            //  > new ExamApplicationBuilder
            //  모두 접근 가능하다.
            // 개선점: Defensive Trick(Nesting Namespaces)
            //  > namespace로 분리한다.
            //  > 동일한 공간에서 모두 접근하지 않는다.
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.AdministeredBy(professor);
            builder.OnSubject(subject);
            builder.TakenBy(student);
            if (builder.CanBuild())
            {
                IExamApplication appl = builder.Build();
                DealWith(appl);
            }
            else
            {
                DisplayWarning();
            }
        }

        private void DealWith(IExamApplication appl)
        {
        }

        private void DisplayWarning()
        {
        }
    }

    public class ExamApplicationBuilder
    {
        private Professor Administrator { get; set; }
        private Subject Subject { get; set; }
        private Student Candidate { get; set; }

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

        public bool CanBuild() =>
            Administrator != null &&
            Subject != null &&
            Candidate != null &&
            Candidate.Enrolled == Subject.TaughtDuring &&
            Candidate.HasPassedExm(Subject) &&
            Subject.TaughtBy == Administrator;

        public IExamApplication Build()
        {
            if (!CanBuild())
                throw new InvalidOperationException();

            return new ExamApplication(Subject, Administrator, Candidate);
        }
    }
}
