﻿using Prism.Ioc;
using Cotemar.ViewModels;
using Cotemar.ViewModels.Home;
using Cotemar.ViewModels.Popups;
using Cotemar.Views;
using Cotemar.Views.Home;
using Cotemar.Views.Popups;
using Xamarin.Forms;
using Cotemar.Views.Session;
using Cotemar.ViewModels.Session;

namespace Cotemar
{
    public class RegisterPagesAndPopups
    {
        public RegisterPagesAndPopups(IContainerRegistry containerRegistry)
        {
            #region Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            #endregion


            #region Session Page's
            containerRegistry.RegisterForNavigation<LogInPage, LogInPageViewModel>("LogIn");
            #endregion

            #region Pages
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>("Home");
            #endregion

            #region Popups
            containerRegistry.RegisterForNavigation<MessagePopup, MessagePopupViewModel>("Message");
            #endregion
        }
    }
}
