using Acr.UserDialogs;
using Prism.Navigation;
using Cotemar.ViewModels.Bases;

namespace Cotemar.ViewModels.Home
{
    public class HomePageViewModel : PageViewModelBase
    {
        #region Constructor
        public HomePageViewModel(INavigationService navigationService, IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        protected override string Tag() => nameof(HomePageViewModel);

        protected override string TitlePage() => "Home";
        #endregion
    }
}
