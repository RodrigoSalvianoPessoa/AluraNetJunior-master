using CasaDoCodigo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task Save(string nome)
        {
            var categoriaDB = contexto.Set<Categoria>().Where(c => c.Nome == nome).SingleOrDefault();

            if (categoriaDB == null)
            {
                categoriaDB = new Categoria(nome);
                contexto.Set<Categoria>().Add(categoriaDB);

                await contexto.SaveChangesAsync();
            }
        }

        public Categoria GetCategoria(int categoriaId)
        {
            return contexto.Set<Categoria>().Where(c => c.Id == categoriaId).SingleOrDefault();
        }
    }
}
