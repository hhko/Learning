using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Constructor;
using Tracer.Lib.Excpetion;
using Tracer.Lib.Inheritance;
using Tracer.Lib.Method;
using Tracer.Lib.Property;
using Xunit;

namespace Tracer.Lib.Tests.Exception
{
    public class ExceptionMethod_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_ThrowException()
        {
            // Arrange 
            ExceptionMethod exceptionMethod = new ExceptionMethod();
            Action act = () => exceptionMethod.NonStatic();

            // Act, Assert
            act.Should().Throw<ApplicationException>();

            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[2].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into NonStatic().");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from NonStatic() ($exception=System.ApplicationException: failed");
        }

        [Fact]
        public void ShouldTrace_ThrowException_Nested()
        {
            // Arrange 
            ExceptionMethod exceptionMethod = new ExceptionMethod();
            Action act = () => exceptionMethod.FirstLevel();

            // Act, Assert
            act.Should().Throw<ApplicationException>();

            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[2].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into FirstLevel().");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from FirstLevel() ($exception=System.ApplicationException: failed");
        }

        [Fact]
        public void ShouldTrace_ThrowException_DifferentPaths()
        {
            // Arrange 
            ExceptionMethod exceptionMethod = new ExceptionMethod();
            Action act = () => exceptionMethod.DifferentExecutionPaths();

            // Act, Assert
            act.Should().Throw<DivideByZeroException>();

            _memoryTarget.Logs.Count.Should().Be(10);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[2].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into DifferentExecutionPaths().");
            _memoryTarget.Logs[3].Should().Be("TRACE Tracer.Lib.Excpetion.MyExceptionClass Entered into .ctor().");
            _memoryTarget.Logs[4].Should().StartWith("TRACE Tracer.Lib.Excpetion.MyExceptionClass Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[5].Should().Be("TRACE Tracer.Lib.Excpetion.MyExceptionClass Entered into Run(Int32) (inp=1).");
            _memoryTarget.Logs[6].Should().StartWith("TRACE Tracer.Lib.Excpetion.MyExceptionClass Returned from Run(Int32) (). Time taken:");
            _memoryTarget.Logs[7].Should().Be("TRACE Tracer.Lib.Excpetion.MyExceptionClass Entered into Run(Int32) (inp=0).");
            _memoryTarget.Logs[8].Should().StartWith("TRACE Tracer.Lib.Excpetion.MyExceptionClass Returned from Run(Int32) ($exception=System.DivideByZeroException:");
            _memoryTarget.Logs[9].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from DifferentExecutionPaths() ($exception=System.DivideByZeroException:");
        }

        [Fact]
        public void ShouldTrace_NoThrowException()
        {
            // Arrange 
            ExceptionMethod exceptionMethod = new ExceptionMethod();
            Action act = () => exceptionMethod.NoRethrow();

            // Act, Assert
            act.Should().NotThrow();

            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into .ctor().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from .ctor() (). Time taken:");
            _memoryTarget.Logs[2].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into NoRethrow().");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from NoRethrow() (). Time taken:");
        }

        [Fact]
        public void ShouldTrace_ThrowException_StaticMethod()
        {
            // Arrange 
            Action act = () => ExceptionMethod.Static();

            // Act, Assert
            act.Should().Throw<ApplicationException>();

            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into Static().");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from Static() ($exception=System.ApplicationException:");
        }
    }
}
