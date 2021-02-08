using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalLanguageSyntax.Solved
{
    public interface ICanAddWhereOrRun
    {
        ICanAddWhereValue Where(string columnName);
        void RunNow();
    }
}
