using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._05
{
    public class ExamApplicationClient
    {
        public void DoSomething()
        {
            Student student = null;
            Subject subject = null;
            Professor professor = null;

            if (Alright(subject, professor, student))
            {
                ExamApplication appl = new ExamApplication(subject, professor, student);
                DealWith(appl);
            }
            else
            { 
                DisplayWarning();
            }
        }

        public bool Alright(Subject subject, Professor professor, Student student)
        {
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.OnSubject(subject);
            builder.AdministrateredBy(professor);
            builder.TakenBy(student);

            return builder.CanBuild();
        }

        public void DealWith(ExamApplication appl)
        {

        }

        private void DisplayWarning()
        {

        }
    }
}
