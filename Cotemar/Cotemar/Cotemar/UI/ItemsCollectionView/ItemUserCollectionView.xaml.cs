using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace Cotemar.UI.ItemsCollectionView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemUserCollectionView : Grid
    {

        public ItemUserCollectionView()
        {
            InitializeComponent();
        }
        public ICommand SelectedCommand
        {
            get => (ICommand)GetValue(SelectedCommandProperty);
            set => SetValue(SelectedCommandProperty, value);
        }
        public static BindableProperty SelectedCommandProperty =
             BindableProperty.Create(nameof(SelectedCommand), typeof(ICommand), typeof(ItemUserCollectionView), null);


    }
}