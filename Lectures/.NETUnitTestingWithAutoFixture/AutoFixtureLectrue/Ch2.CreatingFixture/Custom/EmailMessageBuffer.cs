using System;
using System.Collections.Generic;
using System.Text;

namespace Ch2.CreatingFixture
{
    public class EmailMessageBuffer
    {
        public List<EmailMessage> Emails { get; private set; } = new List<EmailMessage>();

        public void Add(EmailMessage message)
        {
            Emails.Add(message);
        }
    }
}
