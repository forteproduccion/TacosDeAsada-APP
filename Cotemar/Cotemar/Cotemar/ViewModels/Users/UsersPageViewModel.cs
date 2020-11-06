using Cotemar.ViewModels.Bases;
using Cotemar.Models.Spartane;
using Acr.UserDialogs;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Cotemar.ViewModels.Users
{
    public class UsersPageViewModel : PageViewModelBase
    {
        #region Collections
        public ObservableCollection<UsersModel> Users { get; set; }
        #endregion
        #region Testing
        Testing.TestClass test;
        #endregion

        #region Constructor
        public UsersPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        private void Testing() {
            test = new Testing.TestClass();
            Color c1 = new Color();
            Color c2 = new Color();
            c1 = Color.FromArgb(222,222,222);
            c2 = Color.FromArgb(243,243,243);
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
            Testing();
        }
        #endregion
    }
}
