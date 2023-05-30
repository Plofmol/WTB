namespace WTB.Models
{
    public class StreamingServices
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Netflix { get; set; }
        public bool AmazonPrime { get; set; }
        public bool DisneyPlus { get; set; }
        public bool HBO { get; set; }

        // Navigation property for User
        public User User { get; set; }
    }
}
