using System;
using static Step2.StateCodeExt;
using static Step2.EmailAddressExt;
using static LanguageExt.Prelude;
using LanguageExt;

namespace Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = CreateStateCode("CA");
            var s2 = CreateStateCode("XX");

            var e1 = CreateEmailAddresses("a@example.com");
            var e2 = CreateEmailAddresses("example.com");

            var e3 = CreateEmailAddresses("a@example.com") switch
            {
                var _ when None => "... ignore?",
                _ => "... do something with email",
            };

            var e4 = CreateEmailAddress2("example.com");

            Func<EmailAddress, Unit> success1 = _ =>
            {
                Console.WriteLine($"success creating email {_}");
                return Unit.Default;
            };
            Func<string, Unit> failure1 = _ =>
            {
                Console.WriteLine($"error creating email: {_}");
                return Unit.Default;
            };
            CreateEmailAddressWithContinuations(success1, failure1, "example.com");
            CreateEmailAddressWithContinuations(success1, failure1, "x@example.com");

            Func<EmailAddress, Option<EmailAddress>> success2 = _ => Some(_);
            Func<string, Option<EmailAddress>> failure2 = _ => None;
            CreateEmailAddressWithContinuations(success2, failure2, "example.com");
            CreateEmailAddressWithContinuations(success2, failure2, "x@example.com");

            Func<EmailAddress, EmailAddress> success3 = _ => _;
            Func<string, EmailAddress> failure3 = _ => throw new Exception(_);
            CreateEmailAddressWithContinuations(success3, failure3, "example.com");
            CreateEmailAddressWithContinuations(success3, failure3, "x@example.com");

            Func<EmailAddress, Option<EmailAddress>> success4 = _ => Some(_);
            Func<string, Option<EmailAddress>> failure4 = _ => None;
            var x = curry<Func<EmailAddress, Option<EmailAddress>>, Func<string, Option<EmailAddress>>, string, Option<EmailAddress>>(CreateEmailAddressWithContinuations);
            var createEmail = x(success4)(failure4);

            var e5_1 = createEmail("example.com");
            var e5_2 = createEmail("x@example.com");

            Console.WriteLine("Hello World!");

            ////Some(Add2)
            ////    .Apply(1)
            ////    .Apply(2);
            ////Some(1).Map(Add1).A.Apply(3);
            //var x1 = Some(curry<int, int, int>(Add1))
            //    .Apply(1)
            //    .Apply(2);

            //var x2 = Some(curry<int, int, Option<int>>(Add2))
            //    .Apply(1)
            //    .Apply(2);

            //Some(curry<int, int, Option<int>>(Add2))
            //    .Apply(1)
        }

        static int Add1(int x, int y)
        {
            return x + y;
        }

        static Option<int> Add2(int x, int y)
        {
            return x + y;
        }
    }
}
