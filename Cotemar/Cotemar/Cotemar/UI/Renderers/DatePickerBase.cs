using System;
using Cotemar.UI.FontsApp;
using Xamarin.Forms;

namespace Cotemar.UI.Renderers
{
    public class DatePickerBase : DatePicker
    {
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor),
                                    typeof(Color),
                                    typeof(DatePickerBase),
                                    Color.Gray);
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth),
                                    typeof(int),
                                    typeof(DatePickerBase),
                                    2);
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius),
                                    typeof(int),
                                    typeof(DatePickerBase),
                                    15);
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
            BindableProperty.Create(nameof(IsCurvedCornersEnabled),
                                    typeof(bool),
                                    typeof(DatePickerBase),
                                    true);
        public bool IsCurvedCornersEnabled
        {
            get => (bool)GetValue(IsCurvedCornersEnabledProperty);
            set => SetValue(IsCurvedCornersEnabledProperty, value);
        }
        public static readonly BindableProperty EnterTextProperty =
            BindableProperty.Create(propertyName: "Placeholder",
                                    returnType: typeof(string),
                                    declaringType: typeof(DatePickerBase),
                                    defaultValue: default(string));
        public string Placeholder
        {
            get;
            set;
        }
        public static readonly BindableProperty TypeFontProperty =
            BindableProperty.Create(propertyName: nameof(TypeFont),
                                    returnType: typeof(Fonts),
                                    declaringType: typeof(BorderEntryBase),
                                    defaultValue: Fonts.None);
        public Fonts TypeFont
        {
            get => (Fonts)GetValue(TypeFontProperty);
            set => SetValue(TypeFontProperty, value);
        }
        public DatePickerBase()
        {
            MaximumDate = DateTime.Now;
            Format = "dd/MM/yyyy";
        }
    }
}
