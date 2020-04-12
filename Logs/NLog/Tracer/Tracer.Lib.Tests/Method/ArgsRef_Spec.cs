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
    public class ArgsRef_Spec : LogSpec
    {
        //
        // ref 인자 - int
        //
        [Fact]
        public void ShouldTrace_RefInt()
        {
            // Arrange 
            ArgsRef argsRef = new ArgsRef();

            // Act
            int inp2 = 42;
            argsRef.CallMe(ref inp2);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsRef Entered into CallMe(Int32&) (param=42).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsRef Returned from CallMe(Int32&) (param=24). Time taken:");
        }

        //
        // ref 인자 - string
        //
        [Fact]
        public void ShouldTrace_RefString()
        {
            // Arrange 
            ArgsRef argsRef = new ArgsRef();

            // Act
            string inp1 = "goinIn";
            argsRef.CallMe(ref inp1);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsRef Entered into CallMe(String&) (param=goinIn).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsRef Returned from CallMe(String&) (param=goinOut). Time taken:");
        }


        //
        // ref 인자 - struct
        //
        [Fact]
        public void ShouldTrace_RefStruct()
        {
            // Arrange 
            ArgsRef argsRef = new ArgsRef();

            // Act
            MyStruct inp3 = new MyStruct() { IntVal = 42 };
            argsRef.CallMe(ref inp3);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Method.ArgsRef Entered into CallMe(MyStruct&) (param=Tracer.Lib.MyStruct).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Method.ArgsRef Returned from CallMe(MyStruct&) (param=Tracer.Lib.MyStruct). Time taken:");
        }

        //
        // ref 인자 - class
        //
        [Fact]
        public void ShouldTrace_RefClass()
        {
            // Arrange 
            ArgsRef argsRef = new ArgsRef();

            // Act
            MyClass inp4 = new MyClass() { IntVal = 42 };
            argsRef.CallMe(ref inp4);

            // Assert
            _memoryTarget.Logs.Count.Should().Be(6);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.MyClass Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.MyClass Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[2].Should().Be("TRACE Tracer.Lib.Method.ArgsRef Entered into CallMe(MyClass&) (param=Tracer.Lib.MyClass).");
            _memoryTarget.Logs[3].Should().Be("TRACE Tracer.Lib.MyClass Entered into .ctor().");
            _memoryTarget.Logs[4].Should().StartWith("TRACE Tracer.Lib.MyClass Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[5].Should().StartWith("TRACE Tracer.Lib.Method.ArgsRef Returned from CallMe(MyClass&) (param=Tracer.Lib.MyClass). Time taken:");
        }
    }
}
