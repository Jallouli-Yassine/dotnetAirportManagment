using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }

        public string PassportNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public int TelNumber { get; set; }

        public string EmailAdresse { get; set; }
        
        public ICollection<Flight> Flights { get; set; }







    }
}
