using System.Windows.Input;
using Xamarin.Forms;
using MyApp.Models;
using MyApp.Services;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Email { get; set; }

        private readonly DatabaseService _databaseService;

        public ICommand SaveCommand { get; }

        public AddUserViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            SaveCommand = new Command(async () => await AddUser());
        }

        private async Task AddUser()
        {
            var user = new User { Name = Name, Email = Email };
            await _databaseService.AddUserAsync(user);
        }
    }
}
