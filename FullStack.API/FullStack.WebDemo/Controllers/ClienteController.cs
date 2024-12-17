using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullStack.WebDemo.Models;
using FullStack.WebDemo.Services;

namespace FullStack.WebDemo.Controllers
{
    public class ClienteController : Controller
    {
        ApiService _apiService;

        public ClienteController(ApiService apiService)
        {
            _apiService = apiService;
        }
        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            var lista = await _apiService.GetAsync<List<Cliente>>("cliente");
            return View(lista);
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var p1 = await _apiService.GetAsync<Cliente>($"cliente/{id}");
            return View(p1);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente c)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Dados inválidos";
                    return View();
                }
                await _apiService.PostAsync<Cliente>("cliente/", c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var p1 = await _apiService.GetAsync<Cliente>($"cliente/{id}");
                return View(p1);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Cliente c)
        {
            try
            {
                await _apiService.PutAsync<Cliente>("cliente", c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var p1 = await _apiService.GetAsync<Cliente>($"cliente/{id}");
            return View(p1);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Cliente c)
        {
            try
            {
                await _apiService.DeleteAsync<Cliente>($"cliente/{c.Id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
