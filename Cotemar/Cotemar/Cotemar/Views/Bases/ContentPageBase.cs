using System;
using System.Diagnostics;
using Cotemar.UI.Customs;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Cotemar.Views.Bases
{
    public class ContentPageBase : ContentPage
    {
        #region Vars
        private readonly static string TAG = nameof(ContentPageBase);
        private readonly AbsoluteLayout _content = new AbsoluteLayout();
        private LoadingContentViewBase loading;
        #endregion

        #region Properties
        public static readonly BindableProperty ContentUIProperty =
        BindableProperty.Create(nameof(ContentUI),
                                typeof(View),
                                typeof(ContentPageBase), new ContentView(), propertyChanged: OnContentChanged);

        public View ContentUI
        {
            get { return (View)GetValue(ContentUIProperty); }
            set { SetValue(ContentUIProperty, value); }
        }

        public static readonly BindableProperty CustomToolbarProperty =
        BindableProperty.Create(nameof(CustomToolbar),
                                typeof(View),
                                typeof(ContentPageBase), new ContentView(), propertyChanged: OnCustomToolbarChanged);

        public View CustomToolbar
        {
            get { return (View)GetValue(CustomToolbarProperty); }
            set { SetValue(CustomToolbarProperty, value); }
        }


        public static readonly BindableProperty IsBackToolbarProperty =
        BindableProperty.Create(nameof(IsBackToolbar),
                                typeof(bool),
                                typeof(ContentPageBase), false, propertyChanged: IsBackToolbarChanged);

        public bool IsBackToolbar
        {
            get { return (bool)GetValue(ContentUIProperty); }
            set { SetValue(IsBackToolbarProperty, value); }
        }

        public static readonly BindableProperty HideToolbarProperty =
        BindableProperty.Create(nameof(HideToolbar),
                                typeof(bool),
                                typeof(ContentPageBase), false);

        public bool HideToolbar
        {
            get { return (bool)GetValue(HideToolbarProperty); }
            set { SetValue(HideToolbarProperty, value); }
        }

        public static readonly BindableProperty ShowLoadingProperty =
        BindableProperty.Create(nameof(ShowLoading),
                                typeof(bool),
                                typeof(ContentPageBase), false, propertyChanged: ShowLoadingChanged);



        public bool ShowLoading
        {
            get { return (bool)GetValue(ShowLoadingProperty); }
            set { SetValue(ShowLoadingProperty, value); }
        }
        #endregion

        #region Constructor
        public ContentPageBase()
        {
            try
            {
                BackgroundColor = Color.White;
                Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
                if (Device.RuntimePlatform.Equals(Device.iOS) && DeviceInfo.Version.Major <= 10)
                {
                    Padding = new Thickness(0, 20, 0, 0);
                }
                else
                {
                    On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
                }
                AbsoluteLayout.SetLayoutBounds(ContentUI, new Rectangle(0, 56, 1, 1));
                AbsoluteLayout.SetLayoutFlags(ContentUI, AbsoluteLayoutFlags.SizeProportional);
                _content.Children.Add(ContentUI);
                var toolbar = new ToolbarBase();
                AbsoluteLayout.SetLayoutBounds(toolbar, new Rectangle(0, 0, 1, 56));
                AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.XProportional);
                AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.YProportional);
                AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.WidthProportional);
                _content.Children.Insert(1, toolbar);
                loading = new LoadingContentViewBase
                {
                    Content = _content
                };
                Content = loading;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
        #endregion

        #region Methods
        private static void OnCustomToolbarChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ContentPageBase contentPageBase)
            {
                contentPageBase.SetChangeCustomToolbarToolbar(newValue as View);
            }
        }

        private static void ShowLoadingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ContentPageBase contentPageBase)
            {
                contentPageBase.loading.IsBusy = (bool)newValue;
            }
        }

        private void SetChangeCustomToolbarToolbar(View view)
        {
            try
            {
                if (view != null)
                {
                    _content.Children.Remove(_content.Children[1]);
                    AbsoluteLayout.SetLayoutBounds(view, new Rectangle(0, 0, 1, 56));
                    AbsoluteLayout.SetLayoutFlags(view, AbsoluteLayoutFlags.XProportional);
                    AbsoluteLayout.SetLayoutFlags(view, AbsoluteLayoutFlags.YProportional);
                    AbsoluteLayout.SetLayoutFlags(view, AbsoluteLayoutFlags.WidthProportional);
                    _content.Children.Insert(1, view);
                }
                else
                {
                    _content.Children.Remove(_content.Children[1]);
                    var toolbar = new ToolbarBase();
                    AbsoluteLayout.SetLayoutBounds(toolbar, new Rectangle(0, 0, 1, 56));
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.XProportional);
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.YProportional);
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.WidthProportional);
                    _content.Children.Insert(1, toolbar);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }

        private static void IsBackToolbarChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ContentPageBase contentPageBase)
            {
                contentPageBase.SetChangeToolbar((bool)newValue);
            }
        }

        private void SetChangeToolbar(bool isBackToolbar)
        {
            try
            {
                if (isBackToolbar)
                {
                    _content.Children.Remove(_content.Children[1]);
                    var toolbar = new ToolbarBackBase();
                    AbsoluteLayout.SetLayoutBounds(toolbar, new Rectangle(0, 0, 1, 56));
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.XProportional);
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.YProportional);
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.WidthProportional);
                    _content.Children.Insert(1, toolbar);
                }
                else
                {
                    _content.Children.Remove(_content.Children[1]);
                    var toolbar = new ToolbarBase();
                    AbsoluteLayout.SetLayoutBounds(toolbar, new Rectangle(0, 0, 1, 56));
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.XProportional);
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.YProportional);
                    AbsoluteLayout.SetLayoutFlags(toolbar, AbsoluteLayoutFlags.WidthProportional);
                    _content.Children.Insert(1, toolbar);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }

        private static void OnContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ContentPageBase contentPageBase)
            {
                contentPageBase.SetContent(newValue as View);
            }
        }

        private void SetContent(View view)
        {
            try
            {
                if (view != null)
                {
                    if (HideToolbar)
                    {
                        loading = new LoadingContentViewBase
                        {
                            Content = ContentUI
                        };
                        Content = loading;
                    }
                    else
                    {
                        _content.Children.Remove(_content.Children[0]);
                        view.Margin = new Thickness(0, 56, 0, 0);
                        AbsoluteLayout.SetLayoutBounds(view, new Rectangle(0, 56, 1, 1));
                        AbsoluteLayout.SetLayoutFlags(view, AbsoluteLayoutFlags.All);
                        _content.Children.Insert(0, view);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
        #endregion
    }
}
