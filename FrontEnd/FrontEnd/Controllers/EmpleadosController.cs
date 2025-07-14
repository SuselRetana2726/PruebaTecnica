using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly HttpClient _http;

        public EmpleadosController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _http.GetAsync("api/empleados/arbol");
            var json = await response.Content.ReadAsStringAsync();
            var arbol = JsonSerializer.Deserialize<EmpleadoNodo>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(arbol);
        }

        public IActionResult Create(int? codigoJefe) => View(new Empleado { CodigoJefe = codigoJefe });

        [HttpPost]
        public async Task<IActionResult> Create(Empleado emp)
        {
            var json = new StringContent(JsonSerializer.Serialize(emp), Encoding.UTF8, "application/json");
            await _http.PostAsync("api/empleados", json);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _http.GetAsync("api/empleados");
            var empleados = JsonSerializer.Deserialize<List<Empleado>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var emp = empleados?.FirstOrDefault(e => e.Codigo == id);
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Empleado emp)
        {
            var json = new StringContent(JsonSerializer.Serialize(emp), Encoding.UTF8, "application/json");
            await _http.PutAsync("api/empleados", json);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _http.DeleteAsync($"api/empleados/{id}");
            return RedirectToAction("Index");
        }
    }
}
