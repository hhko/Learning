using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._04
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

                ExamApplication appl = new ExamApplication(subject, professor, student);
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
