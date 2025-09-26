using proyecto_final.Models;
using SQLite;

namespace proyecto_final.Models
{
    [SQLite.Table("GasAlerts")]
    public class GasAlert
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string SensorId { get; set; }
        public double GasLevel { get; set; }
        public double Threshold { get; set; }
        public DateTime Timestamp { get; set; }
        public bool NotificationSent { get; set; }
        public bool EmailSent { get; set; }
    }
}