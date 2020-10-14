using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch03._03
{
    public class Student
    {
        private Dictionary<Subject, Grade> Grades = new Dictionary<Subject, Grade>();
    
        public void AddGrade(Subject subject, Grade grade)
        {
            //if (!Enum.IsDefined(typeof(Grade), grade))
            //{
            //    throw new ArgumentException(nameof(grade));
            //}
            if (grade == null)
                throw new ArgumentException(nameof(grade));

            if (subject == null || !IsEnlistedFor(subject))
                throw new ArgumentException(nameof(subject));

            if (Grades.ContainsKey(subject) && Grades[subject] != Grade.F)
                throw new ArgumentException();

            Grades[subject] = grade;
        }

        private bool IsEnlistedFor(Subject subject) => true;

        public double AverageGrade =>
            Grades.Values
                .Select(grade => grade.NumericEquivalent)
                .Where(value => value > 0)
                .Average();
    }

    public class Subject
    {

    }
}
