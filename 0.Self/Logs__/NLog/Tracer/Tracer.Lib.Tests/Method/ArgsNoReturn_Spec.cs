using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Constructor;
using Tracer.Lib.Inheritance;
using Tracer.Lib.Method;
using Xunit;

namespace Tracer.Lib.Tests.Method
{
    public class ArgsNoReturn_Spec : LogSpec
    {
        //
        // 출력 - string
        // 
        [Fact]
        public void ShouldTrace_ReturnString()
        {
            // Arrange 
            ArgsNoReturn argsNoReturn = new ArgsNoReturn();

            // Act
            string value1 = argsNoReturn.CallMe();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallMe().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallMe() ($return=response). Time taken:");
        }

        //
        // 출력 - struct
        // 
        [Fact]
        public void ShouldTrace_ReturnStruct()
        {
            // Arrange 
            ArgsNoReturn argsNoReturn = new ArgsNoReturn();

            // Act
            MyStruct value2 = argsNoReturn.CallMeStruct();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallMeStruct().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallMeStruct() ($return=Tracer.Lib.MyStruct). Time taken:");
        }

        //
        // 출력 - class
        // 
        [Fact]
        public void ShouldTrace_ReturnClass()
        {
            // Arrange 
            ArgsNoReturn argsNoReturn = new ArgsNoReturn();

            // Act
            MyClass value3 = argsNoReturn.CallMeClass();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallMeClass().");
            _memoryTarget.Logs[1].Should().Be("TRACE Tracer.Lib.MyClass Entered into .ctor().");
            _memoryTarget.Logs[2].Should().StartWith("TRACE Tracer.Lib.MyClass Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallMeClass() ($return=Tracer.Lib.MyClass). Time taken:");
        }

        //
        // 출력 - T
        // 
        [Fact]
        public void ShouldTrace_ReturnGeneric()
        {
            // Arrange 
            ArgsNoReturn argsNoReturn = new ArgsNoReturn();

            // Act
            Foo value4 = argsNoReturn.CallaMeGeneric<Foo>();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallaMeGeneric().");
            _memoryTarget.Logs[1].Should().Be("TRACE Tracer.Lib.Foo Entered into .ctor().");
            _memoryTarget.Logs[2].Should().StartWith("TRACE Tracer.Lib.Foo Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallaMeGeneric() ($return=Tracer.Lib.Foo). Time taken:");
        }

        //
        // 출력 추적 제외
        //
        [Fact]
        public void ShouldNotTrace_Return()
        {
            // Arrange 
            ArgsNoReturn argsNoReturn = new ArgsNoReturn();

            // Act
            MyClass value5 = argsNoReturn.CallMeClassNoTrace();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallMeClassNoTrace().");
            _memoryTarget.Logs[1].Should().Be("TRACE Tracer.Lib.MyClass Entered into .ctor().");
            _memoryTarget.Logs[2].Should().StartWith("TRACE Tracer.Lib.MyClass Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallMeClassNoTrace() (). Time taken:");
        }
    }
}
