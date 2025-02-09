﻿using Microsoft.AspNetCore.Mvc;
using  Fundamentos.IS4.Loja.Domain.Interfaces;
using System.Threading.Tasks;

namespace Fundamentos.IS4.Loja.Site.ViewComponents
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly ICarrinhoStore _carrinhoStore;

        public CarrinhoViewComponent(ICarrinhoStore carrinhoStore)
        {
            _carrinhoStore = carrinhoStore;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoStore.ObterCarrinho(User.Identity.Name));
        }
    }

    public class CarrinhoMobileViewComponent : ViewComponent
    {
        private readonly ICarrinhoStore _carrinhoStore;

        public CarrinhoMobileViewComponent(ICarrinhoStore carrinhoStore)
        {
            _carrinhoStore = carrinhoStore;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoStore.ObterCarrinho(User.Identity.Name));
        }
    }
}
