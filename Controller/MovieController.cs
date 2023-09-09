using MovieClassLibrary;
using MovieClassLibrary.Model;
using MovieClassLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieClassLibrary.Exceptions;

namespace FinalMovieApp.Controller
{
    internal class MovieController
    {
        public MovieController()
        {
            MainMenu();
        }
        private static void MainMenu()
        {
            Console.WriteLine(" --------- Welcome to Movie app --------- ");
            while (true)
            {
                new MovieManager();
                Console.WriteLine("1.Display all movies.\n" +
                    "2.Display movie by year.\n" +
                    "3.Add movie.\n" +
                    "4.Remove movie.\n" +
                    "5.Clear all.\n" +
                    "6.SaveAsfile\n" +
                    "7.Exit.");
                Console.WriteLine($"Movies in list {MovieManager.GetMovieCount}/5");
                Console.WriteLine("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            List<Movie> allMovies = MovieManager.GetAllMovieDetails();
                            Console.WriteLine("======== Movies ========");
                            foreach (var item in allMovies)
                            {
                                Console.WriteLine(item.ToString());
                            }

                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Enter year: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            List<Movie> moviesByYear = MovieManager.GetMoviesByYear(year);
                            if (moviesByYear.Count > 0)
                            {
                                Console.WriteLine($"======== Movies for Year {year} ========");
                                foreach (var item in moviesByYear)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case "3":
                        try
                        {
                            Movie newMovie = CreateMovie();
                            MovieManager.AddMovieDetails(newMovie);
                            Console.WriteLine("Movie added successfully.");
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("Enter movie name: ");
                            MovieManager.RemoveMovie();
                            Console.WriteLine("Movie removed from the list.");
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case "5":
                        try
                        {
                            MovieManager.RemoveAll();
                            Console.WriteLine("All movies are cleared.");
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;
                    case "6":
                        MovieManager.SaveAsFile();
                        Console.WriteLine("Movies saved to file.");
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        public static void GetAllMovieDetails(Movie movie)
        {
            Console.WriteLine("Enter movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter movie name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter movie genre: ");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter movie year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            MovieManager.AddMovies(id, name, genre, year);
        }
        private static Movie CreateMovie()
        {
            Console.WriteLine("Enter movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter movie name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter movie genre: ");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter movie year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Movie newMovie = new Movie(id, name, genre, year);
            return newMovie;
        }
    }
}
