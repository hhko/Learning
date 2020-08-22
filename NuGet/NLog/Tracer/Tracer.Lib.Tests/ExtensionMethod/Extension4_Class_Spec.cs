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
    public class Extension4_Class_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace()
        {
            // Arrange 
            MyClass myClass = new MyClass { IntVal = 2019 };

            // Act
            myClass.Do(1);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.MyClass Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.MyClass Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[2].Should().Be("TRACE Tracer.Lib.ExtensionMethod.Extension4_Class Entered into Do(MyClass, Int32) (self=Tracer.Lib.MyClass, value=1).");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.ExtensionMethod.Extension4_Class Returned from Do(MyClass, Int32) ($return=2). Time taken:");
        }
    }
}
