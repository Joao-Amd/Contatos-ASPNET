using ControladorContatos.Models;

namespace ControladorContatos.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adcionar(UsuarioModel contato);
        bool Apagar(int id);
        UsuarioModel Atualizar(UsuarioModel contato);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ListarPorId(int id);
    }
}