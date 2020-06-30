using System.Collections.Generic;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public int Id { get; }

        public string NomeCategoria { get; }

        public List<Produto> Produtos { get; }
    }
}
