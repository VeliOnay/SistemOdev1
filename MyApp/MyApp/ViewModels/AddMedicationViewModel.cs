using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MyApp.Models;
using MyApp.Services;
using System.ComponentModel;
using System;

namespace MyApp.ViewModels
{
    public class AddMedicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Dosage { get; set; }
        public TimeSpan ReminderTime { get; set; }

        private readonly DatabaseService _databaseService;
        private readonly int _userId;

        public ICommand SaveCommand { get; }

        public AddMedicationViewModel(DatabaseService databaseService, int userId)
        {
            _databaseService = databaseService;
            _userId = userId;
            SaveCommand = new Command(async () => await AddMedication());
        }

        private async Task AddMedication()
        {
            var medication = new Medication
            {
                UserID = _userId,
                Name = Name,
                Dosage = Dosage,
                ReminderTime = ReminderTime
            };
            await _databaseService.AddMedicationAsync(medication);
        }
    }
}
