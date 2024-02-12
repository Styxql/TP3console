using Microsoft.EntityFrameworkCore;
using TP3console.Models.EntityFramework;

namespace TP3console
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Exo2Q4();
            Console.ReadKey();
        }
        public static void Exo2Q1()
        {
            var ctx = new FilmsDbContext();
            foreach (var film in ctx.Films)
            {
                Console.WriteLine(film.ToString());
            }
        }
        //Autre possibilité :
        public static void Exo2Q1Bis()
        {
            var ctx = new FilmsDbContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les 
            var films = ctx.Films.FromSqlRaw("SELECT * FROM film");
            foreach (var film in films)
            {
                Console.WriteLine(film.ToString());
            }
        }

        public static void Exo2Q2()
        {
            var ctx = new FilmsDbContext();
            foreach (var email in ctx.Utilisateurs)
            {
                Console.WriteLine(email.Email.ToString());
            }

        }

        public static void Exo2Q3()
        {
            var ctx = new FilmsDbContext();
            var utilisateurs = ctx.Utilisateurs.OrderBy(u => u.Login);

            foreach (var utilisateur in utilisateurs)
            {
                Console.WriteLine(utilisateur.Login);
            }


        }

        public static void Exo2Q4()
        {
            var ctx = new FilmsDbContext();
            Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
            ctx.Entry(categorieAction).Collection(c=>c.Films).Load();
            foreach(var film in categorieAction.Films)
            {
                Console.WriteLine(film.Id+" : "+film.Nom);
            }
        }


    }
}