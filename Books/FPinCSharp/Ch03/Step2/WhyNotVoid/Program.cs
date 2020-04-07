using System;
using System.IO;
using System.Text;

namespace WhyNotVoid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stage 1: Func vs. Action
            // - 문제점: Time 메서드가 2개이고, 거의 중복 코드로 구현되어 있다.
            {
                // 반환 값이 있을 때: Func
                var contents = Stage1.Instrumentation.Time("reading from file.txt",
                    () => FileFake.ReadAllText("file.txt"));

                // 반환 값이 없을 때: Action
                Stage1.Instrumentation.Time("writing to file.txt",
                    () => FileFake.AppendAllText("file.txt", "New content!", Encoding.UTF8));
            }

            // Stage 2: Unit 
            // - 개선점: void 타입을 Unit으로 변경하여 Action을 Func을 구분하지 않는다(일관성consistency을 제공한다).
            //   - void는 타입이 아니다.
            //   - Unit은 타입이다(데이터가 없음the absence of data을 나타낸다).
            // - 문제점: 모든 Action을 Func으로 변환 시켜야 한다.
            {
                // 반환 값이 있을 때: Func
                var contents = Stage2.Instrumentation.Time("reading from file.txt",
                    () => FileFake.ReadAllText("file.txt"));

                // 반환 값이 없을 때: Action
                Stage2.Instrumentation.Time("writing to file.txt",
                    () => FileFake.AppendAllText("file.txt", "New content!", Encoding.UTF8));
            }
        }
    }

    public static class FileFake
    {
        public static string ReadAllText(string fileName)
        {
            return "Hello";
        }

        public static void AppendAllText(string fileName, string contents, Encoding encoding)
        {

        }
    }
}
