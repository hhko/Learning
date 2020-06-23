using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._05
{
    public class ExamApplication
    {
        public ExamApplication(Subject subject, Professor admin, Student candidate)
        {
            if (subject == null)
                throw new ArgumentNullException(nameof(subject));

            if (admin == null)
                throw new ArgumentNullException(nameof(admin));

            if (candidate == null)
                throw new ArgumentNullException(nameof(candidate));
        }
    }
}
