using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullStack.WebDemo.Models;
using FullStack.WebDemo.Services;

namespace FullStack.WebDemo.Controllers
{
    public class CategoriaController : Controller
    {
        ApiService _apiService;
        public CategoriaController(ApiService apiService)
        {
            _apiService = apiService;
        }
        // GET: CategoriaController
        public async Task<ActionResult> Index()
        {
            var lista = await _apiService.GetAsync<List<Categoria>>("categoria");
            return View(lista);
        }

        // GET: CategoriaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var p1 = await _apiService.GetAsync<Categoria>($"categoria/{id}");
            return View(p1);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Categoria c)
        {
            try
            {
                await _apiService.PostAsync<Categoria>("categoria/", c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var p1 = await _apiService.GetAsync<Categoria>($"categoria/{id}");
                return View(p1);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Categoria c)
        {
            try
            {
                await _apiService.PutAsync<Categoria>("categoria", c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var p1 = await _apiService.GetAsync<Categoria>($"categoria/{id}");
            return View(p1);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Categoria c)
        {
            try
            {
                await _apiService.DeleteAsync<Categoria>($"categoria/{c.Id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
