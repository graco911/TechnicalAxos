using TechnicalAxos.App.viewmodels;
using Xamarin.Forms;

namespace TechnicalAxos.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = MaingPageViewModel = new MainPageViewModel();
        }

        public MainPageViewModel MaingPageViewModel { get; }
    }
}
