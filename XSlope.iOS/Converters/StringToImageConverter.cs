using System;
using UIKit;
using XSlope.Core.Converters;

namespace XSlope.iOS.Converters
{
    public class StringToImageConverter : BaseConverter<string, UIImage>
    {
        protected override UIImage Convert(string fromValue)
        {
            return string.IsNullOrEmpty(fromValue) ?
                         new UIImage() :
                         UIImage.FromBundle(fromValue) ?? new UIImage();
        }
    }
}
