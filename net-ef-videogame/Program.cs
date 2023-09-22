namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Videogames management system!");

            while (true)
            {
                Console.WriteLine(@"
             - 1: Add a new Videogame
             - 2: Search a Videogame by his ID
             - 3: Search all Videogames with the name containing a certain word or letters
             - 4: Delete a Videogame
             - 5: Add a new Software House 
             - 6: End Program
             ");

                Console.Write("Select an option that you like: ");

                int selectedOption = int.Parse(Console.ReadLine());
                switch (selectedOption)
                {

                    case 1:
                        {
                            //STAMPO LA LISTA DELLE SOFTWARE HOUSE
                            using (VideogameContext db = new VideogameContext())
                            {
                                List<SoftwareHouse> softwareHouses = db.SoftwareHouse.ToList<SoftwareHouse>();

                                foreach (SoftwareHouse softwareHouse in softwareHouses)
                                {
                                    Console.WriteLine("- " + softwareHouse.ToString());
                                }
                            }

                            // Raccolgo i dati per il nuovo videogioco
                            Console.WriteLine("Insert Videogame details: ");
                            Console.Write("Insert Videogame Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Insert Videogame Overview: ");
                            string overview = Console.ReadLine();

                            Console.Write("Insert Videogame Release date: ");
                            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Insert Software House ID: ");
                            long softwareHouseId = long.Parse(Console.ReadLine());

                            //Aggiungo il nuovo videogioco
                            Videogame newVideogame = new Videogame()
                            {
                                Name = name,
                                Overview = overview,
                                ReleaseDate = releaseDate,
                                SoftwareHouseId = softwareHouseId
                            };

                            using (VideogameContext db = new VideogameContext())
                            {
                                try
                                {
                                    db.Add(newVideogame);
                                    db.SaveChanges();

                                    Console.WriteLine("Videogame added succesfully!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        break;

                    case 2:
                        //Cerco un videogame filtrando per ID
                        Console.Write("Insert a Videogame ID: ");
                        long videogameId = long.Parse(Console.ReadLine());

                        using (VideogameContext db = new VideogameContext())
                        {

                            try
                            {
                                Videogame videogame = db.Videogame.Find(videogameId);
                                Console.WriteLine($"The Videogame that match your selected ID is: {videogame.Name}");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.Write("Insert a string: ");
                            string videogameString = (Console.ReadLine());

                            using (VideogameContext db = new VideogameContext())
                            {

                                try
                                {
                                    Videogame videogame = db.Videogame.Find(videogameString).ToList()<Videogame>;
                                    Console.WriteLine($"The Videogame that match your selected ID is: {videogame.Name}");

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;

                        }
                    case 4:
                        {
                            using (VideogameContext db = new VideogameContext())
                            {
                                List<Videogame> videogames = db.Videogame.ToList<Videogame>();

                                foreach (Videogame videogame in videogames)
                                {
                                    Console.WriteLine("- " + videogame.ToString());
                                }
                            }
                            Console.Write("Insert Videogame ID to delete: ");
                            long videogameIdToDelete = long.Parse(Console.ReadLine());

                            try
                            {
                                using (VideogameContext db = new VideogameContext())
                                {
                                    Videogame videogameToDelete = db.Videogame.Find(videogameIdToDelete);

                                    db.Remove(videogameToDelete);
                                    db.SaveChanges();

                                    Console.WriteLine("Videogame successfully deleted!");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        }
                    case 5:
                        {
                            // Raccolgo i dati per la nuova Software House
                            Console.WriteLine("Insert Software House details: ");
                            Console.Write("Insert Software House Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Insert Software House Country: ");
                            string country = Console.ReadLine();


                            //Aggiungo la nuova Software House
                            SoftwareHouse newSoftwareHouse = new SoftwareHouse()
                            {
                                Name = name,
                                Country = country,

                            };

                            using (VideogameContext db = new VideogameContext())
                            {
                                try
                                {
                                    db.Add(newSoftwareHouse);
                                    db.SaveChanges();

                                    Console.WriteLine("Software House added succesfully!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;
                        }




                }

            }
        }
    }
}