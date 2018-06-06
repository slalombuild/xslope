using System;
using System.Linq;
using UIKit;

namespace XSlope.iOS.Extensions
{
    public static class UIViewExtensions
    {
        public static void AddConstraintsToFillSuperview(this UIView view)
        {
            if (view.Superview != null)
            {
                view.TranslatesAutoresizingMaskIntoConstraints = false;

                view.TopAnchor.ConstraintEqualTo(view.Superview.TopAnchor).Active = true;
                view.BottomAnchor.ConstraintEqualTo(view.Superview.BottomAnchor).Active = true;
                view.LeadingAnchor.ConstraintEqualTo(view.Superview.LeadingAnchor).Active = true;
                view.TrailingAnchor.ConstraintEqualTo(view.Superview.TrailingAnchor).Active = true;
            }
        }

        public static void AddTapHandler(this UIView view, Action onTap)
        {
            view.UserInteractionEnabled = true;
            view.AddGestureRecognizer(new UITapGestureRecognizer(onTap));
        }

        public static void RoundCorners(this UIView view, float radius = 4)
        {
            view.Layer.CornerRadius = radius;
        }

        public static void CollapseView(this UIView view, bool collapseVertical, bool collapseHorizontal)
        {
            view.ClipsToBounds = true;

            if (collapseVertical)
            {
                var heightConstraint = view.Constraints.FirstOrDefault(c => c.FirstAttribute == NSLayoutAttribute.Height);
                Collapse(view.HeightAnchor, heightConstraint);
            }

            if (collapseHorizontal)
            {
                var widthConstraint = view.Constraints.FirstOrDefault(c => c.FirstAttribute == NSLayoutAttribute.Width);
                Collapse(view.WidthAnchor, widthConstraint);
            }

            view.AccessibilityElementsHidden = true;
        }

        public static void ExpandView(this UIView view, bool expandVertical, bool expandHorizontal)
        {
            if (expandVertical)
            {
                var heightConstraint = view.Constraints.FirstOrDefault(c => c.FirstAttribute == NSLayoutAttribute.Height);
                Expand(heightConstraint);
            }

            if (expandHorizontal)
            {
                var widthConstraint = view.Constraints.FirstOrDefault(c => c.FirstAttribute == NSLayoutAttribute.Width);
                Expand(widthConstraint);
            }

            view.AccessibilityElementsHidden = false;
        }

        static void Collapse(NSLayoutDimension anchor, NSLayoutConstraint constraint)
        {
            if (constraint == null)
            {
                anchor.ConstraintEqualTo(0).Active = true;
            }
            else
            {
                constraint.Constant = 0;
                constraint.Active = true;
            }
        }

        static void Expand(NSLayoutConstraint constraint)
        {
            if (constraint != null && constraint.Constant == 0)
            {
                constraint.Active = false;
            }
        }
    }
}
