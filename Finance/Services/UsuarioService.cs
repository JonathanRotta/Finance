using Finance.DTOs;
using Finance.Models;
using Finance.Repositories;

namespace Finance.Services
{
    public class UsuarioService 
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuarios()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario> CriarUsuario(CreateUsuarioDTO request)
        {

            var usuario = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
            };
            
            await _repository.AddAsync(usuario);
            return usuario;
        }

        public async Task AlterarUsuario(int id, CreateUsuarioDTO request)
        {
            var usuarioExistente = await _repository.GetByIdAsync(id);

            if(usuarioExistente != null)
            {
                usuarioExistente.Nome = request.Nome;
                usuarioExistente.Email = request.Email;
                usuarioExistente.Senha = request.Senha;
            }

            await _repository.UpdateAsync(usuarioExistente);

        }

        public async Task RemoverUsuario(int id)
        {

            await _repository.DeleteAsync(id);

        }

        public async Task<Usuario?> ValidarLogin(LoginDTO login)
        {
            var usuario = await _repository.GetByEmailAsync(login.Email);

            if (usuario == null) return null;

            if (usuario.Senha != login.Senha) return null;

            return usuario;
        }


    }
}
