﻿using FluentAssertions;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Lib.Tests
{
    public class LooseCoupledNLogSpec
    {
        private readonly MemoryTarget _memoryTarget;

        public LooseCoupledNLogSpec()
        {
            _memoryTarget = new MemoryTarget
            {
                Layout = "${level}"
            };

            // Trace 수준부터 모든 로그를 수집한다.
            SimpleConfigurator.ConfigureForTargetLogging(_memoryTarget, LogLevel.Trace);
        }

        [Fact]
        public void ShouldHave_TwoTraces()
        {
            // Arrange
            LooseCoupledNLog sut = new LooseCoupledNLog(LogManager.GetCurrentClassLogger());

            // Act
            sut.Divide(2019, 10);

            // Assert
            _memoryTarget.Logs
                .Where(log => log.StartsWith("Trace"))
                .Count()
                .Should().Be(2);
        }
    }
}
