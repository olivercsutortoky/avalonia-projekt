using System;

namespace ApartmentBooking.Models
{
    // In Java this would be a normal class with private fields plus getX()/setX()
    // methods. C# replaces those with "properties" written as { get; set; }.
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Guest()
        {
            // In Java a String field defaults to null. We set empty strings here
            // to avoid null problems later.
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
        }

        public Guest(int id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        // Turns the object into one line of text for the .txt file.
        public string ToFileString()
        {
            return Id + "|" + FirstName + "|" + LastName + "|" + Email + "|" + Phone;
        }

        // Builds a Guest back from one line of text.
        // Java: line.split("\\|")  -> needs a regex string
        // C#:   line.Split('|')    -> can take a single character
        public static Guest FromFileString(string line)
        {
            string[] parts = line.Split('|');

            if (parts.Length != 5)
            {
                // Java would usually throw IllegalArgumentException here.
                throw new FormatException("Invalid guest format: " + line);
            }

            Guest g = new Guest();
            // Java: Integer.parseInt(parts[0])
            g.Id = int.Parse(parts[0]);
            g.FirstName = parts[1];
            g.LastName = parts[2];
            g.Email = parts[3];
            g.Phone = parts[4];
            return g;
        }

        // A read-only property. In Java this would be a getFullName() method.
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        // Java: @Override public String toString()
        public override string ToString()
        {
            return FullName + " (" + Email + ")";
        }
    }
}
