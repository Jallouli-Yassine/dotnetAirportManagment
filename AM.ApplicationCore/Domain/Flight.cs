using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public Flight() { } 

        #region dehe
        

        #endregion dehe

        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string? Dparture { get; set; }
        public string? Destination { get; set; }

        public Plane Plane { get; set; }

        public ICollection<Passenger> Passengers { get; set;}

        



        /*
        private string name;
        public string getName() { return name; }
        public void setName(string name) {
            this.name = name;
        }

        public int Id {  get; set; }

        public private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public int MyProperty1 { get;private set; }

        */
    }
}
