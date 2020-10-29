using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Diagnostics;
using Cotemar.ViewModels.Bases;

namespace Cotemar.ViewModels.Popups
{
    public class MessagePopupViewModel : PopupViewModelBase
    {
        #region Properties
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private string animate;
        public string Animate
        {
            get => animate;
            set => SetProperty(ref animate, value);
        }

        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }
        #endregion

        #region Vars Commands
        public DelegateCommand OnOkCommand { get; set; }
        #endregion

        #region Constructor
        public MessagePopupViewModel(INavigationService navigationService, IUserDialogs userDialogsService) : base(navigationService, userDialogsService)
        {

        }
        #endregion

        #region Init Methods
        public override void InitCommands()
        {
            base.InitCommands();
            OnOkCommand = new DelegateCommand(OnOkCommandExecute);
        }

        protected override string Tag() => nameof(MessagePopupViewModel);
        #endregion

        #region Command Methods
        private async void OnOkCommandExecute()
        {
            await NavigationService.GoBackAsync();
        }
        #endregion

        #region Navigation Methods
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                if (parameters.ContainsKey("title"))
                {
                    Title = parameters.GetValue<string>("title");
                }
                if (parameters.ContainsKey("message"))
                {
                    Message = parameters.GetValue<string>("message");
                }
                if (parameters.ContainsKey("type"))
                {
                    var type = (TypeMessage)parameters.GetValue<TypeMessage>("type");
                    Animate = type.ToString() + ".json";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, Tag());
            }
        }
        #endregion
    }
    public enum TypeMessage
    {
        done,
        error,
        question
    }
}
