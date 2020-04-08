using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CouldBeAbsent.Stage2
{
    public class Hello
    {
        [Pure]
        public static string Greet(Option<string> greetee) =>
            greetee.Match(
                None: () => "Sorry, who?",
                Some: name => $"Hello {name}");
    }
}
