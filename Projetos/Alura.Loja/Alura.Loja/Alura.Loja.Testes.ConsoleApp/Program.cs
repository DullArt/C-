using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // using(var contexto = new LojaContext())
            // {
            //     var produtos = contexto.Produtos.ToList();
            //     foreach(var p in produtos)
            //     {
            //         Console.WriteLine(p);
            //     }


            //     ExibeEntries(contexto.ChangeTracker.Entries());
            //     contexto.Entry(produtos);
            // }

           using(var contexto = new LojaContext())
           {   
               var cliente = contexto.Clientes
               .Include(c => c.EnderecoDeEntrega)
               .FirstOrDefault();

               Console.WriteLine(""+cliente.EnderecoDeEntrega.Logradouro);
               var produto = contexto
               .Produtos
               .Where(p => p.Id == 9004)
               .FirstOrDefault();

               foreach(var item in produtos.Compras)
               {
                   Console.WriteLine(item);
               }

               contexto.Entry(produto)
               .Collection(produto=>produto.Compras)
               .Where(c => c.Preco>10)
               .Load();               
           }
           
        }

        private static void ExibeProdutoPromocao()
        {
             using(var contexto2 = new LojaContext())
            {
                
                var promocao = contexto2.Promocoes
                .Include(p => p.Produtos)
                .ThenInclude(pp => pp.Produto)
                .FirstOrDefault();
                    
                foreach(var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluirPromocao()
        {
             using(var contexto = new LojaContext())
            {
                var promocao = new Promocao();
                promocao.Descricao = "Queima total Janeiro 2017";
                promocao.DataInicio = new DateTime(2017,1,1);
                promocao.DataTermino = new DateTime(2017,1,31);

                var produto = contexto.
                Produtos.
                Where(p => p.Categoria == "Bebidas")
                .ToList();

                foreach(var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.SaveChanges();

            }
        }
        
        private static void UmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua 9",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using(var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
        {
            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao  = "Promoção de Pascoa";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);
            promocaoDePascoa.IncluiProduto(new Produto());
            promocaoDePascoa.IncluiProduto(new Produto());
            promocaoDePascoa.IncluiProduto(new Produto());

            
            using(var contexto = new  LojaContext())
            {
                contexto.Promocoes.Add(promocaoDePascoa);
                contexto.SaveChanges();
            }


        }


        public static void UmParaMuitos()
        {
            
            var paoFrances = new Produto();
            paoFrances.Nome = "Pão frances";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;
            
            using(var contexto = new LojaContext())
            {
                contexto.Compras.Add(compra);
                contexto.SaveChanges();
            }

        }

        private static void ExibeEntries(IEnumberable<EntityEntry> entries)
        {
            //Modified, unchangeed, add, Deleted, Detached
            foreach(var e in entries)
            {
                    Console.WriteLine(e.Entity.ToString()+" - "+e.State);
            }

        }

        private static void AtualizarProduto()
        {
            using(var repo = new LojaContext())
            {
                Produto primeiro = repo.Produto.First();
                primeiro.Nome = "Cassioo Royale - Editado";
                // repo.Produtos.Update(primeiro);
                // repo.SaveChanges();
                repo.Atualizar(primeiro); 
            }   

            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                foreach(var item in produtos)
                {
                    repo.Remove(item);
                }    
            }  
        }
        private static void RecuperarProdutos()
        {
            using(var repo = new ProdutoDAOEntity())
            {
                
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine("Foram encontrados {0}", produtos.Count);
                foreach (var item in produtos)
                {
                   Console.WriteLine(item.Nome); 
                }
            }
        }
        
        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new ProdutoDAOEntity())
            {
                //contexto.Produtos.AddRange(p); //adiciona muitos 
                contexto.Adicionar(p);

            }
        }
        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
