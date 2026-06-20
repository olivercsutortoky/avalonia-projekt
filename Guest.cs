using System;

namespace ApartmentBooking.Models
{
    // An enum looks almost the same in Java. Java usually writes the values in
    // UPPERCASE; the C# convention is PascalCase (first letter capital).
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }

    public class Reservation
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int ApartmentId { get; set; }
        // Java uses LocalDate / LocalDateTime. C# uses one type DateTime for both.
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }
        public int TotalPrice { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        public Reservation()
        {
            Notes = "";
            Status = ReservationStatus.Pending;
        }

        public Reservation(int id, int guestId, int apartmentId, DateTime checkIn, DateTime checkOut, int totalPrice, string notes)
        {
            Id = id;
            GuestId = guestId;
            ApartmentId = apartmentId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPrice = totalPrice;
            Notes = notes;
            Status = ReservationStatus.Pending;
            // Java: LocalDateTime.now()
            CreatedAt = DateTime.Now;
        }

        // Number of nights between check-in and check-out.
        public int Nights
        {
            get
            {
                // Java: ChronoUnit.DAYS.between(checkIn, checkOut)
                // C#: subtracting two DateTime values gives a TimeSpan, which has .TotalDays
                return (int)(CheckOut - CheckIn).TotalDays;
            }
        }

        public string ToFileString()
        {
            string safeNotes = Notes.Replace("|", "/");
            // "yyyy-MM-dd" keeps the date readable and the same on every computer.
            // Java: checkIn.format(DateTimeFormatter.ofPattern("yyyy-MM-dd"))
            return Id + "|" + GuestId + "|" + ApartmentId + "|"
                   + CheckIn.ToString("yyyy-MM-dd") + "|"
                   + CheckOut.ToString("yyyy-MM-dd") + "|"
                   + Status + "|"
                   + TotalPrice + "|"
                   + safeNotes + "|"
                   + CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static Reservation FromFileString(string line)
        {
            string[] parts = line.Split('|');

            if (parts.Length != 9)
            {
                throw new FormatException("Invalid reservation format: " + line);
            }

            Reservation r = new Reservation();
            r.Id = int.Parse(parts[0]);
            r.GuestId = int.Parse(parts[1]);
            r.ApartmentId = int.Parse(parts[2]);
            r.CheckIn = DateTime.Parse(parts[3]);
            r.CheckOut = DateTime.Parse(parts[4]);
            // Java: ReservationStatus.valueOf(parts[5])
            r.Status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), parts[5]);
            r.TotalPrice = int.Parse(parts[6]);
            r.Notes = parts[7];
            r.CreatedAt = DateTime.Parse(parts[8]);
            return r;
        }

        public override string ToString()
        {
            return "Rezervace #" + Id + " | " + CheckIn.ToString("dd.MM.yyyy")
                   + " - " + CheckOut.ToString("dd.MM.yyyy") + " | " + Status;
        }
    }
}
