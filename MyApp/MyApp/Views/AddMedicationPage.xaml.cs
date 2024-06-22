using Xamarin.Forms;
using MyApp.ViewModels;
using MyApp.Services;

namespace MyApp.Views
{
    public partial class AddMedicationPage : ContentPage
    {
        private readonly AddMedicationViewModel _viewModel;

        public AddMedicationPage(int userId)
        {
            InitializeComponent();
            var databaseService = new DatabaseService("Host=localhost;Port=5432;Database=ilac_yonetimi_db;Username=postgres;Password=1234");
            _viewModel = new AddMedicationViewModel(databaseService, userId);
            BindingContext = _viewModel;
        }
    }
}
