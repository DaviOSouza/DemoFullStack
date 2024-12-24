using FullStack.API.Model;

namespace FullStack.API.Repository
{
    public interface IProdutoRepository {
        IEnumerable<Produto> ObterTodos();
        IEnumerable<Produto> ObterPaginados(int pageSize, int pageNumber, string nome = null);
        Produto ObterPorId(int id);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(int id);
    }
}
