using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01_Constraints
{
    //
    // 값/참조 타입을 지정합니다.
    //
    class GenericType<T> 
        where T : class
    {
        void Do(T entity)
        {
            entity = null;          // 참조 타입
            entity = default(T);    // 값, 참조 타입 모두 가능하다.
        }
    }

    //
    // 생성 시킨다.
    //
    class GenericCreate<T> 
        where T : new()             // 반드시 마지막에 위치 시켜야 한다.
                                    // 기본 생성자를 제공해야 한다.
    {
        T Create()
        {
            return new T();     
        }
    }

    // 
    // 타입 범위를 제약 시킨다.
    //
    interface IEntity
    {
        bool IsValid();
    }

    class Person<T1> 
        where T1 : IEntity, new()           // 타입 정보
    {
        void Add(T1 entity)
        {
            if (!entity.IsValid())
                return;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
