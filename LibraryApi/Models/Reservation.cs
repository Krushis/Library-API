using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    /// <summary>
    /// The info of the actual reservation
    /// </summary>
    public class Reservation
    {
        [Key]
        [Required]
        public string Id { get; set; }

        //[Required]
        //public Book Book { get; set; }

        [Required]
        public string BookId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public bool QuickPickUp { get; set; }

        [Required]
        public virtual Book? Book { get; set; }  // not sure if this is the best solution, but its something
        // i found while researching, a big problem is that the book object is non nullable so i have to either
        // make it required or do this, I wanted to try using this new method

        [Required]
        public int DaysReserved { get; set; }

        public double TotalCost { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        public Reservation(string id, string bookId, int userId, string type, bool quickPickUp, int daysReserved)
        {
            Id = id;
            BookId = bookId;
            //Book = book;
            UserId = userId;
            Type = type;
            QuickPickUp = quickPickUp;
            DaysReserved = daysReserved;
            TotalCost = ReturnReservationCost();
        }


        private double ReturnReservationCost()
        {
            double cost = 3; // service fee
            double reserveCost = 0;

            
            if (QuickPickUp)
            {
                cost += 5;
            }

            
            if (Type == "Book")
            {
                reserveCost += 2 * DaysReserved;
            }
            else
            {
                reserveCost += 3 * DaysReserved;
            }

            
            if (DaysReserved > 3 && DaysReserved <= 10)
            {
                cost += 0.9 * reserveCost;
            }
            else if (DaysReserved > 10)
            {
                cost += 0.8 * reserveCost;
            }
            else
            {
                cost += reserveCost;
            }

            return cost;
        }

    }
}
