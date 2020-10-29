using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cotemar.LocalData;
using Cotemar.Models.App;
using Cotemar.Utils.Collections;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Bases;
using Xamarin.Forms;

namespace Cotemar.ViewModels
{
    public class MasterPageViewModel : BindableBase
    {
        #region Properties
        private bool _isExecNavigation;
        public bool IsExecNavigation
        {
            get => _isExecNavigation;
            set => SetProperty(ref _isExecNavigation, value);
        }
        #endregion

        #region Vars Commands
        public ICommand SelectedItemCommand => new Command(async (item) => await SelectedItemCommandExecute(item));

        public AsyncCommand CloseSessionCommand { get; set; }
        #endregion

        #region Collections
        public ObservableCollectionExt<ItemMenuModel> ItemsMenu { get; set; }
        #endregion

        #region Vars
        private readonly INavigationService navigationService;
        #endregion

        #region Constructor
        public MasterPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            CreatedMenu();
        }
        #endregion

        #region Methods
        private void CreatedMenu()
        {
            ItemsMenu = new ObservableCollectionExt<ItemMenuModel>()
            {
                new ItemMenuModel{ Page= "Home", Title="Rederers Base", Icon= "Gamepad" , PopupPage = true},
                new ItemMenuModel{ Page= "HomeBottomBar", Title="Home Bottom Bar", Icon="Ticket"},
                new ItemMenuModel{ Page= "Home", Title="Tablero de Continuidad", Icon="UserCircle"},
                new ItemMenuModel{ Page= "TiempoReal", Title="Tablero de Tiempo Real", Icon="Bell"},
                new ItemMenuModel{ Page= "Historicos", Title="Tablero Histórico", Icon="Plus"},
                new ItemMenuModel{ Page= "Home", Title="Analiticos Gráficas", Icon="PowerOff"},
                new ItemMenuModel{ Page= "Home", Title="Tableros Dinámicos", Icon="Minus"}
            };
        }
        #endregion

        #region Commands Methods
        private async Task SelectedItemCommandExecute(object item)
        {
            if (item is ItemMenuModel itemMenu)
            {
                if (IsExecNavigation) return;

                IsExecNavigation = true;
                if (itemMenu.PopupPage)
                {
                    App.Master.IsPresented = false;
                    var page = PageUtilities.GetCurrentPage(Application.Current.MainPage).BindingContext as PageViewModelBase;
                    await page.NavigationService.NavigateAsync(itemMenu.Page);
                }
                else
                {
                    await navigationService.NavigateAsync(new Uri($"Navigation/{itemMenu.Page}", UriKind.Relative));
                }
                IsExecNavigation = false;
            }
        }
        private async Task CloseSessionCommandExecuted()
        {
            if (IsExecNavigation) return;
            UserSettings.ClearUserSettings();
            IsExecNavigation = true;
            await navigationService.NavigateAsync(new Uri("http://spartaneapp.com/Navigation/LogIn", UriKind.Absolute));
            IsExecNavigation = false;
        }
        #endregion
    }
}
