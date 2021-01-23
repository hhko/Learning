using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Step_01_IEquatable.UnitTests
{
    public class FullNameSpecs
    {
        [Fact]
        public void ShoudFindFullNameInList()
        {
            var fullNames = new List<FullName>();
            fullNames.Add(new FullName("고", "길동"));

            // 비교 호출 순서
            //   1. IEquatable<T>.Equals(T)
            //   2. bool Equals(object obj)
            //
            // https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1?view=net-5.0
            // For a value type, 
            //   you should always implement IEquatable<T> and override Equals(Object) for better performance. 
            //   Equals(Object) boxes value types and relies on reflection to compare two values for equality. 

            var found = fullNames.Contains(new FullName("고", "길동"));

            found.Should().BeTrue();
        }
    }
}
