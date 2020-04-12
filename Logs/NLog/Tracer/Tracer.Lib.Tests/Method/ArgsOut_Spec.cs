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
    public class ArgsOut_Spec : LogSpec
    {
        //
        // out 인자 - int
        // 
        [Fact]
        public void ShouldTrace_OutInt()
        {
            // Arrange 
            ArgsOut argsOut = new ArgsOut();

            // Act
            int outInt;
            argsOut.CallMe(out outInt);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsOut Entered into CallMe(out Int32&).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsOut Returned from CallMe(out Int32&) ($return=response, param=42). Time taken:");

        }

        //
        // out 인자 - string
        // 
        [Fact]
        public void ShouldTrace_OutString()
        {
            // Arrange 
            ArgsOut argsOut = new ArgsOut();

            // Act
            string outString;
            argsOut.CallMe(out outString);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsOut Entered into CallMe(out String&).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsOut Returned from CallMe(out String&) ($return=response, param=rv). Time taken:");
        }

        //
        // out 인자 - struct
        // 
        [Fact]
        public void ShouldTrace_OutStruct()
        {
            // Arrange 
            ArgsOut argsOut = new ArgsOut();

            // Act
            MyStruct outStruct;
            argsOut.CallMe(out outStruct);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsOut Entered into CallMe(out MyStruct&).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsOut Returned from CallMe(out MyStruct&) (param=Tracer.Lib.MyStruct). Time taken:");
        }

        //
        // out 인자 - class
        // 
        [Fact]
        public void ShouldTrace_OutClass()
        {
            // Arrange 
            ArgsOut argsOut = new ArgsOut();

            // Act
            MyClass outClass;
            argsOut.CallMe(out outClass);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsOut Entered into CallMe(out MyClass&).");
            _memoryTarget.Logs[1].Should().Be("TRACE Tracer.Lib.MyClass Entered into .ctor().");
            _memoryTarget.Logs[2].Should().StartWith("TRACE Tracer.Lib.MyClass Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Method.ArgsOut Returned from CallMe(out MyClass&) (param=Tracer.Lib.MyClass). Time taken:");
        }
    }
}
