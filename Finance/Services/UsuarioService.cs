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
    }
}
