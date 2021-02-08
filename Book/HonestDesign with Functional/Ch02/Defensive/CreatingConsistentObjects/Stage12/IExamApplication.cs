using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage12
{
    public interface IExamApplication
    {
        Professor AdministeredBy { get; }
        Subject OnSubject { get; }
        Student TakenBy { get; }
    }
}
