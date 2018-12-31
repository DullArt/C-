using System;
using System.Collections.Generic;
using System.Linq;

namespace AluraTunes
{
    class  LinqToObject 
    {
        static void Principal()
        {
            var generos = new List<Genero>
            {
                new Genero{Id = 1, Nome = "Rock"},
                new Genero{Id = 2, Nome = "Reggae"},
                new Genero{Id = 3, Nome = "Rock Progressivo"},
                new Genero{Id = 4, Nome = "Punk Rock"},
                new Genero{Id = 5, Nome = "Clássica"}
            };

            foreach(var genero in generos)
            {
                Console.WriteLine("{0} \t {1}",genero.Id ,genero.Nome);               
            }

            //select * from generos
            var query = from g in generos where g.Nome.Contains("Rock") select g;

            //Linq - Language Integrated Query - Consulta integrada à linguagem

                Console.ReadKey();

            var musicas = new List<Musica>
            {
                new Musica {Id = 1, Nome = "Sweet chil O'Mine", GeneroId = 1},
                new Musica {Id = 2, Nome = "I shot the sheriff", GeneroId = 2},
                new Musica {Id = 3, Nome = "Danúbio Azul", GeneroId = 3}
            }; 

            var musicaQuery = from m in musicas
                              join g in generos 
                              on m.GeneroId equals g.Id  
                              select new {m,g};
                               

            foreach(var musica in musicaQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id ,musica.m.Nome, musica.m.GeneroId);
                Console.WriteLine(musica.g.Nome);
            }
        }
    

        class Genero
        {
            public int Id { get; set; }
            public string Nome { get; set; }

        }

        class Musica 
        {
            public int Id {get;set;}
            public string Nome {get;set;}
            public int GeneroId { get; set; }


        }
    }
}            
