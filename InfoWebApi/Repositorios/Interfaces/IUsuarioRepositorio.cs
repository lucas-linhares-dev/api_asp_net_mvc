using InfoWebApi.Models;

namespace InfoWebApi.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> InsertUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario, int id);
        Task<bool> DeleteUsuario(int id);
    }
}
