[![.NET](https://github.com/HamedMoghadasi/VersionUp.Core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/HamedMoghadasi/VersionUp.Core/actions/workflows/dotnet.yml)
# VersionUp.Core
In .net core there's no `AssembleyInfo.cs` and every information about assembly will locate in `csproj` file. by using this module you can increment application version automatically.


### Step 1.
Add `Publish\VersionUp.Core.exe` to your project or solution.

### Step 2.
Add following code to your target `.csproj`:

```xml
  <Target Name="PreBuild" BeforeTargets="PreBuildEvent">
    <Exec Command="[VersionUp.Core.exe address located here] &quot;$(ProjectPath)&quot;" />
  </Target>
```

### How it works:
The valid schema for working with this module is as following:
```
[Major].[Minor].[Date].[BuildNumber]
```
Before Target start bnuilding, The version up module looking for `<Version>` in `<PropertyGroup>` of target csproj, if module found it, increment `BuildNumber` one unit, but if module couldn't find `<Version>` it will add `<Version>1.0.0.0</Version>` to `<PropertyGroup>` automatically.
