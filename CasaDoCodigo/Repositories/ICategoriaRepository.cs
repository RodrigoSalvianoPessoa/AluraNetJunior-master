using System.Threading.Tasks;
using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task Save(string nome);
        Task<Categoria> GetCategoria(string nome);
    }
}