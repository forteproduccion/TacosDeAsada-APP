using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using Cotemar.Models.Spartane;

namespace Cotemar.UI.ItemsCollectionView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemUserCollectionView : Grid
    {
        public ItemUserCollectionView()
        {
            InitializeComponent();
        }
        public ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }
        public static BindableProperty EditCommandProperty =
             BindableProperty.Create(nameof(EditCommand), typeof(ICommand), typeof(ItemUserCollectionView), null);
        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        public static BindableProperty DeleteCommandProperty =
            BindableProperty.Create(nameof(DeleteCommand), typeof(ICommand), typeof(ItemUserCollectionView), null);

        private void Edit_Click(object sender, System.EventArgs e)
        {
            if (BindingContext is UsersModel detail)
            {
                EditCommand?.Execute(detail);
            }
        }      
        
        private void Delete_Click(object sender, System.EventArgs e)
        {
            if (BindingContext is UsersModel detail)
            {
                DeleteCommand?.Execute(detail);
            }
        }
    }
}