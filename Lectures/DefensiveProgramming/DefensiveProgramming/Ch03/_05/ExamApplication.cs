using System;
using System.Collections.Generic;
using System.Text;

namespace Ch01._05
{
    public class ExamApplication
    {
        public Subject Subject { get; }
        public Professor Admin { get; }
        public Student Candidate { get; }

        public ExamApplication(Subject subject, Professor admin, Student candidate)
        {
            // 유효성 검사
            if (candidate == null)
                // 유효성 검사의 실패는 예외 밖에 전달할 방법이 없다.
                // Caller는 try-catch을 요구 받는다.
                throw new ArgumentNullException(nameof(subject));

            if (admin == null)
                throw new ArgumentNullException(nameof(admin));

            if (candidate == null)
                throw new ArgumentNullException(nameof(candidate));

            Subject = subject;
            Admin = admin;
            Candidate = candidate;
        }
    }
}
