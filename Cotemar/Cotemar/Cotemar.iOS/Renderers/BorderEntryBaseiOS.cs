using System;
using System.ComponentModel;
using CoreGraphics;
using Cotemar.iOS.Renderers;
using Cotemar.UI.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderEntryBase), typeof(BorderEntryBaseiOS))]
namespace Cotemar.iOS.Renderers
{
    public class BorderEntryBaseiOS : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control is null || e.NewElement is null) return;

            var view = (BorderEntryBase)Element;
            if (view.IsCurvedCornersEnabled)
            {
                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                // Radius for the curves  
                Control.Layer.CornerRadius = view.CornerRadius - 5;
                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                // Thickness of the Border Width  
                var a = (nfloat)(view.BorderWidth / 100);
                Control.Layer.BorderWidth = view.BorderWidth - 1;
                Control.ClipsToBounds = true;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control is null || Element is null) return;

            var font = Cotemar.UI.FontsApp.FontExtensions.FindNameForFont(((BorderEntryBase)Element).TypeFont);
            if (!string.IsNullOrEmpty(font))
            {
                Control.Font = UIFont.FromName(font, (nfloat)Element.FontSize);
            }
        }
    }
}