using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class Videogame
    {
        public long VideogameId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }



        public long SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }




        public override string ToString()
        {
            return $"ID: {VideogameId}, Videogame {Name}, Release Date: {ReleaseDate}";
        }
    }
}
