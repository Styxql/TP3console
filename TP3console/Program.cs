using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using TP3console.Models.EntityFramework;

namespace TP3console
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Exo3Q3();
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

        public static void Exo2Q5()
        {
            var ctx = new FilmsDbContext();
            Console.WriteLine("Nombre de catégorie "+ctx.Categories.Count());
        }

        public static void Exo2Q6()
        {
            var ctx = new FilmsDbContext();
            var avisplusbas = ctx.Avis.OrderByDescending(u => u.Note).FirstOrDefault();
            Console.WriteLine(avisplusbas.Note);
        }

        public static void Exo2Q7()
        {
            var ctx = new FilmsDbContext();
            var allFilms = ctx.Films.ToList(); 

            var filmsLe = allFilms.Where(f => f.Nom.StartsWith("le", StringComparison.InvariantCultureIgnoreCase));

            foreach (var film in filmsLe)
            {
                Console.WriteLine(film.Nom);
            }
        }

        public static void Exo2Q8()
        {
            var ctx = new FilmsDbContext();
            Film pulpFiction = ctx.Films.FirstOrDefault(c => c.Nom == "Pulp fiction");
            var avis = ctx.Avis.Where(a => a.FilmNavigation.Id == pulpFiction.Id).ToList();
           var noteMoyenne=avis.Average(a => a.Note);
            Console.WriteLine(pulpFiction.Nom+"Note Moyenne : "+noteMoyenne);

        }
        public static void Exo3()
        {
            var ctx =new FilmsDbContext();
            var nouvelUtilisateur = new Utilisateur
            {
                Login = "lavalq",
                Email = "lavalq@email.com",
                Pwd = "qdqzdqzdqgrthr"
            };

            ctx.Utilisateurs.Add(nouvelUtilisateur);
            ctx.SaveChanges();
        }

        public static void Exo3Q2()
        {
            var ctx =new FilmsDbContext();
            Film armeeDes = ctx.Films.FirstOrDefault(c => c.Nom == "L'armee des douze singes");
            armeeDes.Description = "Salut";
            armeeDes.Categorie = 5;
            Console.WriteLine(armeeDes);
        }

        public static void Exo3Q3()
        {
            var ctx = new FilmsDbContext();

            Film armeeDes = ctx.Films.FirstOrDefault(c => c.Nom == "L'armee des douze singes");

            if (armeeDes != null)
            {
                var avisArmee = ctx.Avis.Where(a => a.Film == armeeDes.Id).ToList();
                ctx.Avis.RemoveRange(avisArmee);

                ctx.Films.Remove(armeeDes);

                ctx.SaveChanges();

                Console.WriteLine("Film 'L'armée des douze singes' et ses avis associés ont été supprimés avec succès !");
            }
            else
            {
                Console.WriteLine("Film 'L'armée des douze singes' non trouvé.");
            }
        }


        public static void Exo3Q4()
        {
            var ctx=new FilmsDbContext();
            Film seven = ctx.Films.FirstOrDefault(c => c.Nom == "Seven");

            if(seven != null)

            {
                Avi avis = new Avi()
                {
                    Note = 10;
                  
                };
                seven.Avis.Add();
            }
            
        }

    }
}