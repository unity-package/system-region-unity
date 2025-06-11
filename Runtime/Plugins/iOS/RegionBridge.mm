#import "RegionBridge.h"
#include <string.h>

const char* GetiOSRegionCode(void) {
    NSLocale *locale = [NSLocale currentLocale];
    NSString *regionCode = [locale objectForKey:NSLocaleCountryCode];

    return strdup([regionCode UTF8String]);
}
