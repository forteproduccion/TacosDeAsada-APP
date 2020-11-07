using Acr.UserDialogs;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Bases;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Cotemar.ViewModels.Menu
{
    public class CustomersPageViewModel : PageViewModelBase
    {

        #region commands
        public AsyncCommand TableCommand { get; set; }
        public AsyncCommand QuickCommand { get; set; }
        #endregion



        #region Constructor
        public CustomersPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        protected override string Tag() => nameof(CustomersPageViewModel);

        protected override string TitlePage() => "Customers";

        public override void InitCommands()
        {
            base.InitCommands();
            TableCommand = new AsyncCommand(async () => await NavigationService.NavigateAsync("Menu"));
            QuickCommand = new AsyncCommand(async () => await NavigationService.NavigateAsync("Menu"));
        }

        #endregion

    }


}
