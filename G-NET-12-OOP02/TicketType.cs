using G_NET_12_OOP02;
using System;
using System.Collections.Generic;
using System.Text;

namespace G_NET_12_OOP02
{
    public enum TicketType
    {
        Standard,
        VIP,
        IMAX
    }

    public struct SeatLocation
    {
        public char Row { get; set; }
        public int Number { get; set; }

        public SeatLocation(char row, int number)
        {
            Row = row;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Row}-{Number}";
        }
    }

    public class Ticket
    {
        // Static counter
        private static int ticketCounter = 0;

        // Private fields
        private string? movieName;
        private double price;

        // Public auto-properties
        public TicketType Type { get; set; }
        public SeatLocation Seat { get; set; }

        // TicketId (read-only)
        public int TicketId { get; }

        // MovieName Property with validation
        public string? MovieName 
        {
            get { return movieName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    movieName = value;
            }
        }

        // Price Property with validation
        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        // Calculated Property (14% tax)
        public double PriceAfterTax
        {
            get { return Price * 1.14; }
        }

        // Constructor
        public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
        {
            ticketCounter++;
            TicketId = ticketCounter;

            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }

        // Static method
        public static int GetTotalTicketsSold()
        {
            return ticketCounter;
        }
    }
}
public class Cinema
{
    private Ticket[] tickets = new Ticket[20];

    // Indexer by index
    public Ticket this[int index]
    {
        get
        {
            if (index >= 0 && index < tickets.Length)
                return tickets[index];
            return null!;
        }
        set
        {
            if (index >= 0 && index < tickets.Length)
                tickets[index] = value;
        }
    }

    // Indexer by movie name
    public Ticket this[string movieName]
    {
        get
        {
            foreach (var ticket in tickets)
            {
                if (ticket != null &&
                    ticket.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
                    return ticket;
            }
            return null!;
        }
    }

    // Add ticket
    public bool AddTicket(Ticket t)
    {
        for (int i = 0; i < tickets.Length; i++)
        {
            if (tickets[i] == null)
            {
                tickets[i] = t;
                return true;
            }
        }
        return false;
    }
}
public static class BookingHelper
{
    private static int bookingCounter = 0;

    public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
    {
        double total = numberOfTickets * pricePerTicket;

        if (numberOfTickets >= 5)
            return total * 0.9;   // 10% discount

        return total;
    }

    public static string GenerateBookingReference()
    {
        bookingCounter++;
        return $"BK-{bookingCounter}";
    }
}