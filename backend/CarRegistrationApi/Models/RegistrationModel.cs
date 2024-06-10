namespace CarRegistrationApi.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public bool IsNotificationSent { get; set; } = false;
    }
}
