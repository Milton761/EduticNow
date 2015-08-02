using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CoolBeans;
using CoolBeans.Droid;



[assembly: ExportRenderer (typeof (CustomEntry), typeof (CustomEntryRenderer))]

namespace CoolBeans.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the textField here!
                Control.SetBackgroundColor(global::Android.Graphics.Color.ParseColor("#70848484"));
            }
        }
    }
}