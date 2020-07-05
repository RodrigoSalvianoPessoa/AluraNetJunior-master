using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IList<Produto>> GetProdutos()
        {
            var listaProdutos = contexto.Set<Produto>()
                .Include(c => c.Categoria)
                .ThenInclude(c => c.Produtos)
                .ToListAsync();
            
            return await listaProdutos;
        }

        public async Task<IList<Produto>> GetProdutos(string nome)
        {
            IQueryable<Produto> consulta = dbSet.Include(p => p.Categoria);

            if (!string.IsNullOrWhiteSpace(nome))
            {
                consulta = consulta.Where(p => p.Nome.Contains(nome) || p.Categoria.Nome.Contains(nome));
            }

            return consulta.ToList();
        }

        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!String.IsNullOrEmpty(livro.Categoria))
                {
                    await _categoriaRepository.Save(livro.Categoria);
                }
                
                var categoria = await _categoriaRepository.GetCategoria(livro.Categoria);

                if (!dbSet.Any(p => p.Codigo == livro.Codigo))
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
