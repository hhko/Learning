using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingConsistentObjects.Stage01
{
    public class Student
    {
        // 질문
        //  - 빈 문자열일 때?
        //  - NULL 객체일 때?
        //
        // 객체의 내부 상태가 일관성이 없을 때?
        // Object's Internal Operation
        //  - what will happen to the object if its state is inconsistent?
        //  - 상태가 일관성이 없으면 개체는 어떻게됩니까?
        //    > State error will cause execution error.
        //    > Defensive code is mandatory.
        // 일관성이 없는 객체의 내부 상태가 공개될 때?
        // Dependee's Operation: 일관성이 없는(모순되는) 상태가 노출되면
        //  - what will happen to others if an object publicly exposes inconsistent state? 
        //  - 개체가 일관성이 없는 상태를 공개적으로 노출하면 다른 사람에게는 어떻게됩니까?
        private string Name { get; set; }
    }
}
