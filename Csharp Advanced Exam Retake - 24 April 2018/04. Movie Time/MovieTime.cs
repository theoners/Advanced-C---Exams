namespace _04._Movie_Time
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public TimeSpan Time { get; set; }

    }
    public class MovieTime
    {
        public static void Main()
        {
            var movies = new List<Movie>();
            string genre = Console.ReadLine();
            string duration = Console.ReadLine();
            var totalTime = new TimeSpan();
            while (true)
            {
                var input = Console.ReadLine();
                if (input== "POPCORN!")
                {
                    break;
                }

                var movie = input.Split('|');
                var movieName = movie[0].Trim();
                var movieGenre = movie[1].Trim();
                var movieDuration = movie[2].Split(':').Select(int.Parse).ToArray();
                TimeSpan time = new TimeSpan(movieDuration[0],movieDuration[1],movieDuration[2]);
                totalTime += time;
                var currentMovie = new Movie()
                {
                    Name = movieName,
                    Genre = movieGenre,
                    Time = time
                };
                movies.Add(currentMovie);
            }

            if (duration=="Short")
            {
                foreach (var movie in movies.OrderBy(x=>x.Time))
                {
                    if (genre==movie.Genre)
                    {
                        Console.WriteLine(movie.Name);
                        var answer = Console.ReadLine();
                        if (answer == "Yes")
                        {
                            Console.WriteLine($"We're watching {movie.Name} - {movie.Time}");
                            Console.WriteLine($"Total Playlist Duration: {totalTime}");
                            return;
                        }
                    }
                }
            }
            else
            {
                foreach (var movie in movies.OrderByDescending(x => x.Time))
                {
                    if (genre == movie.Genre)
                    {
                        Console.WriteLine(movie.Name);
                        var answer = Console.ReadLine();
                        if (answer == "Yes")
                        {
                            Console.WriteLine($"We're watching {movie.Name} - {movie.Time}");
                            Console.WriteLine($"Total Playlist Duration: {totalTime}");
                            return;
                        }
                    }
                }
            }
        }
    }
}
