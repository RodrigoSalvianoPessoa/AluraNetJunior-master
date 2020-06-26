using System.Collections.Generic;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public BuscaDeProdutosViewModel(IList<Produto> produtos, IList<Categoria> categorias)
        {
            Produtos = produtos;
            Categorias = categorias;
        }

        public IList<Produto> Produtos { get; }

        public IList<Categoria> Categorias { get; }
    }
}
