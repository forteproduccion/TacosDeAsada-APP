using System;
using System.ComponentModel;
using System.Diagnostics;
using Cotemar.iOS.Renderers;
using Cotemar.UI.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ButtonBase), typeof(ButtonBaseiOS))]
namespace Cotemar.iOS.Renderers
{
    public class ButtonBaseiOS : ButtonRenderer
    {

        private readonly static string TAG = nameof(ButtonBaseiOS);

        protected override void Dispose(bool disposing)
        {
            try
            {
                base.Dispose(disposing);
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control is null || Element is null) return;

            var font = UI.FontsApp.FontExtensions.FindNameForFont(((ButtonBase)Element).TypeFont);
            if (!string.IsNullOrEmpty(font))
            {
                Control.Font = UIFont.FromName(font, (nfloat)Element.FontSize);
            }
        }

    }
}