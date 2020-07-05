using System.Collections.Generic;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public BuscaDeProdutosViewModel(IList<Produto> produtos)
        {
            Produtos = produtos;
        }

        public string Nome { get; set; }

        public IList<Produto> Produtos { get; }
    }
}
