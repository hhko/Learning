using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._04
{
    public class PersonalName
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        public PersonalName(string firstName, string middleName, string lastName)
        {
            if (IsBadMandatoryPart(firstName) ||
                IsBadOptionalPart(middleName) ||
                IsBadMandatoryPart(lastName))
                throw new ArgumentException();

            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        private bool IsBadOptionalPart(string part) =>
            part == null ||
            (part.Length > 0 && char.IsHighSurrogate(part[part.Length - 1]));

        private bool IsBadMandatoryPart(string part) =>
            IsBadOptionalPart(part) || part == string.Empty;

    }
}
