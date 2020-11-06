using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cotemar.UI.Customs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyTextCollectionView : Grid
    {
        public string TextEmptyCollectionView
        {
            get => (string)GetValue(TextEmptyCollectionViewProperty);
            set => SetValue(TextEmptyCollectionViewProperty, value);
        }

        public static readonly BindableProperty TextEmptyCollectionViewProperty =
        BindableProperty.Create(nameof(TextEmptyCollectionView),
                                typeof(string),
                                typeof(EmptyTextCollectionView),
                                "No contamos con elementos el momento");
        public EmptyTextCollectionView()
        {
            InitializeComponent();
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName.Equals(TextEmptyCollectionViewProperty.PropertyName))
            {
                text.Text = TextEmptyCollectionView;
            }
        }
    }
}