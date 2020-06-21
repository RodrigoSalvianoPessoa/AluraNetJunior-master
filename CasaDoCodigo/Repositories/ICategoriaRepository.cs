using System.Threading.Tasks;
using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task Save(string nome);
        Categoria GetCategoria(int categoriaId);
    }
}