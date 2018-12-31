using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao {get;set;}
        public DateTime DataInicio {get;set;}
        public DateTime DataTermino {get;set;}
        public IList<PromocaoProduto> Produtos { get; set;}


        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }

        public void IncluiProduto(Produto p)
        {
            this.Produtos.Add(new PromocaoProduto(){ Produto = produto});
        }
        
    }
}
