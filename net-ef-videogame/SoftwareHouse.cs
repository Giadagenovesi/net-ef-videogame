using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class SoftwareHouse
    {
        public long SoftwareHouseId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }


        //Collego le tabelle con relazione 1 a molti
        public List<Videogame> Videogame { get; set; }

        public override string ToString()
        {
            return $"ID: {SoftwareHouseId} Software House name: {Name}, Origin Country: {Country}";
        }

    }
}
