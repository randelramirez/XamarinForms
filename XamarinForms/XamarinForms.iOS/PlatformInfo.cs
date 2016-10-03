using System;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinForms.iOS.PlatformInfo))]

namespace XamarinForms.iOS
{
    public class PlatformInfo : IPlatformInfo
    {

        UIDevice device = new UIDevice();

        public string GetModel()
        {
            return device.Model.ToString();
        }

        public string GetVersion()
        {
            return String.Format("{0} {1}", device.SystemName,
                                            device.SystemVersion);
        }
    }
}