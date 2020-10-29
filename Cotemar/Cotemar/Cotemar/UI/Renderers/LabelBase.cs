using Cotemar.UI.FontsApp;
using Xamarin.Forms;

namespace Cotemar.UI.Renderers
{
    public class LabelBase : Label
    {
        /// <summary>
        /// Property definition for the <see cref="Fonts"/> Property
        /// </summary>
        public static readonly BindableProperty TypeFontProperty =
        BindableProperty.Create(propertyName: nameof(TypeFont),
              returnType: typeof(Fonts),
              declaringType: typeof(LabelBase),
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
