using Acr.UserDialogs;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Bases;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Cotemar.ViewModels.Menu
{
    public class CustomersPageViewModel : PageViewModelBase
    {
        #region Var Commands
        public AsyncCommand NuevaMesa { get; set; }
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

        protected override string TitlePage() => "Menu";

        #endregion

    }


}
