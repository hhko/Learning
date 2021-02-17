using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using static LanguageExt.Prelude;

namespace Step2
{
    [Record]
    public partial class StateCode
    {
        public readonly string Value;
    }

    public static class StateCodeExt
    {
        public static Option<StateCode> CreateStateCode(string s)
        {
            var uppercaseState = s.ToUpper();
            var stateCodes = new List<string> { "AZ", "CA", "NY" };
            return stateCodes.Exists(_ => _ == uppercaseState) switch
            {
                true => StateCode.New(uppercaseState),
                false => None
            };
        }
    }
}
