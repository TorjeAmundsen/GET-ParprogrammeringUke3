using ParprogrammeringUke3;

namespace ParProgrammering
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Movie> MovieList = new List<Movie>();
            CreateNewMovie(MovieList);
        }
        public static void CreateNewMovie(List<Movie> movies)
        {
            Console.WriteLine("Adding new movie!");
            Console.Write("Input movie title: ");
            string title = Console.ReadLine();
            int releaseYear = AskForNumber("Input release year: ");
            Console.Write("Input Director: ");
            string director = Console.ReadLine();
            int actorCount = AskForNumber("How many actors are in the movie? ");
            Console.WriteLine("Which actors are in the movie? ");
            var actorList = new List<string>();
            for (int i = 0; i < actorCount; i++) {
                Console.Write($"Name of actor/actress {i + 1}: ");
                string input = Console.ReadLine();
                if (input == "cancel")
                {
                    actorList.Clear();
                    actorCount = AskForNumber("How many actors are in the movie? ");
                    Console.WriteLine("Which actors are in the movie? ");
                    i = -1;
                }
                else if (input == "edit")
                {
                    int editIndex = AskForNumber("Which actor would you like to edit? ", 1, actorCount) - 1;
                    Console.Write($"Name of actor/actress {editIndex + 1}: ");
                    input = Console.ReadLine();
                    if (input == "cancel")
                    {
                        actorList.Clear();
                        actorCount = AskForNumber("How many actors are in the movie? ");
                        Console.WriteLine("Which actors are in the movie? ");
                        i = -1;
                    }
                    else
                    {
                        actorList[editIndex] = input;
                        i--;
                    }
                }
                else
                {
                    actorList.Add(input);
                }
            }
            movies.Add(new Movie(title, releaseYear, director, actorList));
            Console.WriteLine("\nMovie added successfully!\n");
            Menu(movies);
        }
        public static int AskForNumber(string question)
        {
            int output;
            while (true)
            {
                Console.Write(question);
                string releaseYearInput = Console.ReadLine();
                bool result = Int32.TryParse(releaseYearInput, out output);
                if (result) break;
                Console.WriteLine("Invalid input! Numbers only please.\n");
            }
            return output;
        }
        public static int AskForNumber(string question, int minNumber, int maxNumber)
        {
            int output;
            while (true)
            {
                Console.Write(question);
                string releaseYearInput = Console.ReadLine();
                bool result = Int32.TryParse(releaseYearInput, out output);
                if (result && output >= minNumber && output <= maxNumber) break;
                Console.WriteLine($"Invalid input! Numbers only, between {minNumber} and {maxNumber} please.\n");
            }
            return output;
        }
        public static void Menu(List<Movie> movies)
        {
            int selected = AskForNumber("Input 1 to list all movies, 2 to add a new movie: ", 1, 2);
            Console.WriteLine();
            if (selected == 1)
            {
                ShowAllMovies(movies);
            }
            else if (selected == 2)
            {
                CreateNewMovie(movies);
            }
        }
        public static void ShowAllMovies(List<Movie> movies)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine();
                movies[i].ShowInfo();
                Console.WriteLine();
            }
            Console.WriteLine();
            Menu(movies);
        }
    }
}

/*
 * 
 *  Tittel
 *  År
 *  Forfatter/Director
 *  Skuespillere
 * 
 */