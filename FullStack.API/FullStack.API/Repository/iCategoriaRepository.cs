using FullStack.API.Model;

namespace FullStack.API.Repository
{
    public interface ICategoriaRepository {
        IEnumerable<Categoria> ObterTodos();
        Categoria ObterPorId(int id);
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Deletar(int id);
    }

    
}
