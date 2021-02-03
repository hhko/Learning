using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using static System.Console;

namespace CouldBeAbsent.Stage1
{
    public class IndexerIdiosyncracy
    {
        public static void Impure()
        {
            // [] 메서드 Signature는 "string -> string"이다.
            //
            // 문제점: NameValueCollection, Dictionary 모두 [] 메서드가 정직하지 않다.
            // - NameValueCollection는 데이터가 없을 때 NULL을 반환한다.
            // - Dictionary는 데이터가 없을 때 예외를 발생 시킨다.
            try
            {
                // 예외를 발생 시키지 않는다(NULL을 반환한다).
                var empty = new NameValueCollection();
                var green = empty["green"];
                WriteLine("green!");

                // 예외(KeyNotFoundException)를 발생 시킨다.
                var alsoEmpty = new Dictionary<string, string>();
                var blue = alsoEmpty["blue"];
                WriteLine("blue!");
            }
            catch (Exception ex)
            {
                WriteLine(ex.GetType().Name);
            }
        }
    }
}
