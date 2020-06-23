using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._05
{
    public class ExamApplicationClient
    {
        public void DoSomething()
        {
            try
            {
                Student student = null;
                Subject subject = null;
                Professor professor = null;

                ExamApplication appl = new ExamApplication(student, subject, professor);
                DealWith(appl);
            }
            catch (Exception ex)
            {
                DisplayWarning(ex);
            }
        }

        public void DealWith(ExamApplication appl)
        {

        }

        private void DisplayWarning(Exception ex)
        {

        }
    }
}
