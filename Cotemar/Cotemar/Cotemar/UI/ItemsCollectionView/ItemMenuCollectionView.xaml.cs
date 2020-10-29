using System;
using System.Windows.Input;
using Cotemar.Models.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cotemar.UI.ItemsCollectionView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemMenuCollectionView : ContentView
    {
        public ICommand SelectedCommand
        {
            get => (ICommand)GetValue(SelectedCommandProperty);
            set => SetValue(SelectedCommandProperty, value);
        }

        public static BindableProperty SelectedCommandProperty =
            BindableProperty.Create(nameof(SelectedCommand), typeof(ICommand), typeof(ItemMenuCollectionView), null);

        public ItemMenuCollectionView()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (BindingContext is ItemMenuModel item)
            {
                SelectedCommand?.Execute(item);
            }
        }
    }
}