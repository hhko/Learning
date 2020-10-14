using System;
using System.Collections.Generic;
using System.Text;

namespace Ch02._05
{
    public class PersonalName
    {
        private readonly string _name;

        public PersonalName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            if (char.IsHighSurrogate(name[name.Length - 1]))
                throw new ArgumentException();

            _name = name;
        }

        public string Initial =>
            _name.Substring(0, char.IsSurrogate(_name[0]) ? 2 : 1);
    }
}
