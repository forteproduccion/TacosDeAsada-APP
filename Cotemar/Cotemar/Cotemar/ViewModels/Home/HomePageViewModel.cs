using Acr.UserDialogs;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Bases;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Cotemar.ViewModels.Home
{
    public class HomePageViewModel : PageViewModelBase
    {
        #region commands
        public AsyncCommand UsersCommand { get; set; }
        #endregion
        #region Constructor
        public HomePageViewModel(INavigationService navigationService, IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        protected override string Tag() => nameof(HomePageViewModel);

        protected override string TitlePage() => "Home";

        public override void InitCommands()
        {
            base.InitCommands();
            UsersCommand = new AsyncCommand(UsersCommandExecute);
        }
        #endregion
        #region commandExecute
        private async Task UsersCommandExecute()
        {
            await NavigationService.NavigateAsync("Users");
        }
        #endregion
    }
}
