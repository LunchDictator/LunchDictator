namespace LunchDictator.Web.Core
{
    using System;

    public static class CurrentUrlHelper
    {
        public static string GetCurrentUrl(this Uri uri)
        {
            return uri == null
                       ? "http://www.lunchdictator.co.uk"
                       : uri.AbsoluteUri.Replace(uri.AbsolutePath, string.Empty);
        }
    }
}