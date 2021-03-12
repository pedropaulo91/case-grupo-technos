using System.Collections.Generic;
using System.Threading.Tasks;
using Case_Grupo_Technos.Models;
using Case_Grupo_Technos.Repositories;

namespace Case_Grupo_Technos.Services
{
    public interface IProdutoService
    {
        Task AtualizarProduto(int id, Produto produto);
        Task CadastrarProduto(Produto produto);
        Task DeletarProduto(Produto produto);
        Task<Produto> ObterProdutoPeloId(int id);
        Task<List<Produto>> ObterProdutos();
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Produto>> ObterProdutos()
        {
            return await _repository.ObterProdutos();
        }

        public async Task<Produto> ObterProdutoPeloId(int id)
        {
            return await _repository.ObterProdutoPeloId(id);
        }

        public async Task CadastrarProduto(Produto produto)
        {
            await _repository.CadastrarProduto(produto);
        }

        public async Task AtualizarProduto(int id, Produto produto)
        {
            await _repository.AtualizarProduto(id, produto);
        }

        public async Task DeletarProduto(Produto produto)
        {
            await _repository.DeletarProduto(produto);
        }

    }
}