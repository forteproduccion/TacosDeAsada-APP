using Acr.UserDialogs;
using Cotemar.Models.Spartane;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Bases;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;

namespace Cotemar.ViewModels.Menu
{
    public class CustomersPageViewModel : PageViewModelBase
    {

        #region commands
        public AsyncCommand TableCommand { get; set; }
        public AsyncCommand QuickCommand { get; set; }
        #endregion
        #region Collections
        public ObservableCollection<TableModel> Tables { get; set; }
        #endregion
        #region Testing
        Testing.TestClass test;
        #endregion


        #region Constructor
        public CustomersPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

        #region Init Methods
        public override void Init()
        {
            base.Init();
            Tables = new ObservableCollection<TableModel>();
            Testing();
        }

        private void Testing()
        {
            test = new Testing.TestClass();
            Color c1 = new Color();
            Color c2 = new Color();
            c1 = Color.FromArgb(222, 222, 222);
            c2 = Color.FromArgb(243, 243, 243);
            var aux = true;
            foreach (var item in test.tablesTest)
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
                Tables.Add(item);
            }
        }
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
