using System.Collections.Generic;
using System.ComponentModel;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class UserListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<User> _users;
        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Users)));
            }
        }

        private readonly DatabaseService _databaseService;

        public UserListViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            LoadUsers();
        }

        private async void LoadUsers()
        {
            Users = await _databaseService.GetUsersAsync();
        }
    }
}
