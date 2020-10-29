using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cotemar.Views.Bases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarBase : ContentView
    {
        public ToolbarBase()
        {
            InitializeComponent();
        }
    }
}