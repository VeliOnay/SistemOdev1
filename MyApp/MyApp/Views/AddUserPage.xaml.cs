using Xamarin.Forms;
using MyApp.ViewModels;
using MyApp.Services;

namespace MyApp.Views
{
    public partial class AddUserPage : ContentPage
    {
        private readonly AddUserViewModel _viewModel;

        public AddUserPage()
        {
            InitializeComponent();
            var databaseService = new DatabaseService("Host=localhost;Port=5432;Database=ilac_yonetimi_db;Username=postgres;Password=1234");
            _viewModel = new AddUserViewModel(databaseService);
            BindingContext = _viewModel;
        }
    }
}
