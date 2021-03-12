using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case_Grupo_Technos.Data;
using Case_Grupo_Technos.Models;
using Microsoft.EntityFrameworkCore;

namespace Case_Grupo_Technos.Repositories
{
    public interface IProdutoRepository
    {
        Task AtualizarProduto(int id, Produto produto);
        Task CadastrarProduto(Produto produto);
        Task DeletarProduto(Produto produto);
        Task<Produto> ObterProdutoPeloId(int id);
        Task<List<Produto>> ObterProdutos();
    }

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> ObterProdutos()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterProdutoPeloId(int id)
        {
            return await _context.Produtos.AsNoTracking().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CadastrarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarProduto(int id, Produto produto)
        {
            _context.Entry<Produto>(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

    }

}