using SQLite;
using proyecto_final.Models;

namespace GasDetectorApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            InitializeDatabase();
        }

        private async void InitializeDatabase()
        {
            if (_database != null) return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "gasdetector.db");
            _database = new SQLiteAsyncConnection(databasePath);

            await _database.CreateTableAsync<User>();
            await _database.CreateTableAsync<GasAlert>();
        }

        // Operaciones para Users
        public async Task<int> CreateUser(User user)
        {
            return await _database.InsertAsync(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _database.Table<User>()
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }

        // Operaciones para GasAlerts
        public async Task<int> CreateAlert(GasAlert alert)
        {
            return await _database.InsertAsync(alert);
        }

        public async Task<List<GasAlert>> GetAlerts(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _database.Table<GasAlert>().OrderByDescending(a => a.Timestamp);

            if (fromDate.HasValue)
                query = query.Where(a => a.Timestamp >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(a => a.Timestamp <= toDate.Value);

            return await query.ToListAsync();
        }
    }
}