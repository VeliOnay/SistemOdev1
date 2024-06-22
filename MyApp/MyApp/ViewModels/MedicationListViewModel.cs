using System.Collections.Generic;
using System.ComponentModel;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class MedicationListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Medication> _medications;
        public List<Medication> Medications
        {
            get { return _medications; }
            set
            {
                _medications = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Medications)));
            }
        }

        private readonly DatabaseService _databaseService;
        private readonly int _userId;

        public MedicationListViewModel(DatabaseService databaseService, int userId)
        {
            _databaseService = databaseService;
            _userId = userId;
            LoadMedications();
        }

        private async void LoadMedications()
        {
            Medications = await _databaseService.GetMedicationsAsync(_userId);
        }
    }
}
