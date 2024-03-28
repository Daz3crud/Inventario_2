using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventario_2.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace Inventario_2.Controllers
{
    public class AsientoContablesController : Controller
    {
        private readonly InventarioContext _context;
        private readonly HttpClient _httpClient = new HttpClient();

        public AsientoContablesController(InventarioContext context)
        {
            _context = context;

            // Configurar el HttpClient con la base address y los encabezados
            _httpClient.BaseAddress = new Uri("https://ap1-contabilidad.azurewebsites.net/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Método de ejemplo para realizar una solicitud a la API
        public async Task<IActionResult> Index()
        {
            try
            {
                // Realizar una solicitud de ejemplo a un endpoint de la API de contabilidad
                HttpResponseMessage response = await _httpClient.GetAsync("/Contabilidad/OrigenCuenta");

                // Verificar si la solicitud fue exitosa (código de estado 200)
                if (response.IsSuccessStatusCode)
                {
                    // Puedes manejar la respuesta según sea necesario
                    // Por ejemplo, leer el contenido de la respuesta
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // Y realizar las acciones pertinentes con los datos obtenidos
                    // En este ejemplo, simplemente establecer un mensaje de éxito
                    ViewBag.Message = "Conexión exitosa con la API de Contabilidad";
                }
                else
                {
                    // Si la solicitud no fue exitosa, mostrar un mensaje de error
                    ViewBag.Message = "Error al conectar con la API de Contabilidad: " + response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                // Si se produce una excepción al conectar con la API, mostrar un mensaje de error
                ViewBag.Message = "Error al conectar con la API de Contabilidad: " + ex.Message;
            }

            var vAsientoContables = from asientoContable in _context.AsientoContables
                                    join cuentaContableDB in _context.CuentaContables
                                    on asientoContable.CuentaDb equals cuentaContableDB.IdCuentaContable
                                    join cuentaContableCr in _context.CuentaContables
                                    on asientoContable.CuentaCr equals cuentaContableCr.IdCuentaContable
                                    select new AsientoContable
                                    {
                                        IdMovimiento = asientoContable.IdMovimiento,
                                        Descripcion = asientoContable.Descripcion,
                                        Auxiliar = asientoContable.Auxiliar,
                                        CuentaDb = asientoContable.CuentaDb,
                                        CuentaDbDesc = cuentaContableDB.Descripcion,
                                        CuentaCr = asientoContable.CuentaCr,
                                        CuentaCrDesc = cuentaContableCr.Descripcion,
                                        Monto = asientoContable.Monto
                                    };

            return View(await vAsientoContables.ToListAsync());
        }

        // GET: AsientoContables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientoContables
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            return View(asientoContable);
        }

        // GET: AsientoContables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AsientoContables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMovimiento, Descripcion, Auxiliar, CuentaDB, CuentaCR, Monto")] AsientoContable asientoContable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asientoContable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asientoContable);
        }

        // GET: AsientoContables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientoContables.FindAsync(id);
            if (asientoContable == null)
            {
                return NotFound();
            }
            return View(asientoContable);
        }

        // POST: AsientoContables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMovimiento, Descripcion, Auxiliar, CuentaDB, CuentaCR, Monto")] AsientoContable asientoContable)
        {
            if (id != asientoContable.IdMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asientoContable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsientoContableExists(asientoContable.IdMovimiento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(asientoContable);
        }

        // GET: AsientoContables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoContable = await _context.AsientoContables
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            return View(asientoContable);
        }

        // POST: AsientoContables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asientoContable = await _context.AsientoContables.FindAsync(id);
            _context.AsientoContables.Remove(asientoContable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsientoContableExists(int id)
        {
            return _context.AsientoContables.Any(e => e.IdMovimiento == id);
        }
    }
}
