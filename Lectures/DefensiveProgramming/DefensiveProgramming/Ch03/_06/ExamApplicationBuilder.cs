using Ch01._06.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._06
{
    public class ExamApplicationBuilder
    {
        private Professor Administrator { get; set; }
        private Subject Subject { get; set; }
        private Student Candidate { get; set; }

        public void AdministrateredBy(Professor administrator)
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

        // 사전 검사
        public bool CanBuild() =>
            Administrator != null &&
            Subject != null &&
            Candidate != null &&
            Candidate.Enrolled == Subject.TaughtDuring &&
            Candidate.HasPassedExam(Subject) &&
            Subject.TaughtBy == Administrator;

        public IExamApplication Build()
        {
            // 사전 검사
            if (!CanBuild())
                throw new InvalidOperationException();

            return new ExamApplication(Subject, Administrator, Candidate);
        }
    }
}
