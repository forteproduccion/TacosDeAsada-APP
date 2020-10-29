using System;
using System.ComponentModel;
using System.Diagnostics;
using Cotemar.iOS.Renderers;
using Cotemar.UI.IconsApp;
using Cotemar.UI.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconAwesomeLabelBase), typeof(IconAwesomeLabelBaseiOS))]
namespace Cotemar.iOS.Renderers
{
    public class IconAwesomeLabelBaseiOS : LabelRenderer
    {

        private static readonly string TAG = nameof(IconAwesomeLabelBaseiOS);

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

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == IconAwesomeLabelBase.IconProperty.PropertyName ||
                e.PropertyName == IconAwesomeLabelBase.TextProperty.PropertyName ||
                e.PropertyName == IconAwesomeLabelBase.TypeIconProperty.PropertyName)
            {

                if (!string.IsNullOrEmpty(((IconAwesomeLabelBase)Element).Icon))
                {
                    Control.Font = UIFont.FromName(IconExtensions.FindNameForFont
                        (((IconAwesomeLabelBase)Element).TypeIcon), (nfloat)Element.FontSize);

                    IIcon icon = IconExtensions.FindIconForKey(((IconAwesomeLabelBase)Element).Icon);

                    Control.Text = $"{icon.Character}";
                }
            }
        }

    }
}