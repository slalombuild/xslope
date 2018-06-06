using Android.Widget;
using XSlope.Core.Converters;

namespace XSlope.Droid.Converters
{
    public class StringToImageConverter : BaseConverter<string, ImageView>
    {
        readonly ImageView _imageView;

        public StringToImageConverter(ImageView imageView)
        {
            _imageView = imageView;
        }

        protected override ImageView Convert(string fromValue)
        {
            if (!string.IsNullOrEmpty(fromValue))
            {
                var imageId = _imageView.Resources.GetIdentifier(fromValue, "drawable", _imageView.Context.PackageName);
                _imageView.SetImageResource(imageId);
            }
            return _imageView;
        }
    }
}
