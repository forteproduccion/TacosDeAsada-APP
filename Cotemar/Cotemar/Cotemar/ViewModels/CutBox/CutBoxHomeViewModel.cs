using Acr.UserDialogs;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Bases;
using Prism.Navigation;

namespace Cotemar.ViewModels.CutBox
{
    class CutBoxHomeViewModel : PageViewModelBase
    {
        #region Constructor
        public CutBoxHomeViewModel(INavigationService navigationService, IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        protected override string Tag() => nameof(CutBoxHomeViewModel);

        protected override string TitlePage() => "CutBox";

 
        #endregion
    }
}
