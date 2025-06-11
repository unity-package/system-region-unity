using System;
using System.Globalization;
using UnityEngine;

namespace VirtueSky.SystemRegion
{
    internal static class RegionHelperMacOsEditor
    {
        internal static RegionInfo GetCurrentRegion()
        {
#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
            try
            {
                var region = RegionInfo.CurrentRegion;
                if (region != null && region.TwoLetterISORegionName != "IV") return region;
            }
            catch (Exception e)
            {
                Debug.LogWarning("macOS region fallback: " + e.Message);
            }
#endif
            return new RegionInfo("US");
        }
    }
}