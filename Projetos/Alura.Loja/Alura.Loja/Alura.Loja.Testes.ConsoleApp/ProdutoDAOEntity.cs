using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class ProdutoDAOEntity : IProdutoDAO, IDisposable
    {
        private LojaContext contexto;        
        
        public ProdutoDAOEntity()
        {
            this.contexto = new LojaContext();
        }

        public IList<Produto> Produtos()
        {
            return contexto.Produtos.ToList();
        }

        public void Adicionar(Produto p)
        {
            contexto.Produtos.Add(p);
            contexto.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            contexto.Produtos.Update(produto);
            contexto.SaveChanges();
        }

        public void Remove(Produto p)
        {
            IList<Produto> produtos = contexto.Produtos.ToList();
            foreach(var produto in produtos)
            {
                contexto.Produtos.Remove(produto);
            }
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

    }
}
