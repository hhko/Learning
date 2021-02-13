using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._09.__Domain__.Models
{
    public class Professor
    {
        public Professor(PersonalName name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public PersonalName Name { get; }
    }
}
