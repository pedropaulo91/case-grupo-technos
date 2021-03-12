using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Case_Grupo_Technos.Models;
using Case_Grupo_Technos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Case_Grupo_Technos.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<Produto>>> ObterProdutos()
        {
            try
            {
                var produtos = await _service.ObterProdutos();
                return Ok(produtos);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível encontrar os produtos" });
            }

        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult> ObterProdutoPeloId(int id)
        {
            try
            {
                var produto = await _service.ObterProdutoPeloId(id);
                if (produto == null)
                    return BadRequest(new { message = "Produto não encontrado" });

                return Ok(produto);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível encontrar o produto");
            }
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<Produto>>> CadastrarProduto([FromBody] Produto produto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.CadastrarProduto(produto);
                return Ok(produto);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível cadastrar o produto" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult> AtualizarProduto(int id, [FromBody] Produto produto)
        {
            var prod = await _service.ObterProdutoPeloId(id);
            if (prod == null)
                return BadRequest(new { message = "Produto não encontrado" });

            if (!ModelState.IsValid)
                return BadRequest(produto);

            try
            {
                await _service.AtualizarProduto(id, produto);
                return Ok(produto);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível alterar o produto" });
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            var produto = await _service.ObterProdutoPeloId(id);
            if (produto == null)
                return BadRequest(new { message = "Produto não encontrado" });

            try
            {
                await _service.DeletarProduto(produto);
                return Ok(new { message = "Produto removido com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o produto" });
            }
        }

    }
}