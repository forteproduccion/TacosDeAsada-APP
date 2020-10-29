using Cotemar.UI.IconsApp;
using Xamarin.Forms;

namespace Cotemar.UI.Renderers
{
    public class IconAwesomeButtonBase : Button
    {


        /// <summary>
        /// Border thickness of circle image
        /// </summary>
        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

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
        /// Thickness property of border
        /// </summary>
        public static readonly BindableProperty BorderThicknessProperty =
          BindableProperty.Create(propertyName: nameof(BorderThickness),
              returnType: typeof(int),
              declaringType: typeof(IconAwesomeButtonBase),
              defaultValue: 0);

        /// <summary>
        /// Property definition for the <see cref="Fonts"/> Property
        /// </summary>
        public static readonly BindableProperty TypeIconProperty =
        BindableProperty.Create(propertyName: nameof(TypeIcon),
              returnType: typeof(Icons),
              declaringType: typeof(IconAwesomeButtonBase),
              defaultValue: Icons.Solid);

        /// <summary>
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static readonly BindableProperty IconProperty =
        BindableProperty.Create(propertyName: nameof(Icon),
              returnType: typeof(string),
              declaringType: typeof(IconAwesomeButtonBase),
              defaultValue: string.Empty);
    }
}
