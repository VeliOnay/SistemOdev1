using Xamarin.Forms;
using MyApp.ViewModels;
using MyApp.Services;
using System;

namespace MyApp.Views
{
    public partial class UserListPage : ContentPage
    {
        private readonly UserListViewModel _viewModel;

        public UserListPage()
        {
            InitializeComponent();
            var databaseService = new DatabaseService("Host=localhost;Port=5432;Database=ilac_yonetimi_db;Username=postgres;Password=1234");
            _viewModel = new UserListViewModel(databaseService);
            BindingContext = _viewModel;
        }

        private async void OnAddUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUserPage());
        }
    }
}
