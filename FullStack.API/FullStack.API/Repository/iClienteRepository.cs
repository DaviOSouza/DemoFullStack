using FullStack.API.Model;

namespace FullStack.API.Repository
{
    public interface iClienteRepository
    {
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorId(int id);
        void Adicionar(Cliente produto);
        void Atualizar(Cliente produto);
        void Deletar(int id);
    }
}
