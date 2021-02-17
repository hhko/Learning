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
    public class Extension5_Generic_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_Struct()
        {
            // Arrange 

            // Act
            2019.10.DoStruct(1);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.ExtensionMethod.Extension5_Generic Entered into DoStruct(T, Int32) (self=2019.1, value=1).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.ExtensionMethod.Extension5_Generic Returned from DoStruct(T, Int32) ($return=2). Time taken:");
        }

        [Fact]
        public void ShouldTrace_Class()
        {
            // Arrange 
            MyClass myClass = new MyClass { IntVal = 2019 };

            // Act
            myClass.DoClass(1);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.MyClass Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.MyClass Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[2].Should().Be("TRACE Tracer.Lib.ExtensionMethod.Extension5_Generic Entered into DoClass(T, Int32) (self=Tracer.Lib.MyClass, value=1).");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.ExtensionMethod.Extension5_Generic Returned from DoClass(T, Int32) ($return=2). Time taken:");
        }
    }
}
