<p align="left">
  <a>
    <img alt="Made With Unity" src="https://img.shields.io/badge/made%20with-Unity-57b9d3.svg?logo=Unity">
  </a>
  <a>
    <img alt="License" src="https://img.shields.io/github/license/unity-package/system-region-unity?logo=github">
  </a>
  <a>
    <img alt="Last Commit" src="https://img.shields.io/github/last-commit/unity-package/system-region-unity?logo=Mapbox&color=orange">
  </a>
  <a>
    <img alt="Repo Size" src="https://img.shields.io/github/repo-size/unity-package/system-region-unity?logo=VirtualBox">
  </a>
  <a>
    <img alt="Last Release" src="https://img.shields.io/github/v/release/unity-package/system-region-unity?include_prereleases&logo=Dropbox&color=yellow">
  </a>
</p>

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
    private void Start()
    {
        Debug.Log($"region: {RegionHelper.GetCurrentRegion()}");
    }
```
