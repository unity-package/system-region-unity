using System.Globalization;

namespace VirtueSky.SystemRegion
{
    public static class RegionHelper
    {
        public static RegionInfo GetCurrentRegion()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
             return RegionHelperAndroid.GetCurrentRegion();
#elif UNITY_IOS && !UNITY_EDITOR
            return RegionHelperIos.GetCurrentRegion();
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            return RegionHelperWindowEditor.GetCurrentRegion();
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
            return RegionHelperMacOsEditor.GetCurrentRegion();
#else
            // Default fallback for unsupported platforms
            try
            {
                return RegionInfo.CurrentRegion;
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogWarning("Region detection failed: " + e.Message);
                return new RegionInfo("US"); // Fallback to US region
            }
#endif
        }
    }
}