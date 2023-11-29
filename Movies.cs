namespace ParprogrammeringUke3
{
    internal class Movie
    {
        private string _title;
        private int _releaseYear;
        private string _director;
        private List<string> _actors;

        public Movie(string title, int releaseYear, string director, List<string> actors)
        {
            _title = title;
            _releaseYear = releaseYear;
            _director = director;
            _actors = actors;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Release year: {_releaseYear}");
            Console.WriteLine($"Directed by: {_director}");
            Console.Write("Actors:");
            for (int i = 0; i < _actors.Count; i++)
            {
                if (i < _actors.Count - 1)
                {
                    Console.Write($" {_actors[i]},");
                }
                else
                {
                    Console.Write($" {_actors[i]}.");
                }
            }
        }
    }
}
