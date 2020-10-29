using Cotemar.UI.IconsApp;
using Xamarin.Forms;

namespace Cotemar.UI.Renderers
{
    public class IconAwesomeLabelBase : Label
    {

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public Icons TypeIcon
        {
            get { return (Icons)GetValue(TypeIconProperty); }
            set { SetValue(TypeIconProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }


        /// <summary>
        /// Property definition for the <see cref="Fonts"/> Property
        /// </summary>
        public static readonly BindableProperty TypeIconProperty =
        BindableProperty.Create(propertyName: nameof(TypeIcon),
              returnType: typeof(Icons),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: Icons.Solid);

        /// <summary>
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static readonly BindableProperty IconProperty =
        BindableProperty.Create(propertyName: nameof(Icon),
              returnType: typeof(string),
              declaringType: typeof(IconAwesomeLabelBase),
              defaultValue: string.Empty);
    }
}
