using NaturalLanguageSyntax.Problem_without_Grammer;
using NaturalLanguageSyntax.Solved;
using System;

namespace NaturalLanguageSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Problem without Grammer
            //
            DeleteQueryWithoutGrammar
                .DeleteRowsFrom("Account")  // Initiating Method(s), static method
                .IsNotEqualTo("Admin")      // Chaining Method(s)
                .IsEqualTo("Inactive")
                .Where("Status")
                .RunNow();                  // Executing Method(s)

            // vs.


            //-------------------------------------------------------------------------------------
            //               | Where  IsEqualTo  IsNotEqualTo  AllRows  RunNow
            //               |     W          I             N        A       N
            //-------------------------------------------------------------------------------------
            // DeleteRowFrom |     Y                                 Y           ICanAddCondition
            // Where         |                Y             Y                    ICanAddWhereValue
            // IsEqualTo     |     Y                                         Y   ICanAddWhereOrRun
            // IsNotEqualTo  |     Y                                         Y   ICanAddWhereOrRun
            //-------------------------------------------------------------------------------------

            //
            // With Grammer
            // Problem without Grammer
            //
            DeleteQueryWithGrammar
                .DeleteRowsFrom("Account")  // Initiating Method(s), static method
                .Where("Status")            // Chaining Method(s), ICanAddCondition
                .IsNotEqualTo("Admin")      // Chaining Method(s), ICanAddWhereValue, 
                .RunNow();                  // Executing Method(s)
        }
    }
}
