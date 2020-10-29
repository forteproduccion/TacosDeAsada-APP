using Foundation;
using Lottie.Forms.iOS.Renderers;
using Prism;
using Prism.Ioc;
using Cotemar.DependencyServices;
using Cotemar.iOS.DependencyServices;
using UIKit;

namespace Cotemar.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            #region Change color status bar
            UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            statusBar.BackgroundColor = UIColor.FromRGB(27, 46, 72);
            var navigationController = new UINavigationController();
            navigationController.NavigationBar.TintColor = UIColor.White;
            navigationController.NavigationBar.BarTintColor = UIColor.FromRGB(52, 152, 219);
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.White
            });
            #endregion

            #region Init Components
            global::Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            AnimationViewRenderer.Init(); // Initializing Lottie
            #endregion

            LoadApplication(new App(new IOSInitializer()));
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }

    public class IOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.Register<ISqlLiteDependecyService, SqlLiteDependecyServiceiOS>();
        }
    }
}
