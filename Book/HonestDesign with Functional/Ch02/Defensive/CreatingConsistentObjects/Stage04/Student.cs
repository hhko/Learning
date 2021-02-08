using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage04
{
    public class Student
    {
        public string Name { get; }

        // Expression-bodied syntax can be used when there is no defensive code
        // 방어 코드가 제거되면 C# Expression-bodied 문법으로 코드를 더 단순화 시킬 수 있다. 
        public int NameLength => 
            Name.Length;

        public char NameInitialLetter => 
            Name[0];
        
        // Separation of responsibilities
        //  - Constructor ensures that only valid objects can be created.
        //    유효한 객체만 생성된다.
        //  - The caller will never be able to obtain an inconsistent object.
        //    > Never accept null
        //    호출자는 NULL을 반환받지 않는다(일관성 없는 객체는 반환하지 않는다).
        //  - Provide your own factory function for every stateful object.
        //    > complete & consistent
        public Student(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }
    }
}
