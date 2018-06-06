using System;
using Android.Views;

namespace XSlope.Droid.Extensions
{
    public static class ViewExtensions
    {
        public static void FindView<T>(this View view, ref T control, int id) where T : View
        {
            control = view.FindViewById<T>(id);
        }

        public static EventHandler AddTapHandler(this View view, Action onTap, EventHandler existingEventHandler)
        {
            if (existingEventHandler != null)
            {
                view.Click -= existingEventHandler;
            }

            EventHandler eventHandler = (sender, e) => onTap?.Invoke();
            view.Click += eventHandler;
            return eventHandler;
        }
    }
}
