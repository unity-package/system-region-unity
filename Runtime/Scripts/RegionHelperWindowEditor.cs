using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace VirtueSky.SystemRegion
{
    internal static class RegionHelperWindowEditor
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        [DllImport("kernel32.dll")]
        private static extern int GetUserGeoID(int geoClass);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetGeoInfo(
            int location, int geoType, [Out] char[] lpGeoData, int geoDataLen, int langId);

        private const int GEOCLASS_NATION = 16;
        private const int GEO_ISO2 = 0x0004;
#endif
        internal static RegionInfo GetCurrentRegion()
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            try
            {
                int geoId = GetUserGeoID(GEOCLASS_NATION);
                char[] isoCode = new char[3];
                int result = GetGeoInfo(geoId, GEO_ISO2, isoCode, isoCode.Length, 0);

                if (result != 0)
                {
                    string iso = new string(isoCode).TrimEnd('\0');
                    return new RegionInfo(iso);
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogWarning("Windows region detection failed: " + e.Message);
            }
#endif
            return new RegionInfo("US");
        }
    }
}