## How To Install

### Add the line below to `Packages/manifest.json`

for version `1.0.0`
```json
"com.unity-package.system-region":"https://github.com/unity-package/system-region-unity.git#1.0.0",
```

## Use 
- Use Api `RegionHelper.GetCurrentRegion()` to get the current region.
- Example usage in a script:
```csharp
    Debug.Log($"region: {RegionHelper.GetCurrentRegion()}");
```