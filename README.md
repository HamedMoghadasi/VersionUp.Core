[![.NET](https://github.com/HamedMoghadasi/VersionUp.Core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/HamedMoghadasi/VersionUp.Core/actions/workflows/dotnet.yml)
![Nuget](https://img.shields.io/nuget/v/VersionUp.Core?logo=Nuget&logoColor=Nuget)
# What is VersionUp.Core ?!
It is ready-to-go package for updating .Net core application automatically.

# Installation
 1. Get latest version of VersionUp.Core package from [Nuget](https://www.nuget.org/packages/VersionUp.Core/). 
 2. All it's Done :) Now If you build your application the version will update automatticlly.


# How it works:
The valid schema for working with this module is as follows:
```
[Major].[Minor].[Date].[BuildNumber]
```
If your `csproj` file doesn't have `<version>` node when you build your application after installation, The VersionUp.Core will add a `<version>1.0.0.0</version>` to the csproj file.
After that when you build project again, the `[BuildNumber]` increment by 1 and the `[Date]` will update too, `[Date]` is combination of `year` and `DayOfYear`.
for exmaple `11 March 2022` is 70th day of the year, so:
```
<version>1.0.22070.1</version>
```


#### P.S. The `VersionUp.Core` never change `Major` and `Minor` value and If you want to change their value you can do it manually.

