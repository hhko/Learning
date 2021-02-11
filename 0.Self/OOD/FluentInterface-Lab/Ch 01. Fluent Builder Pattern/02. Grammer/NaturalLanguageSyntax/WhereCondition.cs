using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalLanguageSyntax
{
    public class WhereCondition
    {
        public enum ComparisonMethod
        {
            EqualTo,
            NotEqualTo
        }

        public string ColumnName { get; private set; }
        public ComparisonMethod Comparator { get; private set; }
        public object Value { get; private set; }

        public WhereCondition(string columnName, ComparisonMethod comparator, object value)
        {
            ColumnName = columnName;
            Comparator = comparator;
            Value = value;
        }
    }
}
