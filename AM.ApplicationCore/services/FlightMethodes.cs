using AM.ApplicationCore.Domain;
using AM.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            IList<DateTime> fDesitaion = new List<DateTime>();
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



  
        

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            
            DateTime endDate = startDate.AddDays(7);
            /*
            var numberOfFlights = (from f in Flights
                                   where f.FlightDate >= startDate && f.FlightDate < endDate
                                   select f).Count();
            */

            return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate < endDate);
        }

        public double DurationAverage(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
                                         .Average(f => f.EstimatedDuration);


        }

        public List<Flight> OrderedDurationFlights()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration).ToList();
            /*
            var query = from f in Flights
                        orderby f.EstimatedDuration descending
                        select f;
            return query.ToList();
            */
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {

            return flight.Passengers.OfType<Traveller>().OrderBy(p=> p.Birthdate).Take(3);
            /*
            var query = from p in flight.Passengers.OfType<Traveller>()
                        orderby p.Birthdate
                        select p;

            return query.Take(3);
            */

        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query = from f in Flights
                        group f by f.Destination;
            foreach (var item in query)
            {
             Console.WriteLine($"Destination {item.Key}");
                foreach(var detail in item)
                {
                    Console.WriteLine($"Destination {detail.FlightId}");
                }
            }
            return query;
        }

        public void ShowFlightDetails(Domain.Plane plane)
        {

            var flightDetails = from flight in plane.Flights
                                select new { flight.FlightDate, flight.Destination };
            Console.WriteLine($"Flight details for Plane {plane.PlanedId} ({plane.PlanType}):");
            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Date: {detail.FlightDate}, Destination: {detail.Destination}");
            }
        }
    }
}
