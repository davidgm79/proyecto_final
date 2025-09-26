using SQLite;

namespace proyecto_final.Models
{
    public class AppConfig
    {
        public double GasThreshold { get; set; } = 500;
        public bool BuzzerEnabled { get; set; } = true;
        public bool EmailNotifications { get; set; } = true;
        public bool PushNotifications { get; set; } = true;
    }
}