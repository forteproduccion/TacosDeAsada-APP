using Cotemar.ViewModels.Bases;
using Cotemar.Models.Spartane;
using Acr.UserDialogs;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Cotemar.ViewModels.Users
{
    class NewUserPageViewModel : PageViewModelBase
    {

        #region Constructor
        public NewUserPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
 
        protected override string Tag() => nameof(NewUserPageViewModel);

        protected override string TitlePage() => "NewUser";
        public override void Init()
        {
            base.Init();
        }
        #endregion
    }
}
