using System;
using System.ComponentModel;
using Cotemar.iOS.Renderers;
using Cotemar.UI.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderEditorBase), typeof(BorderEditorBaseiOS))]
namespace Cotemar.iOS.Renderers
{
    public class BorderEditorBaseiOS : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control is null || e.NewElement is null) return;

            var view = (BorderEditorBase)Element;
            if (view.IsCurvedCornersEnabled)
            {
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                // Radius for the curves  
                Control.Layer.CornerRadius = view.CornerRadius;
                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                // Thickness of the Border Width  
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control is null || Element is null) return;

            var font = UI.FontsApp.FontExtensions.FindNameForFont(((BorderEditorBase)Element).TypeFont);
            if (!string.IsNullOrEmpty(font))
            {
                Control.Font = UIFont.FromName(font, (nfloat)Element.FontSize);
            }
        }
    }
}