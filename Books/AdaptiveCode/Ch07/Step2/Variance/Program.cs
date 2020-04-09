using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02_Variance
{
    class Level1 { }
    class Level2 : Level1 { }
    class Level3 : Level2 { }

    interface IInvariant<T> { }
    interface IReadOnlyRepo<out T> { }
    interface IWriteOnlyRepo<in T> { }

    class Program
    {
        static void Main(string[] args)
        {
            //
            // 1. 다형성
            //
            // 좌측 = 우측
            // 생성 타입 | 부모 타입 = 생성 타입
            //
            string s = "Hello";
            object o = s;                                   // 부모 타입

            Level2 l22 = new Level2();                      // 같은 타입(불변)
            Level1 l12 = new Level2();                      // 부모 타입
            //Level3 l32 = new Level2();                    // 자식 타입, 에러


            //
            // 2. Generic 불변성
            //
            IEnumerable<Level2> y = null;
            Dictionary<Level2, Level2> x = null;
            List<Level2> values22 = new List<Level2>();     // 같은 타입
            //List<Level1> values12 = new List<Level2>();   // 부모 타입, 에러
            //List<Level3> values32 = new List<Level2>();   // 자식 타입, 에러

            IInvariant<Level2> valuei22 = null;
            IInvariant<Level2> i22 = valuei22;              // 같은 타입
            //IInvariant<Level1> i12 = valuei22;            // 부모 타입, 에러
            //IInvariant<Level3> i32 = valuei22;            // 자식 타입, 에러


            //
            // 3. Generic 공변성
            // 
            //  Level1 → IWriteOnlyRepo<Level1>
            //    ↑          ↑     
            //  Level2 → IWriteOnlyRepo<Level2>
            //
            IReadOnlyRepo<Level2> out22 = null;
            IReadOnlyRepo<Level2> wo22 = out22;             // 같은 타입
            IReadOnlyRepo<Level1> wo12 = out22;             // 부모 타입
            //IWriteOnlyRepo<Level3> wo32 = out22;          // 자식 타입, 에러

            Func<Level2> fun22 = Program.Fun;               // 같은 타입
            Func<Level1> fun12 = Program.Fun;               // 부모 타입
            //Func<Level3> fun32 = Program.Fun;               // 자식 타입, 에러


            //
            // 4. Generic 반공변성(상속 관계가 역전된다)
            //
            //  Level2 ↘ IWriteOnlyRepo<Level3>
            //    ↑          ↑         
            //  Level3 ↗ IWriteOnlyRepo<Level2>
            //    
            //
            IWriteOnlyRepo<Level2> in22 = null;
            IWriteOnlyRepo<Level2> ro22 = in22;             // 같은 타입
            //IReadOnlyRepo<Level1> ro12 = in22;            // 부모 타입, 에러
            IWriteOnlyRepo<Level3> ro31 = in22;             // 자식 타입

            Action<Level2> a22 = Program.Act;               // 같은 타입
            //Action<Level1> a12 = Program.Act;             // 부모 타입, 에러
            Action<Level3> a32 = Program.Act;               // 자식 타입
        }

        private static Level2 Fun()
        {
            return null;
        }

        private static void Act(Level2 level2)
        {
        }
    }
}
