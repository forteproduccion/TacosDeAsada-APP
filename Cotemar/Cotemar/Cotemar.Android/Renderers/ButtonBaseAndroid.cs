using Android.Content;
using Android.Graphics;
using Android.Views;
using Cotemar.Droid.Renderers;
using Cotemar.UI.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ButtonBase), typeof(ButtonBaseAndroid))]
namespace Cotemar.Droid.Renderers
{
    public class ButtonBaseAndroid : ButtonRenderer
    {

        private readonly Context context;

        public ButtonBaseAndroid(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                //Only enable hardware accelleration on lollipop
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }
                var font = UI.FontsApp.FontExtensions.FindNameFileForFont(((ButtonBase)Element).TypeFont);
                if (!string.IsNullOrEmpty(font))
                {
                    Control.Typeface = Typeface.CreateFromAsset(context.Assets, font);
                }

            }
        }

    }
}