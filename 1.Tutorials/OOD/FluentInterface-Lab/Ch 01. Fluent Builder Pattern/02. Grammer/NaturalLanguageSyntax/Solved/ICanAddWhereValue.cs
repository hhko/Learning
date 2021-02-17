using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalLanguageSyntax.Solved
{
    public interface ICanAddWhereValue
    {
        ICanAddWhereOrRun IsEqualTo(object value);
        ICanAddWhereOrRun IsNotEqualTo(object value);
    }
}
