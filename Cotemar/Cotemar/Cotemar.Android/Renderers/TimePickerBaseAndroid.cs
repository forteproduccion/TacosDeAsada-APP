using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using Cotemar.Droid.Renderers;
using Cotemar.UI.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TimePickerBase), typeof(TimePickerBaseAndroid))]
namespace Cotemar.Droid.Renderers
{
    public class TimePickerBaseAndroid : TimePickerRenderer
    {
        public TimePickerBaseAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);
            Control.Gravity = GravityFlags.Center;
            this.Control.SetPadding(20, 0, 0, 0);
            GradientDrawable gd = new GradientDrawable();
            TimePickerBase element = Element as TimePickerBase;
            this.Control.SetTextColor(element.TextColor.ToAndroid());
            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }
            this.Control.TextChanged += (sender, arg) =>
            {
                var selectedDate = arg.Text.ToString();
                if (selectedDate == element.Placeholder)
                {
                    Control.Text = DateTime.Now.ToString("hh:mm tt");
                }
            };
            if (e.NewElement != null)
            {
                var view = (TimePickerBase)Element;
                if (view.IsCurvedCornersEnabled)
                {
                    // creating gradient drawable for the curved background  
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                    // Thickness of the stroke line  
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                    // Radius for the curves  
                    _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context, view.CornerRadius));
                    Control.SetMaxLines(1);
                    // set the background of the   
                    Control.SetBackground(_gradientBackground);
                    Control.RootView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
                // Set padding for the internal text from border  
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);
            }

        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}