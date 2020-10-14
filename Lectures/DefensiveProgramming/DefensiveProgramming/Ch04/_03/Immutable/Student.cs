using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ch02._03.Immutable
{
    [Record]
    public partial class Student
    {
        public readonly string Name;
    }
}
