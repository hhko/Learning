using System;
using System.Collections.Generic;
using System.Text;

namespace Ch2.CreatingFixture.Sequence
{
    public class DebugMessageBuffer
    {
        public List<string> Messages { get; set; } = new List<string>();

        public int MessagesWritten { get; private set; }

        public void WriteMessages()
        {
            foreach (var message in Messages)
            {
                MessagesWritten++;
            }
        }
    }
}
