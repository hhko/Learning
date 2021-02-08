using System;

namespace CreatingConsistentObjects.Stage12
{
    public class Student
    {
        public object Enrolled { get; private set; }

        internal bool HasPassedExm(Subject subject)
        {
            return true;
        }

        // Builder 패턴 장점 1.
        //  > 객체 생성 전에 유효성 검사를 할 수 있다.
        //  > 예외?
        public IExamApplication ApplyFor(Subject examOn, Professor administeredBy)
        {
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.OnSubject(examOn);
            builder.AdministeredBy(administeredBy);
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

        // Builder 패턴 장점 2.
        //   > 지연 실행(항상 객체가 생성된다)을 할 수 있다.
        public Func<IExamApplication> GetExamApplicationFactory(Subject examOn, Professor administeredBy)
        {
            ExamApplicationBuilder builder = new ExamApplicationBuilder();
            builder.OnSubject(examOn);
            builder.AdministeredBy(administeredBy);
            builder.TakenBy(this);

            // 즉시 실행
            if (!builder.CanBuild())
                throw new ArgumentException();

            // 지연 실행: 객체는 항상 생성된다(성공한다).
            return builder.Build;
        }
    }
}
