[![.NET](https://github.com/HamedMoghadasi/VersionUp.Core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/HamedMoghadasi/VersionUp.Core/actions/workflows/dotnet.yml)
![Nuget](https://img.shields.io/nuget/v/VersionUp.Core?logo=Nuget&logoColor=Nuget)
# VersionUp.Core
In .net core, there is no `AssembleyInfo.cs` and every information about assembly will locate in the `csproj` file. by using this module you can increment the application version automatically.


### Step 1.
Add `Publish\VersionUp.Core.exe` to your project or solution.

### Step 2.
Add following code to your target `.csproj`:

```xml
  <Target Name="PreBuild" BeforeTargets="PreBuildEvent">
    <Exec Command="[VersionUp.Core.exe address located here] &quot;$(ProjectPath)&quot;" />
  </Target>
```
# Example: 
Imagine the Project structure is like below:

```
Soltion.sln
 | Web.csproj
 | Tools
   \- VersionUp.Core.exe
```   
For working with versionUp, you should add following snippet to `web.csproj`:
```xml
  <Target Name="PreBuild" BeforeTargets="PreBuildEvent">
    <Exec Command="$(SolutionDir)Tools\VersionUp.Core.exe &quot;$(ProjectPath)&quot;" />
  </Target>
```

### How it works:
The valid schema for working with this module is as follows:
```
[Major].[Minor].[Date].[BuildNumber]
```
Before Target starts building, The version up module looking for `<Version>` in `<PropertyGroup>` of target csproj, if module found it, increment `BuildNumber` one unit, but if the module couldn't find `<Version>` it will add `<Version>1.0.0.0</Version>` to `<PropertyGroup>` automatically.
