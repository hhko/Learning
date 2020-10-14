using System;
using System.Collections.Generic;
using System.Text;

namespace Ch02._03
{
    public class ImmutableStudent
    {
        private string Name { get; }
        
        public ImmutableStudent(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            if (char.IsHighSurrogate(name[name.Length - 1]))
                throw new ArgumentException();

            Name = name;
        }

        public string NameInitial =>
            Name.Substring(0, char.IsSurrogate(Name[0]) ? 2 : 1);

        public ImmutableStudent WithName(string name) =>
            new ImmutableStudent(name);
    }
}
