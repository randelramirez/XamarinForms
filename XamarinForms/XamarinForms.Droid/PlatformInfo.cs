using Android.OS;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinForms.Droid.PlatformInfo))]

namespace XamarinForms.Droid
{
    public class PlatformInfo : IPlatformInfo
    {
        public string GetModel()
        {
            return String.Format("{0} {1}", Build.Manufacturer,
                                            Build.Model);
        }

        public string GetVersion()
        {
            return Build.VERSION.Release.ToString();
        }
    }
}