using Xamarin.Forms;
using Cotemar.UI.FontsApp;

namespace Cotemar.UI.Renderers
{
    public class BorderEditorBase : Editor
    {
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor),
                                    typeof(Color),
                                    typeof(BorderEditorBase),
                                    Color.Gray);
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth),
                                    typeof(int),
                                    typeof(BorderEditorBase),
                                    2);
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius),
                                    typeof(int),
                                    typeof(BorderEditorBase),
                                    15);
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
            BindableProperty.Create(nameof(IsCurvedCornersEnabled),
                                    typeof(bool),
                                    typeof(BorderEditorBase),
                                    true);
        public bool IsCurvedCornersEnabled
        {
            get => (bool)GetValue(IsCurvedCornersEnabledProperty);
            set => SetValue(IsCurvedCornersEnabledProperty, value);
        }
        public static readonly BindableProperty TypeFontProperty =
            BindableProperty.Create(propertyName: nameof(TypeFont),
                                    returnType: typeof(Fonts),
                                    declaringType: typeof(BorderEditorBase),
                                    defaultValue: Fonts.None);
        public Fonts TypeFont
        {
            get => (Fonts)GetValue(TypeFontProperty);
            set => SetValue(TypeFontProperty, value);
        }
    }
}
