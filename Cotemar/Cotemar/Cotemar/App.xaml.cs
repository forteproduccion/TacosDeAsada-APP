using Cotemar.LocalData;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cotemar
{
    public partial class App
    {
        #region Vars
        public static string TAG = nameof(App);
        public static MasterDetailPage Master { get; set; }
        public static App CurrentApp { get; private set; }
        #endregion

        #region Constructors
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }
        #endregion

        #region Methods Init Prism
        protected override async void OnInitialized()
        {
            InitializeComponent();
            CurrentApp = this;
            if (UserSettings.GetBoolean(Key.Logged))
            {
                await NavigationService.NavigateAsync(new Uri("http://spartaneapp.com/Index/Navigation/Home", UriKind.Absolute));
            }
            else
            {
                await NavigationService.NavigateAsync(new Uri("http://spartaneapp.com/Navigation/LogIn", UriKind.Absolute));
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _ = new RegisterPagesAndPopups(containerRegistry);
            _ = new RegisterServicesAndInstances(containerRegistry, Container);
        }
        #endregion

        #region Life Cicle App Methods
        protected override void OnStart()
        {
            base.OnStart();
            AppCenter.Start("android=a7839b9a-d131-486e-ae90-dbe36fd632cf;" +
                  "ios=26354eb8-3cea-491d-8242-eb95f64fcbbd;",
                  typeof(Analytics), typeof(Crashes));
        }
        #endregion
    }
}