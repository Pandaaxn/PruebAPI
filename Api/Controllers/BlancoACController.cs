using Api.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlancoACController : ControllerBase
    {
        public static List<CatalogoColores> ListaColores = new List<CatalogoColores>();

        [HttpGet("ObtenSaludo/{nombre}/{edad}")]
        public string ObtenSaludo(string nombre, int edad)
        {
            return $"Hola {nombre}, tienes {edad} años, desde la API";
        }
        [HttpGet("ObtenColores")]
        public List<CatalogoColores> ObtenColores()
        {

            return ListaColores;
        }

        [HttpPost("AgregaColor")]
        public IActionResult AgregaColor(CatalogoColores color)
        {
            ListaColores.Add(color);
            return Ok();
        }
        [HttpDelete("EliminaColor/{id}")]
        public IActionResult EliminaColor(int id)
        {
            var color = ListaColores.FirstOrDefault(c => c.Id == id);
            if (color != null)
            {
                ListaColores.Remove(color);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("ActualizaColor/{id}")]
        public IActionResult ActualizaColor(int id, CatalogoColores colorActualizado)
        {
            var color = ListaColores.FirstOrDefault(c => c.Id == id);
            if (color != null)
            {
                ListaColores.Remove(color);
                ListaColores.Add(colorActualizado);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
