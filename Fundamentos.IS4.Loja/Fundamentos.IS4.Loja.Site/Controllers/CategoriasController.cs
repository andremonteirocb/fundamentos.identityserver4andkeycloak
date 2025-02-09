﻿using Microsoft.AspNetCore.Mvc;
using  Fundamentos.IS4.Loja.Domain.Interfaces;
using Fundamentos.IS4.Loja.Site.Models;
using Fundamentos.IS4.Loja.Domain.ViewObjects;
using System.Threading.Tasks;

namespace Fundamentos.IS4.Loja.Site.Controllers
{
    [Route("categorias")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaStore _categoriaStore;
        private readonly IProdutoStore _produtoStore;
        private readonly IMarcaStore _marcaStore;

        public CategoriasController(ICategoriaStore categoriaStore, IProdutoStore produtoStore, IMarcaStore marcaStore)
        {
            _categoriaStore = categoriaStore;
            _produtoStore = produtoStore;
            _marcaStore = marcaStore;
        }

        [Route("{categoria}")]
        public async Task<IActionResult> Index(string categoria, [FromQuery] PesquisarProdutoVo model)
        {
            model.Categoria = categoria.ToLower();
            var categoriaData = await _categoriaStore.ObterPorNome(categoria);

            return View("Produtos/_ListaProdutos", new ProdutosPrincipalViewModel()
            {
                Produtos = await _produtoStore.PesquisarPorCategoria(model),
                ImagemCapa = categoriaData?.ImagemCapa,
                Titulo = categoriaData?.Nome,
                SubTitulo = categoriaData?.Descricao,
                Categorias = await _categoriaStore.ObterTodos(),
                Marcas = await _marcaStore.ObterTodos(),
                PesquisaAtual = model,
                Action = "Lista",
                Controller = "Home"
            });
        }
    }
}
