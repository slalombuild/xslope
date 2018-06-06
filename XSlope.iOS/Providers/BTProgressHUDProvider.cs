using System;
using BigTed;
using XSlope.iOS.Providers.Interfaces;

namespace XSlope.iOS.Providers
{
    public class BTProgressHUDProvider : IProgressHUDProvider
    {
        public void Show()
        {
            BTProgressHUD.Show(maskType: ProgressHUD.MaskType.Black);
        }

        public void Dismiss()
        {
            BTProgressHUD.Dismiss();
        }
    }
}
