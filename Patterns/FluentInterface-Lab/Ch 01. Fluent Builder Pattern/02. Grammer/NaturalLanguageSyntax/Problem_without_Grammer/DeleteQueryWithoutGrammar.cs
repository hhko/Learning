using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalLanguageSyntax.Problem_without_Grammer
{
    public class DeleteQueryWithoutGrammar
    {
        private readonly string _tableName;
        private readonly List<WhereCondition> _whereConditions = new List<WhereCondition>();

        private string _currentWhereConditionColumn;

        // Private constructor, to force object instantiation from the fluent method(s)
        private DeleteQueryWithoutGrammar(string tableName)
        {
            _tableName = tableName;
        }

        #region Initiating Method(s)

        public static DeleteQueryWithoutGrammar DeleteRowsFrom(string tableName)
        {
            return new DeleteQueryWithoutGrammar(tableName);
        }

        #endregion

        #region Chaining Method(s)

        public DeleteQueryWithoutGrammar Where(string columnName)
        {
            _currentWhereConditionColumn = columnName;

            return this;
        }

        public DeleteQueryWithoutGrammar IsEqualTo(object value)
        {
            _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.EqualTo, value));

            return this;
        }

        public DeleteQueryWithoutGrammar IsNotEqualTo(object value)
        {
            _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.NotEqualTo, value));

            return this;
        }

        #endregion

        #region Executing Method(s)

        public void AllRows()
        {
            ExecuteThisQuery();
        }

        public void RunNow()
        {
            ExecuteThisQuery();
        }

        #endregion

        private void ExecuteThisQuery()
        {
            // Code to build and execute the delete query
        }
    }
}
