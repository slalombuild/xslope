using System;
using UIKit;
using XSlope.Core.Converters;
using XSlope.iOS.Extensions;

namespace XSlope.iOS.Converters
{
    public class CollapseViewConverter : BaseConverter<bool, UIView>
    {
        readonly UIView _view;
        readonly bool _reverseFromValue;
        readonly bool _adjustVertical;
        readonly bool _adjustHorizontal;

        public CollapseViewConverter(UIView view, bool reverseFromValue = false, bool adjustVertical = true, bool adjustHorizontal = true)
        {
            _view = view;
            _reverseFromValue = reverseFromValue;
            _adjustVertical = adjustVertical;
            _adjustHorizontal = adjustHorizontal;
        }

        protected override UIView Convert(bool fromValue)
        {
            var shouldCollapse = _reverseFromValue ? !fromValue : fromValue;
            if (shouldCollapse)
            {
                _view.CollapseView(_adjustVertical, _adjustHorizontal);
            }
            else
            {
                _view.ExpandView(_adjustVertical, _adjustHorizontal);
            }

            return _view;
        }
    }
}
