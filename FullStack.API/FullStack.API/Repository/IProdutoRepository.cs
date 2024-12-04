using FullStack.API.Model;

namespace FullStack.API.Repository
{
    public interface IProdutoRepository {
        IEnumerable<Produto> ObterTodos();
        Produto ObterPorId(int id);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(int id);
    }
}
