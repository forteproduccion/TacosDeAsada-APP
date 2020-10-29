﻿using Acr.UserDialogs;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Cotemar.Models.Catalogs;
using Cotemar.Utils.Commands;
using Cotemar.ViewModels.Popups;
using Xamarin.Essentials;

namespace Cotemar.ViewModels.Bases
{
    public abstract class PopupViewModelBase : BindableBase, INavigationAware, IDestructible, IPageLifecycleAware
    {
        #region Vars
        protected INavigationService NavigationService { get; private set; }

        protected IUserDialogs UserDialogsService { get; private set; }

        protected NetworkAccess NetworkAccess { get; set; }
        #endregion

        #region Command Var's
        public AsyncCommand BackToPreviousPageCommand
        {
            get
            {
                return new AsyncCommand(async () =>
                {
                    await NavigationService.GoBackAsync();
                });
            }
        }

        public AsyncCommand BackToRootPage
        {
            get
            {
                return new AsyncCommand(async () =>
                {
                    await NavigationService.GoBackToRootAsync();
                });
            }
        }
        #endregion

        #region Properties
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private bool _isExecNavigation;
        public bool IsExecNavigation
        {
            get => _isExecNavigation;
            set => SetProperty(ref _isExecNavigation, value);
        }
        #endregion

        #region Constructor
        public PopupViewModelBase(INavigationService navigationService, IUserDialogs userDialogsService)
        {
            NetworkAccess = Connectivity.NetworkAccess;
            NavigationService = navigationService;
            UserDialogsService = userDialogsService;
            Init();
            InitCommands();
            InitServices();
        }
        #endregion

        #region Abstract Methods
        protected abstract string Tag();
        #endregion

        #region Virtual Methods
        public virtual void Init() { }

        public virtual void InitServices() { }

        public virtual void InitCommands() { }
        #endregion

        #region Services Api Methods
        protected async Task<ResponseBase<T>> RunSafeApi<T>(Task<T> runMethod)
        {
            var result = new ResponseBase<T>
            {
                Status = TypeReponse.Error,
                Response = default
            };
            try
            {
                if (NetworkAccess == NetworkAccess.Internet)
                {
                    try
                    {
                        int timeout = 60;
                        var task = runMethod;
                        if (await Task.WhenAny(task, Task.Delay((int)TimeSpan.FromSeconds(timeout).TotalMilliseconds)) == task)
                        {
                            if (task.Result != null)
                            {
                                result.Response = task.Result;
                            }
                            if (!result.Response.Equals(null))
                            {
                                result.Status = TypeReponse.Ok;
                            }
                        }
                        else
                        {
                            result.Status = TypeReponse.ConnectivityError;
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, Tag());
                    }
                }
                else
                {
                    result.Status = TypeReponse.ConnectivityError;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, Tag());
            }
            return result;
        }
        #endregion

        #region Messages Methods
        protected async Task ShowMessage(string title = null, string message = null, TypeMessage type = TypeMessage.done)
        {
            var navigationParameters = new NavigationParameters { { "title", title }, { "message", message }, { "type", type } };
            await NavigationService.NavigateAsync("Message", navigationParameters);
        }

        protected void Toast(string msg, int time = 3)
        {
            var toastConfig = new ToastConfig(msg)
            {
                Duration = TimeSpan.FromSeconds(time),
                Position = ToastPosition.Top
            };
            UserDialogs.Instance.Toast(toastConfig);
        }
        #endregion

        #region Methods of navigation of the Popup
        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
        #endregion

        #region Popup life cycle methods
        public virtual void Destroy() { }

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }
        #endregion
    }
}
