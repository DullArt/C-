using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public interface IProdutoDAO
    {
        void Adicionar(Produto p);
        void Atualizar(Produto p);
        void Remove(Produto p);
        IList<Produto> Produtos();   
    }
}
