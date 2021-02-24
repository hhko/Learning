https://github.com/tsimbalar/serilog-settings-comparison

## 설정 비교
- Serilog.Settings.Configuration(Microsoft.Logging.Configuration)
  - JSON 형식
  - 파일 : appsettings.json
- Serilog.Settings.AppSettings
  - XML 형식 : <appSettings>
  - 파일 : App.config or Web.config file

## 기초
### 빈 설정
- Serilog.Settings.Configuration
var config = new ConfigurationBuilder()
    .AddJsonFile(fileName, optional: false) // or possibly other sources
    .Build();

new LoggerConfiguration().ReadFrom.Configuration(config)
    // snip ...
    .CreateLogger();

{
  "Serilog": {}
}

- Serilog.Settings.AppSettings
new LoggerConfiguration().ReadFrom.AppSettings()
    // snip ...
    .CreateLogger();

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
  </appSettings>
</configuration>

### MinimumLevel
- Serilog.Settings.Configuration
LoggerConfiguration
    .MinimumLevel.Warning()

{
  "Serilog": {
    "MinimumLevel": "Warning"
  }
}
- Serilog.Settings.AppSettings
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:minimum-level" value="Warning" />
  </appSettings>
</configuration>

### MinimumLevel - Overrides
using Serilog.Events;

LoggerConfiguration
  .MinimumLevel.Verbose()
  .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
  .MinimumLevel.Override("Microsoft.Extensions", LogEventLevel.Information)
  .MinimumLevel.Override("System", LogEventLevel.Debug)

{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Verbose",
      "Override": {
        "Microsoft": "Error",
        "Microsoft.Extensions": "Information",
        "System": "Debug"
      }
    }
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:minimum-level" value="Verbose" />
    <add key="serilog:minimum-level:override:Microsoft" value="Error" />
    <add key="serilog:minimum-level:override:Microsoft.Extensions" value="Information" />
    <add key="serilog:minimum-level:override:System" value="Debug" />
  </appSettings>
</configuration>

### Sinks
#r ".\TestDummies.dll"
using System;
using TestDummies;

LoggerConfiguration
    .WriteTo.Dummy();

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo": [ "Dummy" ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:write-to:Dummy" />
  </appSettings>
</configuration>


### restrictedToMinimumLevel

#r ".\TestDummies.dll"
using Serilog.Events;
using TestDummies;

LoggerConfiguration
    .WriteTo.Dummy(restrictedToMinimumLevel: LogEventLevel.Error);

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo": [
      {
        "Name": "Dummy",
        "Args": {
          "restrictedToMinimumLevel": "Error"
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:write-to:Dummy.restrictedToMinimumLevel" value="Error" />
  </appSettings>
</configuration>

### Sinks - Simple parameter types
#r ".\TestDummies.dll"
using TestDummies;

LoggerConfiguration
    .WriteTo.Dummy(stringParam: "A string param", intParam: 666, nullableIntParam: null);

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo": [
      {
        "Name": "Dummy",
        "Args": {
          "stringParam": "A string param",
          "intParam": 666,
          "nullableIntParam": ""
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:write-to:Dummy.stringParam" value="A string param" />
    <add key="serilog:write-to:Dummy.intParam" value="666" />
    <add key="serilog:write-to:Dummy.nullableIntParam" value="" />
  </appSettings>
</configuration>

### Sinks - Audit

#r ".\TestDummies.dll"
using TestDummies;

LoggerConfiguration
    .AuditTo.Dummy(stringParam: "A string param", intParam: 666, nullableIntParam: null);

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "AuditTo": [
      {
        "Name": "Dummy",
        "Args": {
          "stringParam": "A string param",
          "intParam": 666,
          "nullableIntParam": ""
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:audit-to:Dummy.stringParam" value="A string param" />
    <add key="serilog:audit-to:Dummy.intParam" value="666" />
    <add key="serilog:audit-to:Dummy.nullableIntParam" value="" />
  </appSettings>
</configuration>

### Enrichment - Property

LoggerConfiguration
    .Enrich.WithProperty("AppName", "MyApp")
    .Enrich.WithProperty("ServerName", "MyServer");

{
  "Serilog": {
    "Properties": {
      "AppName": "MyApp",
      "ServerName": "MyServer"
    }
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:enrich:with-property:AppName" value="MyApp" />
    <add key="serilog:enrich:with-property:ServerName" value="MyServer" />
  </appSettings>
</configuration>

### Enrichment - LogContext
LoggerConfiguration
    .Enrich.FromLogContext();

{
  "Serilog": {
    "Enrich": [ "FromLogContext" ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:enrich:FromLogContext" value="" />
  </appSettings>
</configuration>

### Sinks - LoggingLevelSwitch
#r ".\TestDummies.dll"
using Serilog.Core;
using Serilog.Events;
using TestDummies;

var mySwitch = new LoggingLevelSwitch(LogEventLevel.Warning);

LoggerConfiguration
    .MinimumLevel.ControlledBy(mySwitch)
    .WriteTo.DummyWithLevelSwitch(controlLevelSwitch: mySwitch);

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "LevelSwitches": { "$mySwitch": "Warning" },
    "MinimumLevel": {
      "ControlledBy": "$mySwitch"
    },
    "WriteTo": [
      {
        "Name": "DummyWithLevelSwitch",
        "Args": {
          "controlLevelSwitch": "$mySwitch"
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:level-switch:$mySwitch" value="Warning" />
    <add key="serilog:minimum-level:controlled-by" value="$mySwitch" />
    <add key="serilog:write-to:DummyWithLevelSwitch.controlLevelSwitch" value="$mySwitch" />
  </appSettings>
</configuration>


### Destructure
#r ".\TestDummies.dll"
using TestDummies;
using TestDummies.Policies;

LoggerConfiguration
    .Destructure.ToMaximumDepth(maximumDestructuringDepth: 3)
    .Destructure.ToMaximumStringLength(maximumStringLength: 3)
    .Destructure.ToMaximumCollectionCount(maximumCollectionCount: 3)
    .Destructure.AsScalar(typeof(System.Version))
    .Destructure.With(new CustomPolicy());

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "Destructure": [
      {
        "Name": "ToMaximumDepth",
        "Args": { "maximumDestructuringDepth": 3 }
      },
      {
        "Name": "ToMaximumStringLength",
        "Args": { "maximumStringLength": 3 }
      },
      {
        "Name": "ToMaximumCollectionCount",
        "Args": { "maximumCollectionCount": 3 }
      },
      {
        "Name": "AsScalar",
        "Args": { "scalarType": "System.Version" }
      },
      {
        "Name": "With",
        "Args": { "policy": "TestDummies.Policies.CustomPolicy, TestDummies" }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:destructure:ToMaximumDepth.maximumDestructuringDepth" value="3" />
    <add key="serilog:destructure:ToMaximumStringLength.maximumStringLength" value="3" />
    <add key="serilog:destructure:ToMaximumCollectionCount.maximumCollectionCount" value="3" />
    <add key="serilog:destructure:AsScalar.scalarType" value="System.Version" />
    <add key="serilog:destructure:With.policy" value="TestDummies.Policies.CustomPolicy, TestDummies" />
  </appSettings>
</configuration>

### Filtering - Expressions
#r ".\Serilog.Filters.Expressions.dll"

LoggerConfiguration
    .Filter.ByExcluding("filter = 'exclude'");

{
  "Serilog": {
    "Using": [ "Serilog.Filters.Expressions" ],
    "Filter": [
      {
        "Name": "ByExcluding",
        "Args": {
          "expression": "filter = 'exclude'"
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:Serilog.Filters.Expressions" value="Serilog.Filters.Expressions" />
    <add key="serilog:filter:ByExcluding.expression" value="filter = 'exclude'" />
  </appSettings>
</configuration>

### Sinks - Sub-loggers
#r ".\TestDummies.dll"
using TestDummies;

LoggerConfiguration
    .WriteTo.Logger(lc => lc
        .Enrich.WithProperty("Prop1", "PropValue1")
        .WriteTo.DummyConsole()
        )
    .WriteTo.Logger(lc => lc
        .Enrich.WithProperty("Prop2", "PropValue2")
        .WriteTo.Dummy()
    );

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo:SubLogger1": {
      "Name": "Logger",
      "Args": {
        "configureLogger": {
          "Properties": {
            "Prop1": "PropValue1"
          },
          "WriteTo": [ "DummyConsole" ]
        }
      }
    },
    "WriteTo:SubLogger2": {
      "Name": "Logger",
      "Args": {
        "configureLogger": {
          "Properties": {
            "Prop2": "PropValue2"
          },
          "WriteTo": [ "Dummy" ]
        }
      }
    }
  }
}

| Type	|  C# API	|  xml prefix	|  json section | 
| ---- |  ---- |  ---- |  ---- | 
| LoggerSinkConfiguration	|  config.WriteTo.*	| serilog:write-to:	| WriteTo | 
LoggerAuditSinkConfiguration | 	config.AuditTo.* | 	serilog:audit-to: | 	AuditTo | 
LoggerEnrichmentConfiguration | 	config.Enrich.*	|  serilog:enrich:	|  Enrich | 
LoggerFilterConfiguration	|  config.Filter.* | 	serilog:filter:	 |  Filter | 

## Setting values conversions
### Simple values
#r ".\TestDummies.dll"
using System;
using TestDummies;

LoggerConfiguration
    .WriteTo.DummyWithManyParams(
        enumParam: MyEnum.Qux,
        timespanParam: new TimeSpan(2, 3, 4, 5),
        uriParam: new Uri("https://www.serilog.net"));

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo": [
      {
        "Name": "DummyWithManyParams",
        "Args": {
          "enumParam": "Qux",
          "timespanParam": "2.03:04:05",
          "uriParam": "https://www.serilog.net"
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:write-to:DummyWithManyParams.enumParam" value="Qux" />
    <add key="serilog:write-to:DummyWithManyParams.timespanParam" value="2.03:04:05" />
    <add key="serilog:write-to:DummyWithManyParams.uriParam" value="https://www.serilog.net" />
  </appSettings>
</configuration>

### Complex values
#r ".\TestDummies.dll"
using TestDummies;

LoggerConfiguration
    .WriteTo.DummyWithComplexParams(
        poco: new Poco()
        {
            StringProperty = "myString",
            IntProperty = 42,
            Nested = new SubPoco()
            {
                SubProperty = "Sub"
            }
        },
        intArray: new[] { 2, 4, 6 },
        stringArray: new[] { "one", "two", "three" },
        objArray: new SubPoco[]
            {
                new SubPoco()
                {
                    SubProperty = "Sub1"
                },
                new SubPoco()
                {
                    SubProperty = "Sub2"
                }
            }
    );

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo": [
      {
        "Name": "DummyWithComplexParams",
        "Args": {
          "poco": {
            "stringProperty": "myString",
            "intProperty": 42,
            "nested": {
              "subProperty": "Sub"
            }
          },
          "intArray": [ 2, 4, 6 ],
          "stringArray": [ "one", "two", "three" ],
          "objArray": [
            { "subProperty": "Sub1" },
            { "subProperty": "Sub2" }
          ]
        }
      }
    ]
  }
}

## Interfaces and abstract classes
### Full type name of implementation with default constructor

#r ".\TestDummies.dll"
using System;
using Serilog.Formatting.Json;
using TestDummies;
using TestDummies.Console;

LoggerConfiguration
    .WriteTo.DummyWithFormatter(formatter: new JsonFormatter())
    .WriteTo.DummyConsole(theme: new CustomConsoleTheme());

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo": [
      {
        "Name": "DummyWithFormatter",
        "Args": {
          "formatter": "Serilog.Formatting.Json.JsonFormatter"
        }
      },
      {
        "Name": "DummyConsole",
        "Args": {
          "theme": "TestDummies.Console.CustomConsoleTheme, TestDummies"
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:write-to:DummyWithFormatter.formatter" value="Serilog.Formatting.Json.JsonFormatter" />
    <add key="serilog:write-to:DummyConsole.theme" value="TestDummies.Console.CustomConsoleTheme, TestDummies" />
  </appSettings>
</configuration>

### Public static properties

#r ".\TestDummies.dll"
#r ".\Serilog.Settings.Comparison.Tests.dll"
using System;
using Serilog.Formatting.Json;
using TestDummies;
using TestDummies.Console;
using TestDummies.Console.Themes;
using Serilog.SettingsComparisonTests.Support.Formatting;

LoggerConfiguration
    .WriteTo.DummyWithFormatter(formatter: CustomFormatters.Formatter)
    .WriteTo.DummyConsole(theme: ConsoleThemes.Theme1);

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo": [
      {
        "Name": "DummyWithFormatter",
        "Args": {
          "formatter": "Serilog.SettingsComparisonTests.Support.Formatting.CustomFormatters::Formatter, Serilog.Settings.Comparison.Tests"
        }
      },
      {
        "Name": "DummyConsole",
        "Args": {
          "theme": "TestDummies.Console.Themes.ConsoleThemes::Theme1, TestDummies"
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:write-to:DummyWithFormatter.formatter" value="Serilog.SettingsComparisonTests.Support.Formatting.CustomFormatters::Formatter, Serilog.Settings.Comparison.Tests" />
    <add key="serilog:write-to:DummyConsole.theme" value="TestDummies.Console.Themes.ConsoleThemes::Theme1, TestDummies" />
  </appSettings>
</configuration>

### Environment variable expansion
#r ".\TestDummies.dll"
using System;
using TestDummies;


LoggerConfiguration
    .WriteTo.Dummy(
        stringParam: Environment.ExpandEnvironmentVariables("%PATH%"),
        intParam: Int32.Parse(Environment.ExpandEnvironmentVariables("%NUMBER_OF_PROCESSORS%")));

{
  "Serilog": {
    "Using": [ "TestDummies" ],
    "WriteTo": [
      {
        "Name": "Dummy",
        "Args": {
          "stringParam": "%PATH%",
          "intParam": "%NUMBER_OF_PROCESSORS%"
        }
      }
    ]
  }
}

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="serilog:using:TestDummies" value="TestDummies" />
    <add key="serilog:write-to:Dummy.stringParam" value="%PATH%" />
    <add key="serilog:write-to:Dummy.intParam" value="%NUMBER_OF_PROCESSORS%" />
  </appSettings>
</configuration>