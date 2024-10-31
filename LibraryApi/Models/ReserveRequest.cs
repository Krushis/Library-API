namespace LibraryApi.Models
{
    /// <summary>
    /// The reserve request
    /// </summary>
    public class ReserveRequest
    {
        public int UserId { get; set; }

        public string BookId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool QuickPickUp { get; set; }
        public int DaysReserved { get; set; }
    }
}
