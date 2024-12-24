using FullStack.API.Model;

namespace FullStack.API.Repository
{
    public interface ICategoriaRepository {
        IEnumerable<Categoria> ObterTodos();
        IEnumerable<Categoria> ObterPaginados(int pageSize, int pageNumber, string nome = null);
        Categoria ObterPorId(int id);
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Deletar(int id);
    }

    
}
