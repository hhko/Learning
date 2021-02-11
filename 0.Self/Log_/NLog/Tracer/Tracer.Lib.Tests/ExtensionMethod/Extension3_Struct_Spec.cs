using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Constructor;
using Tracer.Lib.Inheritance;
using Tracer.Lib.Method;
using Tracer.Lib.Property;
using Xunit;
using Tracer.Lib.ExtensionMethod;

namespace Tracer.Lib.Tests.ExtensionMethod
{
    public class Extension3_Struct_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace()
        {
            // Arrange 
            MyStruct myStruct = new MyStruct { IntVal = 2019 };

            // Act
            myStruct.Do(1);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.ExtensionMethod.Extension3_Struct Entered into Do(MyStruct, Int32) (self=Tracer.Lib.MyStruct, value=1).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.ExtensionMethod.Extension3_Struct Returned from Do(MyStruct, Int32) ($return=2). Time taken:");
        }
    }
}
