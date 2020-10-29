using Acr.UserDialogs;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Bases;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Cotemar.ViewModels.Session
{
    public class LogInPageViewModel : PageViewModelBase
    {

        #region Var Commands 
        public AsyncCommand LogInCommand { get; set; }
        public AsyncCommand ShowPopupTypeSessionCommand { get; set; }
        #endregion

        #region Constructor
        public LogInPageViewModel(
            INavigationService navigationService, 
            IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods

        public override void InitCommands()
        {
            base.InitCommands();
            LogInCommand = new AsyncCommand(LogInCommandExecute);
            ShowPopupTypeSessionCommand = new AsyncCommand(ShowPopupTypeSessionCommandExecute);
        }

        protected override string Tag() => nameof(LogInPageViewModel);

        protected override string TitlePage() => "Login";
        #endregion

        #region Methods Command
        private async Task ShowPopupTypeSessionCommandExecute()
        {
            await NavigationService.NavigateAsync("");
        }

        private async Task LogInCommandExecute()
        {
            await NavigationService.NavigateAsync("Home");
        }
        #endregion
    }
}