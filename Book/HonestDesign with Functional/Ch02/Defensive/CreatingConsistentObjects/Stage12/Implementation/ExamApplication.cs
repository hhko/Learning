using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage12.Implementation
{
    public class ExamApplication : IExamApplication
    {
        public Professor AdministeredBy { get; private set; }
        public Subject OnSubject { get; private set; }
        public Student TakenBy { get; private set; }

        public ExamApplication(Subject subject, Professor adminstrator, Student candidate)
        {
            OnSubject = subject;
            AdministeredBy = adminstrator;
            TakenBy = candidate;
        }
    }
}
