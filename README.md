[![.NET](https://github.com/HamedMoghadasi/VersionUp.Core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/HamedMoghadasi/VersionUp.Core/actions/workflows/dotnet.yml)
# VersionUp.Core
.Net 5.0 version auto incrementor


### Step 1.
Add `Publish\VersionUp.Core.exe` to your project or solution.

### Step 2.
Add following code to your target `.csproj`:

```xml
  <Target Name="PreBuild" BeforeTargets="PreBuildEvent">
    <Exec Command="[VersionUp.Core.exe address located here] &quot;$(ProjectPath)&quot;" />
  </Target>
```
