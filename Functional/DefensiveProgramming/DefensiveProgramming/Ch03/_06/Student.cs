using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._06
{
    public class Student
    {
        public Semester Enrolled { get; }

        public bool HasPassedExam(Subject subject)
        {
            return true;
        }

        public IExamApplication ApplyFor(Subject examOn, Professor administeredBy)
        {
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.OnSubject(examOn);
            builder.AdministrateredBy(administeredBy);
            builder.TakenBy(this);

            if (builder.CanBuild())
            {
                return builder.Build();
            }
            else
            {
                // Think of something smarter
                throw new ArgumentException();
            }
        }

        public Func<IExamApplication> GetExamApplicationFactory(Subject examOn, Professor administeredBy)
        {
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.OnSubject(examOn);
            builder.AdministrateredBy(administeredBy);
            builder.TakenBy(this);

            if (!builder.CanBuild())
            {
                // Think of something smarter
                throw new ArgumentException();
            }
            
            return builder.Build;
        }
    }
}
