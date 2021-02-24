using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Async;
using Tracer.Lib.Constructor;
using Tracer.Lib.Excpetion;
using Tracer.Lib.Inheritance;
using Tracer.Lib.Method;
using Tracer.Lib.Property;
using Xunit;

namespace Tracer.Lib.Tests.Async
{
    public class AsyncMethod_Spec : LogSpec
    {
        [Fact]
        public void ShouldTrace_Async()
        {
            // Arrange 
            AsyncMethod asyncMethod = new AsyncMethod();

            // Act
            int x1 = asyncMethod.CallMeAsync(2019, "Hello2", 10).Result;

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Async.AsyncMethod Entered into CallMeAsync(Int32, String, Int32) (param=2019, param2=Hello2, paraInt=10).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Async.AsyncMethod Returned from CallMeAsync(Int32, String, Int32) ($return=20). Time taken:");
        }

        [Fact]
        public void ShouldTrace_AsyncReturnNo()
        {
            // Arrange 
            AsyncMethod asyncMethod = new AsyncMethod();

            // Act
            asyncMethod.CallMeReturnNodAsync("Hello1", "Hello2", 10).Wait();

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Async.AsyncMethod Entered into CallMeReturnNodAsync(String, String, Int32) (param=Hello1, param2=Hello2, paraInt=10).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Async.AsyncMethod Returned from CallMeReturnNodAsync(String, String, Int32) (). Time taken:");
        }

        [Fact]
        public void ShouldTrace_AsyncNested()
        {
            // Arrange 
            AsyncMethod asyncMethod = new AsyncMethod();

            // Act
            int x2 = asyncMethod.CallMeOtherClass("Hello1", "Hello2", 10).Result;

            // Assert
            _memoryTarget.Logs.Count.Should().Be(4);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Async.AsyncMethod Entered into CallMeOtherClass(String, String, Int32) (param=Hello1, param2=Hello2, paraInt=10).");
            _memoryTarget.Logs[1].Should().Be("TRACE Tracer.Lib.Async.OtherClass Entered into Double(Int32) (p=10).");
            _memoryTarget.Logs[2].Should().StartWith("TRACE Tracer.Lib.Async.OtherClass Returned from Double(Int32) ($return=20). Time taken:");
            _memoryTarget.Logs[3].Should().StartWith("TRACE Tracer.Lib.Async.AsyncMethod Returned from CallMeOtherClass(String, String, Int32) ($return=40). Time taken:");
        }

        [Fact]
        public void ShouldTrace_AsyncGeneric()
        {
            // Arrange 
            AsyncMethod asyncMethod = new AsyncMethod();

            // Act
            int x3 = asyncMethod.CallMeGeneric(2019, "Hello", 10).Result;

            // Assert
            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Async.AsyncMethod Entered into CallMeGeneric(T, String, Int32) (param=2019, param2=Hello, paraInt=10).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Async.AsyncMethod Returned from CallMeGeneric(T, String, Int32) ($return=20). Time taken:");
        }

        [Fact]
        public void ShouldTrace_ThrowException()
        {
            // Arrange 
            AsyncMethod asyncMethod = new AsyncMethod();
            Action act = () =>
            {
                int x4 = asyncMethod.Throw(2019).Result;
            };

            // Act, Assert
            act.Should().Throw<ApplicationException>();

            _memoryTarget.Logs.Count.Should().Be(2);
            _memoryTarget.Logs[0].Should().Be("TRACE Tracer.Lib.Async.AsyncMethod Entered into Throw(Int32) (p=2019).");
            _memoryTarget.Logs[1].Should().StartWith("TRACE Tracer.Lib.Async.AsyncMethod Returned from Throw(Int32) ($exception=System.ApplicationException:");
        }
    }
}
