using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";
                var registros = contexto.Database.ExecuteSqlCommand(sql);
                Console.WriteLine($"O total de registros afetados é {registros}.");

                var deleteSql = "DELETE FROM language WHERE name LIKE 'Teste%'";
                registros = contexto.Database.ExecuteSqlCommand(deleteSql);
                Console.WriteLine($"O total de registros afetados é {registros}.");

            }
        }

        static void StoredProcedure(DbContext contexto)
        {
            var categ = "Action"; //36

            var paramCateg = new SqlParameter("category_name", categ);

            var paramTotal = new SqlParameter
            {
                ParameterName = "@total_actors",
                Size = 4,
                Direction = System.Data.ParameterDirection.Output
            };

            contexto.Database
                .ExecuteSqlCommand(
                  "total_actors_from_given_category @category_name, @total_actors OUT",
                  paramCateg,
                  paramTotal);

            Console.WriteLine($"O total de atores na categoria {categ} é de {paramTotal.Value}.");

        }

        private static void Details()
        {
            // using(var contexto = new AluraFilmesContexto)
            // {
            //     var ator = new Ator();
            //     ator.PrimeiroNome = "Tom";
            //     ator.Ultimonome = "Hanks";
            //     contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;
                
            //     contexto.Atores.Add(ator);
            //     contexto.SaveChanges();
                
            //     var atores = contexto.Atores.
            //     OrderByDescending(a => EF.Property<DateTime>(a, "last_update")).Take(10);
            // }

            //******************************* */
                // using(var contexto = new AluraFilmesContexto())
                // {
                //     var filme = contexto.Filmes
                //     .Include(f => f.Atores)
                //     .ThenInclude(fa => fa.Ator)
                //     .First();
                    
                //     Console.WriteLine(filme);

                //     foreach(var item in contexto.Elenco)
                //     {
                //         var entidade = contexto.Entry(item);
                //         var filmId = entidade.Property("film_id").CurrentValue;
                //         var actorId = entidade.Property("actor_id").CurrentValue;
                //         var lastUp = entidade.Property("last_update").CurrentValue;


                //     }
                // }

        }
    }
}
