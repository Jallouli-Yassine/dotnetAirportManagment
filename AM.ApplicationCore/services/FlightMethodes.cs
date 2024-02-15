using AM.ApplicationCore.Domain;
using AM.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.services
{
    public class FlightMethodes : Iflight
    {
        public List<Flight> Flights = new List<Flight>();
        /*
        public List<DateTime> GetFlightDates(string des)
        {
            List <DateTime> fDesitaion = new List<DateTime>();
            for (int i = 0; i < Flights.Count; i++) {
                if (Flights[i].Destination == des)
                {
                    fDesitaion.Add(Flights[i].FlightDate);
                }
            }
            return fDesitaion;
        }
       

        public List<DateTime> GetFlightDates(string des)
        {
            List<DateTime> fDesitaion = new List<DateTime>();
            foreach (Flight f in Flights)
            {
                if (f.Destination == des)
                {
                    fDesitaion.Add(f.FlightDate);
                }
            }

            return fDesitaion;
        }
        */

        public List<DateTime> GetFlightDates(string des)
        {
            var query = from f in Flights 
                        where f.Destination == des
                        select f.FlightDate;

            return query.ToList();
        }

        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> filteredFlights = new List<Flight>();
            PropertyInfo property = typeof(Flight).GetProperty(filterType);
            if (property == null)
            {
                throw new ArgumentException("Invalid filterType");
            }
            foreach (Flight flight in Flights)
            {
                object value = property.GetValue(flight);
                if (value != null && value.ToString() == filterValue)
                {
                    filteredFlights.Add(flight);
                }
            }
            return filteredFlights;

        }



        public void ShowFlightDetails(Plane plane)
        {
            var flightDetails = from flight in plane.Flights
                                select new { flight.FlightDate,  flight.Destination };
            Console.WriteLine($"Flight details for Plane {plane.PlanedId} ({plane.PlanType}):");
            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Date: {detail.FlightDate}, Destination: {detail.Destination}");
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(7);

            var numberOfFlights = (from f in Flights
                                   where f.FlightDate >= startDate && f.FlightDate < endDate
                                   select f).Count();

            return numberOfFlights;
        }

        public double DurationAverage(string destination)
        {
            var averageDuration = Flights.Where(f => f.Destination == destination)
                                         .Average(f => f.EstimatedDuration);

            return averageDuration;
        }
    }
}
