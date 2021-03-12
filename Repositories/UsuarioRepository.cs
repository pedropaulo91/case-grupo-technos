using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Case_Grupo_Technos.Data;
using Case_Grupo_Technos.Helpers;
using Case_Grupo_Technos.Models;
using Microsoft.EntityFrameworkCore;

namespace Case_Grupo_Technos.Repositories
{
    public interface IUsuarioRepository
    {
        Task AtualizarUsuario(Usuario usuario);
        Task<Usuario> AutenticarUsuario(Usuario usuario);
        Task CadastrarUsuario(Usuario usuario);
        Task DeletarUsuario(Usuario usuario);
        Task<Usuario> ObterUsuarioPeloId(int id);
        Task<Usuario> ObterUsuarioPeloNome(string nomeUsuario);
        Task<List<Usuario>> ObterUsuarios();
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;
        private readonly Hash hash = new Hash(SHA512.Create());

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AutenticarUsuario(Usuario usuario)
        {

            var senhaCriptografada = hash.CriptografarSenha(usuario.Senha);

            var user = await _context.Usuarios
                .AsNoTracking()
                .Where(u => u.NomeUsuario.ToUpper() == usuario.NomeUsuario.ToUpper() &&
                    u.Senha.ToUpper() == senhaCriptografada.ToUpper())
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPeloId(int id)
        {
            return await _context.Usuarios.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterUsuarioPeloNome(string nomeUsuario)
        {
            return await _context.Usuarios.AsNoTracking().Where(u => u.NomeUsuario.ToUpper() == nomeUsuario.ToUpper()).FirstOrDefaultAsync();
        }

        public async Task CadastrarUsuario(Usuario usuario)
        {
            var senhaCriptografada = hash.CriptografarSenha(usuario.Senha);

            usuario.Senha = senhaCriptografada;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _context.Entry<Usuario>(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

    }
}