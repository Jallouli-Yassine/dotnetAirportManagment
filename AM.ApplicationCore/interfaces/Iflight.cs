using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.interfaces
{
    public interface Iflight
    {
        public List<DateTime> GetFlightDates(string des);

        public List<Flight> GetFlights(string filterType, string filterValue);

        public void ShowFlightDetails(Plane plane);

        public int ProgrammedFlightNumber(DateTime startDate);

        public double DurationAverage(string destination);

        public List<Flight> OrderedDurationFlights();

        public IEnumerable<Traveller> SeniorTravellers(Flight flight);

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();


    }
}
