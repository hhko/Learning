using System;
using System.Collections.Generic;
using System.Text;

namespace Null_03_AntiProducerPerspective
{
    public interface IUser
    {
        //
        // 문제: 소비자는 Null을 확인해야 한다(Null Object Anit-Pattern).
        //
        bool IsNull { get; }

        string Name { get; }

        void IncrementSessionTicket();
    }
}
