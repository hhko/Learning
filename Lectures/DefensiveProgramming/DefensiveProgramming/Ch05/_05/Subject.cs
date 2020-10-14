using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch03._05
{
    public class Subject
    {
        private string Name { get; }
        private Semester TaughtDuring { get; }
        private Professor TaughtBy { get; }
        private IList<Student> EnlistedStudents { get; } = new List<Student>();

        public Subject(string name, Semester taughtDuring, Professor taughtBy)
        {
            if (string.IsNullOrEmpty(name))
                throw new AggregateException(nameof(name));

            if (taughtDuring == null)
                throw new ArgumentException(nameof(taughtDuring));

            if (taughtBy == null)
                throw new ArgumentException(nameof(taughtBy));

            Name = name;
            TaughtDuring = taughtDuring;
            TaughtBy = taughtBy;
        }

        public void Enlist(Student student)
        {
            if (student == null)
                throw new ArgumentException(nameof(student));

            EnlistedStudents.Add(student);
        }

        //public void AssignGrades(IEnumerable<(string, Grade)> grades)
        //{
        //    var listedGrades = grades.Select(tuple =>
        //    {
        //        var (_1, _2) = tuple;
        //
        //        return new
        //        {
        //            Student = EnlistedStudents.First(student =>
        //                string.Compare(student.Name, _1, StringComparison.OrdinalIgnoreCase) == 0),
        //            Grade = _2
        //        };
        //    });
        //
        //    foreach (var studentGrade in listedGrades)
        //        studentGrade.Student.AddGrade(this, studentGrade.Grade);
        //}

        public void AssignGrades(IEnumerable<(PersonalName, Grade)> grades)
        {
            var listedGrades = grades.Select(tuple =>
            {
                var (_1, _2) = tuple;

                return new
                {
                    // 비교를 캡슐화한다.
                    //string.Compare(student.Name, _1, StringComparison.OrdinalIgnoreCase) == 0),
                    Student = EnlistedStudents.First(student => student.Name.Equals(_1)),
                    Grade = _2
                };
            });

            foreach (var studentGrade in listedGrades)
                studentGrade.Student.AddGrade(this, studentGrade.Grade);
        }
    }
}
