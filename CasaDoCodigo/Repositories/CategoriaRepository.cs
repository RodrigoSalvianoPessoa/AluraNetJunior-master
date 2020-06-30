using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task Save(string nome)
        {
            var categoriaDB = contexto.Set<Categoria>().SingleOrDefault(c => c.Nome == nome);

            if (categoriaDB == null)
            {
                categoriaDB = new Categoria(nome);
                contexto.Set<Categoria>().Add(categoriaDB);

                await contexto.SaveChangesAsync();
            }
        }

        public async Task<Categoria> GetCategoria(string nome)
        {
            return contexto.Set<Categoria>().SingleOrDefault(c => c.Nome == nome);
        }

        public List<Categoria> GetCategorias()
        {
            return dbSet.Include(c => c.Produtos)
                .ThenInclude(p => p.Categoria)
                .ToList();
        }
    }
}
