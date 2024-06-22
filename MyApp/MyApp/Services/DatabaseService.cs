using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = new List<User>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("SELECT * FROM Users", conn))
                {
                    var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        users.Add(new User
                        {
                            UserID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2)
                        });
                    }
                }
            }
            return users;
        }

        public async Task AddUserAsync(User user)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", conn))
                {
                    cmd.Parameters.AddWithValue("Name", user.Name);
                    cmd.Parameters.AddWithValue("Email", user.Email);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Medication>> GetMedicationsAsync(int userId)
        {
            var medications = new List<Medication>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("SELECT * FROM Medications WHERE UserID = @UserID", conn))
                {
                    cmd.Parameters.AddWithValue("UserID", userId);
                    var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        medications.Add(new Medication
                        {
                            MedicationID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            Dosage = reader.GetString(3),
                            ReminderTime = reader.GetTimeSpan(4)
                        });
                    }
                }
            }
            return medications;
        }

        public async Task AddMedicationAsync(Medication medication)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("INSERT INTO Medications (UserID, Name, Dosage, ReminderTime) VALUES (@UserID, @Name, @Dosage, @ReminderTime)", conn))
                {
                    cmd.Parameters.AddWithValue("UserID", medication.UserID);
                    cmd.Parameters.AddWithValue("Name", medication.Name);
                    cmd.Parameters.AddWithValue("Dosage", medication.Dosage);
                    cmd.Parameters.AddWithValue("ReminderTime", medication.ReminderTime);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
