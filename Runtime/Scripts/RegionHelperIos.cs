using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace VirtueSky.SystemRegion
{
    internal static class RegionHelperIos
    {
#if UNITY_IOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string GetiOSRegionCode();
#endif


        internal static RegionInfo GetCurrentRegion()
        {
#if UNITY_IOS && !UNITY_EDITOR
            try
            {
                string isoRegion = GetiOSRegionCode();
                if (!string.IsNullOrEmpty(isoRegion)) return new RegionInfo(isoRegion);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogWarning("iOS region detection failed: " + ex.Message);
            }
#endif
            return new RegionInfo("US");
        }
    }
}