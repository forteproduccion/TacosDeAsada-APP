#define Testing
using Cotemar.ViewModels.Bases;
using Cotemar.Models.Spartane;
using Acr.UserDialogs;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Input;
using Cotemar.Utils.Commands;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Cotemar.ViewModels.Users
{
    public class UsersPageViewModel : PageViewModelBase
    {
        #region varCommands
        public AsyncCommand NewUser { get; set; }
        public ICommand DeleteCommand => new Command(async (item) => await DeleteCommandExecute(item));
        public ICommand EditCommand => new Command(async (item) => await EditCommandExecute(item));
        #endregion

        #region Collections
        public ObservableCollection<UsersModel> Users { get; set; }
        #endregion

        #if Testing
        Testing.TestClass test;
        #endif

        #region Constructor
        public UsersPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        private void Testing() {
            test = new Testing.TestClass();
            System.Drawing.Color c1 = new System.Drawing.Color();
            System.Drawing.Color c2 = new System.Drawing.Color();
            c1 = System.Drawing.Color.FromArgb(222,222,222);
            c2 = System.Drawing.Color.FromArgb(243,243,243);
            var aux = true;
            foreach (var item in test.usrsTest) 
            {
                if (aux)
                {
                    item.BgColor = c1;
                }
                else 
                {
                    item.BgColor = c2;
                }
                aux = !aux;
                Users.Add(item);
            }
        }
        protected override string Tag() => nameof(UsersPageViewModel);

        protected override string TitlePage() => "Users";
        public override void Init()
        {
            base.Init();
            Users = new ObservableCollection<UsersModel>();
            NewUser = new AsyncCommand(async () => await NavigationService.NavigateAsync("NewUser"));
            Testing();
        }
        #endregion

        #region Command Methods 
        private async Task DeleteCommandExecute(object item)
        {
            if (item is UsersModel detail)
            {

                var request = await Application.Current.MainPage.DisplayAlert("Alerta", "¿Está seguro de eliminar a "+detail.Name+"?", "Aceptar", "Calcelar");
                if (request)
                {

                }
            }
        }
        private async Task EditCommandExecute(object item)
        {
            if (item is UsersModel detail)
            {
                
            }
        }

        #endregion 
    }
}
