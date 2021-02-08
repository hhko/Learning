using System;
using System.Collections.Generic;
using System.Text;

namespace Null_02_ProducerPerspective
{
    public interface IUser
    {
        string Name { get; }

        void IncrementSessionTicket();
    }
}
