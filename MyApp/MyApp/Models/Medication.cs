using System;

namespace MyApp.Models
{
    public class Medication
    {
        public int MedicationID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public TimeSpan ReminderTime { get; set; }
    }
}
