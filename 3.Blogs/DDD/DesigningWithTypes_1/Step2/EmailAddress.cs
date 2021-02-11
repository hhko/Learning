using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static LanguageExt.Prelude;

namespace Step2
{
    [Record]
    public partial struct EmailAddress
    {
        public readonly string Value;
    }

    public static class EmailAddressExt
    {
        public static Option<EmailAddress> CreateEmailAddresses(string s)
        {
            if (Regex.IsMatch(s, @"^\S+@\S+\.\S+$"))
                return EmailAddress.New(s);
            else
                return None;
        }

        public static ICreationResult<EmailAddress> CreateEmailAddress2(string s)
        {
            if (Regex.IsMatch(s, @"^\S+@\S+\.\S+$"))
            {
                // TODO
                // return Success<EmailAddress>.New(s);
                return Success<EmailAddress>.New(EmailAddress.New(s));
            }
            else
                return Error<EmailAddress>.New("Email address must contain an @ sign");
        }

        public static T CreateEmailAddressWithContinuations<T>(Func<EmailAddress, T> success, Func<string, T> failure, string s)
        {
            if (Regex.IsMatch(s, @"^\S+@\S+\.\S+$"))
                return success(EmailAddress.New(s));
            else
                return failure("Email address must contain an @ sign");
        }
    }
}
