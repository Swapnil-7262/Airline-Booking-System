using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airline_Booking_System
{
    
    class Flight
    {
        private String flightNo;
        private String origin;
        private String destination;
        private int availableSeat;
        public Flight(String flightNo, String origin, String destination, int totalSeat)
        {
            this.flightNo = flightNo;
            this.origin = origin;
            this.destination = destination;
            this.availableSeat = totalSeat;
        }
        public String getFilghtNo()
        {
            return flightNo;
        }
        public String getOrigin()
        {
            return origin;
        }
        public String getDestination()
        {
            return destination;
        }
        public int getAvailableSeat()
        {
            return availableSeat;
        }

        public void bookSeat()
        {
            Console.WriteLine("How many Seat are you want? ");
            int seat = Convert.ToInt32(Console.ReadLine());
            if (availableSeat > 0)
            {
                Console.WriteLine("Seat booked successfully.");
                availableSeat = availableSeat - seat;
            }
            else
            {
                Console.WriteLine("No available seats on this Flight.");
            }
        }

        public override String ToString()
        {
            return "Flight Number=" + flightNo + "\tOrigin=" + origin + "\tDestination=" + destination + "\tAvailable Seat=" + availableSeat;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Flight> list = new List<Flight>();
            list.Add(new Flight("FL001", "Mumbai", "New York", 100));
            list.Add(new Flight("FL002", "Punjab", "London", 120));


            while (true)
            {
                Console.WriteLine("Welcome to Airline Booking System");
                Console.WriteLine("1]View Flight");
                Console.WriteLine("2]Book Flight");
                Console.WriteLine("3]Exit");
                Console.WriteLine("Select an Option:");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Available Flights");
                        foreach (Flight flight in list)
                        {
                            Console.WriteLine(flight);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the flight Number");
                        String flightNo = Console.ReadLine();
                        bool found = false;
                        foreach (Flight flight in list)
                        {
                            if (flight.getFilghtNo().Equals(flightNo, StringComparison.OrdinalIgnoreCase))
                            {
                                flight.bookSeat();
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Flight is not Found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Exiting program. Thank you!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
