using Cotemar.ViewModels.Bases;
using Cotemar.Models.Spartane;
using Acr.UserDialogs;
using Prism.Navigation;
using Cotemar.Utils.Commands;
using System.Threading.Tasks;
using Cotemar.Testing;

namespace Cotemar.ViewModels.Users
{
    
    class NewUserPageViewModel : PageViewModelBase
    {
        #region Vars
        public UsersModel user { get; set; }
        public bool Admin { get; set; } 
        public string Password { get; set; } 
        #endregion

        #region VarCommands
        public AsyncCommand NewUserCommand { get; set; }
        #endregion

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
            user = new UsersModel();
            user.initEmpty();
        }
        public override void InitCommands()
        {
            base.InitCommands();
            NewUserCommand = new AsyncCommand(NewUserCommandExcecute);
        }
        #endregion

        #region CommandsMethods
        public async Task NewUserCommandExcecute()
        {
            if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(Password))
            {
                if (user.Password == Password)
                {
                    TestClass test = new TestClass();
                    test.usrsTest.Add(user);
                    await ShowMessage("Éxito", "Usuario Registrado", Popups.TypeMessage.done);
                }
                else
                {
                    await ShowMessage("Alerta", "Contraseñas no son iguales", Popups.TypeMessage.question);
                }
            }
            else 
            {
                await ShowMessage("Alerta", "Llena todos los campos", Popups.TypeMessage.question);
            }
        }
        #endregion

        #region Navigation Methods
        public override void OnNavigatedTo(INavigationParameters parameters)
        { 
            base.OnNavigatedTo(parameters);
            user = parameters.GetValue<UsersModel>("User");
            
        }
        #endregion
    }
}
