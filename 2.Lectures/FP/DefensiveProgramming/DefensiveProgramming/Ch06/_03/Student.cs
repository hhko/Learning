using System;
using System.Collections.Generic;
using System.Text;

namespace Ch06._03
{
    class Student
    {
        public Semester Enrolled { get; }

        public bool HasPassedExam(Subject subject)
        {
            return false;
        }

        public bool CanApplyFor([NotNull] Subject examOn, [NotNull] Professor administreredBy)
        {
            // 1. NULL
            // [NotNull]
            
            if (
                // 2. Business Rule(Dynamic)
                Enrolled != examOn.TaughtDuring ||
                HasPassedExam(examOn) ||
                // 3. Business Rule(Static)
                !examOn.IsTaughtBy(administreredBy))
                return true;
            else
                return false;
        }

        public IExamApplication ApplyFor(Subject examOn, Professor administreredBy)
        {
            // 1. NULL
            //if (administreredBy == null ||
            //    examOn == null ||
            //
            // 2. Business Rule(Dynamic)
            //    Enrolled != examOn.TaughtDuring ||
            //    HasPassedExam(examOn) ||
            //
            // 3. Business Rule(Static)
            //    !examOn.IsTaughtBy(administreredBy))
            //    throw new ArgumentException();

            if (!CanApplyFor(examOn, administreredBy))
                throw new ArgumentException();

            return null;
        }
    }

    public class ExamApplicationBuilder
    {
        Professor _administrator;
        Subject _subject;
        Student _candidate;

        //public bool CanBuild() =>
        //    _administrator != null &&
        //    _subject != null &&
        //    _candidate != null &&
        //    _candidate.Enrolled == _subject.TaughtDruing &&
        //    !_candidate.HasPassedExam(_subject) &&
        //    _subject.TaughtBy == _administrator;

        public bool CanBuild() =>
            _administrator != null &&
            _subject != null &&
            _candidate != null &&
            _candidate.Enrolled == _subject.TaughtDuring &&
            !_candidate.HasPassedExam(_subject) &&
            _subject.IsTaughtBy(_administrator);
    }

    public class Professor
    {

    }

    public class Subject
    {
        public Semester TaughtDuring { get; }

        //public Professor TaughtBy { get; }

        public bool IsTaughtBy(Professor professor)
        {
            return false;
        }
    }

    public class Semester
    {

    }

    public interface IExamApplication
    {

    }

    public class NotNullAttribute : Attribute
    {

    }
}
