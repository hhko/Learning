using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalLanguageSyntax.Solved
{
    public interface ICanAddCondition
    {
        ICanAddWhereValue Where(string columnName);
        void AllRows();
    }
}
