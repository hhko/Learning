using System;
using System.Collections.Generic;
using System.Text;

namespace Ch02._04
{
    public class Student
    {
        public string Name { get; }

        private Dictionary<Subject, Grade> Grades = new Dictionary<Subject, Grade>();

        public Student(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            if (char.IsHighSurrogate(name[name.Length - 1]))
                throw new ArgumentException();

            Name = name;
        }

        public string NameInitial =>
            Name.Substring(0, char.IsSurrogate(Name[0]) ? 2 : 1);

        public void AddGrade(Subject subject, Grade grade)
        {
            // 방어 코드를 근본적으로 제겅하는 방법을 찾아보자.
            if (!Enum.IsDefined(typeof(Grade), grade))
                throw new ArgumentException(nameof(grade));
            if (subject == null || !IsEnlistedFor(subject))
                throw new ArgumentException(nameof(subject));
            if (Grades.ContainsKey(subject) && Grades[subject] != Grade.F)
                throw new ArgumentException();

            Grades[subject] = grade;
        }

        private bool IsEnlistedFor(Subject subject) =>
            true;
    }
}
