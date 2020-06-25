﻿using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        Task SaveProdutos(List<Livro> livros);
        List<Produto> GetProdutos();
        List<Produto> GetProdutosCategoria();
    }
}