using UIKit;
using System.Linq;

namespace XSlope.iOS.Extensions
{
    public static class UIStackViewExtensions
    {
        public static void ClearArrangedSubViews(this UIStackView stackView)
        {
            for (int i = stackView.ArrangedSubviews.Count() - 1; i >= 0; i--)
            {
                var subView = stackView.ArrangedSubviews[i];
                stackView.RemoveArrangedSubview(subView);
                subView.RemoveFromSuperview();
            }
        }
    }
}
