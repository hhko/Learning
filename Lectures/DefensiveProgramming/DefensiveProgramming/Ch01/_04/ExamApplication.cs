using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._04
{
    public class ExamApplication
    {
        public ExamApplication(Student candidate, Subject subject, Professor admin)
        {
            if (candidate == null)
                throw new ArgumentNullException(nameof(candidate));

            if (subject == null)
                throw new ArgumentNullException(nameof(subject));

            if (admin == null)
                throw new ArgumentNullException(nameof(admin));
        }
    }
}
