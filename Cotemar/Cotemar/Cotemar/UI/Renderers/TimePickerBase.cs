using Cotemar.UI.FontsApp;
using Xamarin.Forms;

namespace Cotemar.UI.Renderers
{
    public class TimePickerBase : TimePicker
    {
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor),
                typeof(Color), typeof(TimePickerBase), Color.Gray);
        // Gets or sets BorderColor value  
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(int),
                typeof(TimePickerBase), 2);
        // Gets or sets BorderWidth value  
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius),
                typeof(int), typeof(TimePickerBase), 15);
        // Gets or sets CornerRadius value  
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
            BindableProperty.Create(nameof(IsCurvedCornersEnabled),
                typeof(bool), typeof(TimePickerBase), true);
        // Gets or sets IsCurvedCornersEnabled value  
        public bool IsCurvedCornersEnabled
        {
            get => (bool)GetValue(IsCurvedCornersEnabledProperty);
            set => SetValue(IsCurvedCornersEnabledProperty, value);
        }
        public TimePickerBase()
        {
            Format = "hh:mm tt";
        }

        public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(TimePickerBase), defaultValue: default(string));
        public string Placeholder
        {
            get;
            set;
        }
        /// <summary>
        /// Property definition for the <see cref="Fonts"/> Property
        /// </summary>
        public static readonly BindableProperty TypeFontProperty =
        BindableProperty.Create(propertyName: nameof(TypeFont),
              returnType: typeof(Fonts),
              declaringType: typeof(TimePickerBase),
              defaultValue: Fonts.None);

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The button.
        /// </value>
        public Fonts TypeFont
        {
            get => (Fonts)GetValue(TypeFontProperty);
            set => SetValue(TypeFontProperty, value);
        }
    }
}
