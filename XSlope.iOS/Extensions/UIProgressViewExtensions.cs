using System.Linq;
using CoreGraphics;
using UIKit;

namespace XSlope.iOS.Extensions
{
    public static class UIProgressViewExtensions
    {
        public static void SetHeight(this UIProgressView progressView, float height)
        {
            progressView.Transform = CGAffineTransform.MakeScale(1.0f, height);

            progressView.Subviews.ToList().ForEach(subview =>
            {
                subview.Layer.CornerRadius = height / 2.0f;
                subview.Layer.MasksToBounds = true;
            });
        }
    }
}
