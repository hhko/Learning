using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._05
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

        public override bool Equals(object obj) =>
            Equals(obj as PersonalName);

        private bool Equals(PersonalName other) =>
            other != null &&
            ArePartsEqual(FirstName, other.FirstName) &&
            ArePartsEqual(MiddleName, other.MiddleName) &&
            ArePartsEqual(LastName, other.LastName);

        private bool ArePartsEqual(string part1, string part2) =>
            string.Compare(part1, part2, StringComparison.OrdinalIgnoreCase) == 0;

        public override int GetHashCode() =>
            FirstName.GetHashCode() ^
            MiddleName.GetHashCode() ^
            LastName.GetHashCode();
    }
}
