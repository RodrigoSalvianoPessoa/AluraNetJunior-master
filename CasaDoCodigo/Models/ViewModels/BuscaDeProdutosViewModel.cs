using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public BuscaDeProdutosViewModel(IEnumerable<Produto> produtos, IEnumerable<Categoria> categorias)
        {
            Produtos = produtos;
            Categorias = categorias;

            foreach (var produto in produtos)
            {
                NomeCategoria = categorias.Where(c => c.Id == produto.Categoria.Id).SingleOrDefault().Nome;
            }
        }

        public IEnumerable<Produto> Produtos { get; }

        public IEnumerable<Categoria> Categorias { get; }

        public string NomeCategoria { get; }
    }
}
