using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum planeType
    {
        Boing,
        Airbus
    }
    public class Plane
    {
        public int PlanedId { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }

        public planeType PlanType { get; set; }

        public ICollection<Flight> Flights { get; set;}

    }
}
