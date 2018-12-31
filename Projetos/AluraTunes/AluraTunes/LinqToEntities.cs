
using System;

class LinqToEntities
{
    public static void LinqEntities()
    {
                using(var contexto = new AluraTunesEntities())
                {
                    var query = from g in contexto.Generos 
                                select g;
                    foreach(var genero in query)
                    {
                        Console.WriteLine(genero.GeneroId+genero.Nome);
                    }
                    
                    var faixaEgenero = from g in contexto.Generos
                                    join f in contexto.Faixas
                                    on g.GeneroId equals f.GeneroId
                                    select new {f,g};

                    faixaEgenero = faixaEgenero.Take(10);
                    
                    contexto.Database.Log = Console.WriteLine();

                    foreach(var item in faixaEgenero)
                    {
                        Console.WriteLine(item.f.Nome+item.g.Nome);
                    } 
                }


    }


    public void Busca()
    {
        using(var contexto = new AluraTunesEntities())
        {
            var textoBusca = "Led";
            var query = from a in contexto.Artitas
                        join alb in contexto.Albums
                        on a.ArtistaId equals alb.ArtistaId 
                        where a.Nome.Contains(textoBusca)
                        select new
                        {
                            NomeArtista = a.Nome,
                            NomeAlbum = alb.Titulo
                         };

            foreach(var item in query)
            {
                System.Console.WriteLine(item.NomeArtista+item.NomeAlbum);
            }

            var query2 = contexto.Artistas.Where(a => a.Nome.Contains(textoBusca));
            Console.WriteLine();

            foreach(var artista in query2)
            {
                Console.WriteLine(artista.ArtistaId+artista.Nome);
            }

            //Propriedade de navegação
            var query3 = from alb in contexto.Albums
                         where alb.Artista.Nome.Contains(textoBusca)
                        select alb;
            
        }
    }

        public static void GetFaixas(AluraTunesEntities contexto, string buscaArtista, string buscaAlbum)
        {
            var query = from f in contexto.Faixas
             where f.Album.Nome.Contains(buscaArtista)
             && (!string.IsNullOrEmpty(buscaAlbum) ? f.Album.Titulo.Contains(buscaAlbum) : true)
             orderby f.Album.Titulo , f.Nome
             select f;

            // if(!string.IsNullOrEmpty(buscaAlbum))
            // {
            //     query = query.Where(q => q.Album.Titulo.Contains(buscaAlbum));
            // }

            //query = query.OrderBy(q => q.Album.Titulo).ThenBy(q => q.Nome);

            foreach(var faixa in query)
            {
                Console.WriteLine("{0}\t{1}", faixa.Album.Titulo, faixa.Nome);
            }
        }

        public static void Conta(AluraTunesEntities contexto)
        {
             var query = from f in contexto.Faixas
               where f.Album.Artista.Nome == "Led Zeppelin"
               select f;
               
            //    var quantidade = query.Count();
            //    Console.WriteLine("Led Zeppelin {0}", quantidade);

               var quantidade = contexto.Faixas
               .Count(f => f.Album.Artista.Nome == "Led Zeppelin");
               
               Console.WriteLine("Quantidade {0}", quantidade); 
               Console.ReadKey();
        }

        public static void Sum(AluraTunesEntities contexto)
        {
            var query = from inf in contexto.ItemsNotaFiscal 
              where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
              select new {totalDoItem = inf.Quantidade*inf.PrecoUnitario};

              var totalDoArtista = query.Sum(q => q.totalDoItem);
              Console.WriteLine("Total do artista R$ {0}", totalDoArtista);
              Console.ReadKey();
        }

        public static void GroupBy()
        {
            using(var contexto = new AluraTunesEntities())
            {           
              var query = from inf in contexto.ItemsNotaFiscal
              where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
              group inf by inf.Faixa.Album into agrupado
              let vendasPorAlbum = agrupado.Sum(a => a.Quantidade * a.PrecoUnitario) 
              orderby vendasPorAlbum
              descending              
              select new
              {
                  TituloDoAlbum = agrupado.Key.Titulo,
                //   TotalPorAlbum = agrupado.Sum(a=>a.Quantidade *a.PrecoUnitario)
                TotalPorAlbum = vendasPorAlbum
              };

              foreach(var agrupado in query)
              {
                  Console.WriteLine("{0}\t{1}", agrupado.TituloDoAlbum.PadRight(40),agrupado.TotalPorAlbum);
              }

            }
        }

        public static void MinMaxMedia(AluraTunesEntities contexto)
        {
              //scripts de database 
              contexto.Database.Log = Console.WriteLine;
              var maiorVenda = contexto.NotasFiscais.Max(nf=> nf.Total);
              var menorVenda = contexto.NotasFiscais.Min(nf=> nf.Total);
              var vendaMedia = contexto.NotasFiscais.Average(nf=> nf.Total);

            Console.WriteLine($"A maior venda é de {maiorVenda}");
            Console.WriteLine($"A menor venda é dde R${menorVenda}");
            Console.WriteLine("A venda média é de R$ {vendaMedia}");

            var vendas = from nf in contexto.NotasFiscais
            group nf by 1 into agrupado
            select new 
            {
                maiorVenda = agrupado.Max(nf => nf.Total),
                menoVenda = agrupado.Min(nf => nf.Total),
                vendaMluraedia = agrupado.Average(nf =>nf.Total)
            };

                Console.WriteLine($"A maior venda é de R$ {vendas.maiorVenda}");
                Console.WriteLine($"A menor venda é de R$ {vendas.menorVenda}");
                Console.WriteLine($"A venda média é de R$ {vendas.vendaMedia}");

        }
}