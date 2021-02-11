using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._06
{
    public class ExamApplicationClient
    {
        public void DoSomething()
        {
            Student student = new Student();
            Subject subject = null;
            Professor professor = null;

            try
            {
                IExamApplication appl = student.ApplyFor(subject, professor); ;
                DealWith(appl);
            }
            catch (Exception _)
            {
                DisplayWarning(_);
            }
        }

        public void DealWith(IExamApplication appl)
        {

        }

        private void DisplayWarning(Exception ex)
        {

        }
    }
}
