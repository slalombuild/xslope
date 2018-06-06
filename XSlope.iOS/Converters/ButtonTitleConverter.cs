using System;
using UIKit;
using XSlope.Core.Converters;

namespace XSlope.iOS.Converters
{
    public class ButtonTitleConverter : BaseConverter<string, UIButton>
    {
        readonly UIButton _button;
        readonly UIControlState _state;

        public ButtonTitleConverter(UIButton button, UIControlState state = UIControlState.Normal)
        {
            _button = button;
            _state = state;
        }

        protected override UIButton Convert(string fromValue)
        {
            UIView.PerformWithoutAnimation(() =>
            {
                _button.SetTitle(fromValue, _state);
                _button.LayoutIfNeeded();
            });

            return _button;
        }
    }
}
