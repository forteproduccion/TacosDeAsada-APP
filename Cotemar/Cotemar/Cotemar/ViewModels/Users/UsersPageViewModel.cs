
using Acr.UserDialogs;
using Prism.Navigation;
using Cotemar.ViewModels.Bases;

namespace Cotemar.ViewModels.Users
{
    public class UsersPageViewModel : PageViewModelBase
    {
        #region Constructor
        public UsersPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        protected override string Tag() => nameof(UsersPageViewModel);

        protected override string TitlePage() => "Users";
        #endregion
    }
}
