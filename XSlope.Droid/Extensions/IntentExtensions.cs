using System;
using Android.Content;
using Newtonsoft.Json;

namespace XSlope.Droid.Extensions
{
    public static class IntentExtensions
    {
        public static Intent SaveExtra<T>(this Intent intent, string key, T extra)
        {
            intent.PutExtra(key, JsonConvert.SerializeObject(extra));
            return intent;
        }

        public static void GetExtra<T>(this Intent intent, ref T reference, string key)
        {
            try
            {
                if (intent.Extras != null && intent.Extras.ContainsKey(key))
                {
                    reference = JsonConvert.DeserializeObject<T>(intent.GetStringExtra(key));
                    return;
                }
                reference = default(T);
            }
            catch
            {
                reference = default(T);
            }
        }

        public static Intent AddClearBackstackFlags(this Intent intent)
        {
            intent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.NewTask);
            return intent;
        }
    }
}
