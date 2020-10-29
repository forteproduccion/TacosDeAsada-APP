using Acr.UserDialogs;
using Prism.Ioc;
using Prism.Plugin.Popups;
using SQLite;
using Cotemar.DependencyServices;

namespace Cotemar
{
    public class RegisterServicesAndInstances
    {

        public RegisterServicesAndInstances(IContainerRegistry containerRegistry, IContainerProvider container)
        {
            #region Instances
            containerRegistry.RegisterInstance(new SQLiteAsyncConnection(container.Resolve<ISqlLiteDependecyService>().GetDatabasePath()));
            containerRegistry.RegisterInstance(typeof(IUserDialogs), UserDialogs.Instance);
            #endregion

            #region Services
            containerRegistry.RegisterPopupNavigationService();
            #endregion
        }
    }
}
