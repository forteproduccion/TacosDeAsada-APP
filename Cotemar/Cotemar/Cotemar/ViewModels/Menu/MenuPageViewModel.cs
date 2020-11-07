using Acr.UserDialogs;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Bases;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Cotemar.ViewModels.Menu
{
    public class MenuPageViewModel : PageViewModelBase
    {

        #region Constructor
        public MenuPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        protected override string Tag() => nameof(MenuPageViewModel);

        protected override string TitlePage() => "Menu";

        #endregion

    }
}
