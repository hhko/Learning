using ManagingSideEffects.Stage1;
using ManagingSideEffects.Stage2;
using ManagingSideEffects.Stage3;
using System;

namespace ManagingSideEffects
{
    class Program
    {
        static void Main(string[] args)
        {
            // 불순 함수
            Impure impure = new Impure();
            impure.SideEffects();

            // 순수 함수 발견
            PureDiscovery pureDiscovery = new PureDiscovery();
            pureDiscovery.SideEffects();

            // 순수 함수 합성
            PureComposition pureComposition = new PureComposition();
            pureComposition.SideEffects();
        }
    }
}
