using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    /// <summary>
    /// The user of the program
    /// </summary>
    public class User
    {
        [Key]
        public required int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password {  get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public void AddReservation (Reservation reservation)
        {
            Reservations.Add(reservation);
        }

    }
}
