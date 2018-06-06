using Android.OS;
using Newtonsoft.Json;

namespace XSlope.Droid.Extensions
{
    public static class BundleExtensions
    {
        public static Bundle PutArg<T>(this Bundle bundle, string key, T arg)
        {
            bundle.PutString(key, JsonConvert.SerializeObject(arg));
            return bundle;
        }

        public static void GetArg<T>(this Bundle bundle, ref T reference, string key)
        {
            if (bundle.ContainsKey(key))
            {
                reference = JsonConvert.DeserializeObject<T>(bundle.GetString(key));
                return;
            }
            reference = default(T);
        }
    }
}
