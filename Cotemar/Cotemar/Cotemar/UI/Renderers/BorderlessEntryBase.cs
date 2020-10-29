using Cotemar.UI.FontsApp;
using Xamarin.Forms;

namespace Cotemar.UI.Renderers
{
    public partial class BorderlessEntryBase : Entry
    {
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
