using System;
using System.Globalization;
using UnityEngine;

namespace VirtueSky.SystemRegion
{
    internal static class RegionHelperAndroid
    {
        internal static RegionInfo GetCurrentRegion()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            try
            {
                using (var buildVersion = new AndroidJavaClass("android.os.Build$VERSION"))
                {
                    int sdkInt = buildVersion.GetStatic<int>("SDK_INT");
                    Debug.Log($"[RegionHelper] Android SDK: {sdkInt}");

                    string countryCode = null;

                    if (sdkInt >= 24)
                    {
                        using (var localeListClass = new AndroidJavaClass("android.os.LocaleList"))
                        {
                            var locale = localeListClass.CallStatic<AndroidJavaObject>("getAdjustedDefault")
                                .Call<AndroidJavaObject>("get", 0);
                            countryCode = locale.Call<string>("getCountry");
                            Debug.Log($"[RegionHelper] API 24+ → {locale.Call<string>("toString")} → {countryCode}");
                        }
                    }
                    else
                    {
                        using (var localeClass = new AndroidJavaClass("java.util.Locale"))
                        {
                            var locale = localeClass.CallStatic<AndroidJavaObject>("getDefault");
                            countryCode = locale.Call<string>("getCountry");
                            Debug.Log($"[RegionHelper] API <24 → {locale.Call<string>("toString")} → {countryCode}");
                        }
                    }

                    if (!string.IsNullOrEmpty(countryCode))
                        return new RegionInfo(countryCode);
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning("[RegionHelper] Android fallback: " + ex.Message);
            }
#endif
            return new RegionInfo("US");
        }
    }
}