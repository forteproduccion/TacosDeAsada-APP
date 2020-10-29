using System;
using System.ComponentModel;
using Cotemar.iOS.Renderers;
using Cotemar.UI.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TimePickerBase), typeof(TimePickerBaseiOS))]
namespace Cotemar.iOS.Renderers
{
    public class TimePickerBaseiOS : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Control is null || e.NewElement is null) return;

            var element = e.NewElement as TimePickerBase;
            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }
            Control.AdjustsFontSizeToFitWidth = true;
            Control.TextColor = element.TextColor.ToUIColor();
            Control.ShouldEndEditing += (textField) =>
            {
                var seletedDate = (UITextField)textField;
                var text = seletedDate.Text;
                if (text == element.Placeholder)
                {
                    Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                return true;
            };
            var view = (TimePickerBase)Element;
            // Radius for the curves  
            Control.Layer.CornerRadius = view.CornerRadius;
            // Thickness of the Border Color  
            Control.Layer.BorderColor = view.BorderColor.ToCGColor();
            // Thickness of the Border Width  
            Control.Layer.BorderWidth = view.BorderWidth;
            Control.ClipsToBounds = true;
        }
        private void OnCanceled(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
        private void OnDone(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control is null || Element is null) return;

            var font = UI.FontsApp.FontExtensions.FindNameForFont(((TimePickerBase)Element).TypeFont);
            if (!string.IsNullOrEmpty(font))
            {
                Control.Font = UIFont.FromName(font, (nfloat)Element.FontSize);
            }
        }
    }
}