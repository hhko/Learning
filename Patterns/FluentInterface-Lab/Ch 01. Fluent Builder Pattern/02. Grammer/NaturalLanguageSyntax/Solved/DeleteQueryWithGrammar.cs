
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalLanguageSyntax.Solved
{
    public class DeleteQueryWithGrammar : ICanAddCondition, ICanAddWhereValue, ICanAddWhereOrRun
    {
        private readonly string _tableName;
        private readonly List<WhereCondition> _whereConditions = new List<WhereCondition>();

        private string _currentWhereConditionColumn;

        // Private constructor, to force object instantiation from the fluent method(s)
        private DeleteQueryWithGrammar(string tableName)
        {
            _tableName = tableName;
        }

        #region Initiating Method(s)

        public static ICanAddCondition DeleteRowsFrom(string tableName)
        {
            return new DeleteQueryWithGrammar(tableName);
        }

        #endregion

        #region Chaining Method(s)

        public ICanAddWhereValue Where(string columnName)
        {
            _currentWhereConditionColumn = columnName;

            return this;
        }

        public ICanAddWhereOrRun IsEqualTo(object value)
        {
            _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.EqualTo, value));

            return this;
        }

        public ICanAddWhereOrRun IsNotEqualTo(object value)
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
