using InfoWebApi.Data;
using InfoWebApi.Models;
using InfoWebApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfoWebApi.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {   
        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<Usuario> GetUsuario(int id)
        {
            Usuario usuarioEncontraodo = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id) ?? new Usuario();

            if(usuarioEncontraodo == null)
            {
                throw new Exception($"Usuario de ID: {id} não foi encontrado.");
            }
      
            return usuarioEncontraodo;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();

        }


        public async Task<Usuario> InsertUsuario(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;

        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario, int id)
        {
            Usuario usuarioUpdate = await GetUsuario(id);
            if(usuarioUpdate == null)
            {
                throw new Exception($"Usuario de ID: {id} não foi encontrado.");
            }

            usuarioUpdate.Nome = usuario.Nome;
            usuarioUpdate.Email = usuario.Email;

           _dbContext.Usuarios.Update(usuarioUpdate); // ENTENDER A DIFERENÇA DE UPDATE PARA EXECUTE UPDATE ASYNC
           await _dbContext.SaveChangesAsync();

            return usuarioUpdate;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            Usuario UsuarioDelete = await GetUsuario(id);

            if(UsuarioDelete == null)
            {
                throw new Exception($"Usuario de ID: {id} não foi encontrado.");
            }

            _dbContext.Usuarios.Remove(UsuarioDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
