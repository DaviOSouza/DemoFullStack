using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullStack.WebDemo.Models;
using FullStack.WebDemo.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FullStack.WebDemo.Controllers
{
    public class ProdutoController : Controller
    {
        ApiService _apiService;
        public ProdutoController(ApiService apiService)
        {
            _apiService = apiService;
        }
        // GET: ProdutoController
        public async Task<ActionResult> Index()
        {
            var lista =  await _apiService.GetAsync<List<Produto>>("product");
            return View(lista);
        }

        // GET: ProdutoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var p1 = await _apiService.GetAsync<Produto>($"product/{id}");
            return View(p1);
        }

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            ObterCategorias(0);
            return View();
        }

        private void ObterCategorias(int currentCat)
        {
            var categorias = _apiService.GetAsync<List<Categoria>>("categoria").GetAwaiter().GetResult();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", currentCat);
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(Produto p)
        {
            try
            {
                await _apiService.PostAsync<Produto>("product/",p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var p1 = await _apiService.GetAsync<Produto>($"product/{id}");
                ObterCategorias(p1.CodigoCategoria);                
                return View(p1);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Produto p)
        {
            try
            {
                await _apiService.PutAsync<Produto>("product", p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var p1 = await _apiService.GetAsync<Produto>($"product/{id}");
            return View(p1);
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Produto p)
        {
            try
            {
                await _apiService.DeleteAsync<Produto>($"product/{p.Id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
