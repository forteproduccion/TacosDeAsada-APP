using System;
using System.ComponentModel;
using System.Drawing;
using Cotemar.iOS.Renderers;
using Cotemar.UI.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PickerWithIconBase), typeof(PickerWithIconBaseiOS))]
namespace Cotemar.iOS.Renderers
{
    public class PickerWithIconBaseiOS : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control is null || e.NewElement is null) return;

            var view = (PickerWithIconBase)Element;
            Control.Layer.CornerRadius = view.CornerRadius;
            Control.Layer.BorderColor = view.BorderColor.ToCGColor();
            Control.TextColor = view.TextColor.ToUIColor();
            Control.TintColor = view.TitleColor.ToUIColor();
            Control.AttributedPlaceholder = new Foundation.NSAttributedString(this.Control.AttributedPlaceholder.Value, foregroundColor: view.TitleColor.ToUIColor());
            Control.Layer.BorderWidth = view.BorderWidth;
            Control.ClipsToBounds = true;
            Control.RightViewMode = UITextFieldViewMode.Always;

            var imageView = new UIImageView(UIImage.FromBundle(view.Icon))
            {
                // Indent it 10 pixels from the left.
                Frame = new RectangleF(-5, 0, view.IconWidth, view.IconHeight)
            };

            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, view.IconWidth, view.IconHeight));
            objLeftView.AddSubview(imageView);
            Control.RightView = objLeftView;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null || Element == null) return;

            var font = UI.FontsApp.FontExtensions.FindNameForFont(((PickerWithIconBase)Element).TypeFont);
            if (!string.IsNullOrEmpty(font))
            {
                Control.Font = UIFont.FromName(font, (nfloat)Element.FontSize);
            }
        }
    }
}