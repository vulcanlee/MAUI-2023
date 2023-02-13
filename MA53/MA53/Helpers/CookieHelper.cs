using Android.Webkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA53.Helpers
{
    public class CookieHelper
    {
        public void CleanCookie()
        {

#if ANDROID
            CookieSyncManager.CreateInstance(Android.App.Application.Context);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                Android.Webkit.CookieManager.Instance.RemoveAllCookies(null);
            else
                Android.Webkit.CookieManager.Instance.RemoveAllCookie();

            var foo = CookieManager.Instance;
            CookieManager.Instance.RemoveExpiredCookie();
            CookieManager.Instance.RemoveSessionCookie();
            CookieManager.Instance.Flush();
            CookieSyncManager.Instance.Sync();
            //CookieSyncManager cookieSyncManager = CookieSyncManager.CreateInstance(Android.App.Application.Context);
            //cookieSyncManager.StartSync();
            //CookieManager cookieManager = CookieManager.Instance;
            //cookieManager.RemoveAllCookies(null);
            //cookieManager.Flush();
            //cookieSyncManager.StopSync();
            //cookieSyncManager.Sync();
            //MainThread.InvokeOnMainThreadAsync(() =>
            //{
            //}).Wait();
#elif IOS
            Foundation.NSHttpCookieStorage CookieStorage = Foundation.NSHttpCookieStorage.SharedStorage;
            foreach (var cookie in CookieStorage.Cookies)
                CookieStorage.DeleteCookie(cookie);
        }
#else
#endif
            SecureStorage.RemoveAll();
        }
    }
}
