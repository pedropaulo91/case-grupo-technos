using System.Collections.Generic;
using System.Threading.Tasks;
using Case_Grupo_Technos.Models;
using Case_Grupo_Technos.Repositories;

namespace Case_Grupo_Technos.Services
{
    public interface IUsuarioService
    {
        Task AtualizarUsuario(Usuario usuario);
        Task<Usuario> AutenticarUsuario(Usuario usuario);
        Task CadastrarUsuario(Usuario usuario);
        Task DeletarUsuario(Usuario usuario);
        Task<Usuario> ObterUsuarioPeloId(int id);
        Task<Usuario> ObterUsuarioPeloNome(string nomeUsuario);
        Task<List<Usuario>> ObterUsuarios();
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> AutenticarUsuario(Usuario usuario)
        {
            return await _repository.AutenticarUsuario(usuario);
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            return await _repository.ObterUsuarios();
        }

        public async Task<Usuario> ObterUsuarioPeloId(int id)
        {
            return await _repository.ObterUsuarioPeloId(id);
        }

        public async Task<Usuario> ObterUsuarioPeloNome(string nomeUsuario)
        {
            return await _repository.ObterUsuarioPeloNome(nomeUsuario);
        }

        public async Task CadastrarUsuario(Usuario usuario)
        {
            await _repository.CadastrarUsuario(usuario);
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            await _repository.AtualizarUsuario(usuario);
        }

        public async Task DeletarUsuario(Usuario usuario)
        {
            await _repository.DeletarUsuario(usuario);
        }

    }
}