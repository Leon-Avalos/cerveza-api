using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cervezaApi.Models;

namespace cervezaApi.Controllers
{
    [Route("api/cervezas")]
    [ApiController]
    public class CervezaController : ControllerBase
    {
        private readonly CervezaContext _context;

        public CervezaController(CervezaContext context)
        {
            _context = context;

            if (_context.CervezaItem.Count() == 0)
            {

                //Crea un nuevo CervezaItem si la coleccion 
                // which means you can't delete all TodoItems.
                _context.CervezaItem.Add(new CervezaItems { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        //Metodo GET: api/cervezas 
        [HttpGet]
        /**Obtiene todos los items de la clase cerveza y los convierte a una lista retornando mediante un metodo asincrono  */
        public async Task<ActionResult<IEnumerable<CervezaItems>>> GetCervezaItems() => await _context.CervezaItem.ToListAsync();

        //Metodo GET que obtiene un item especifico : api/cervezas/id
        [HttpGet("{id}")]
        public async Task<ActionResult<CervezaItems>> GetCervezaItems(long id)
        {
            //Busca el item con el id pasado como parametro
            var cervezaItem = await _context.CervezaItem.FindAsync(id);

            //Verifica que no sea nulo el parametro pasado
            if (cervezaItem == null)
            {
                //Retorna un status code de 404 (not found)
                return NotFound();
            }
            //Retorna el item cerveza ya serializado (parseado a JSON )
            return cervezaItem;
        }

        //Metodo POST: api/cervezas
        [HttpPost]
        public async Task<ActionResult<CervezaItems>> PostCervezaItem(CervezaItems item)
        {

            //Añade el item a la coleccion
            _context.CervezaItem.Add(item);

            //Guarda los cambios de manera asincrona
            await _context.SaveChangesAsync();

            //Retorna el objeto creado
            return CreatedAtAction(nameof(GetCervezaItems), new { id = item.Id }, item);
        }

        // PUT: api/cervezas/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCervezaItem(long id, CervezaItems item)
        {
            //Compara que el id del parametro sea igual al id del item
            //En caso que no lo sea, retorna una BadRequest code
            if (id != item.Id)
            {
                return BadRequest();
            }

            //Pone el estado del item en estado modificado
            _context.Entry(item).State = EntityState.Modified;

            //Guarda los cambios asicronamente en la base de datos en memora
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/cervezas/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            //Busca el item con el id pasado por parametro
            var cervezaItem = await _context.CervezaItem.FindAsync(id);

            //Si el item no existe retorna un status code de NotFound
            if (cervezaItem == null)
            {
                return NotFound();
            }

            //Elimina el item de la base de datos en memoria
            _context.CervezaItem.Remove(cervezaItem);

            //Guarda los cambios asincronamente dentro de la base de datos en memoria
            await _context.SaveChangesAsync();

            //Crea un response vacio y lo retorna
            return NoContent();
        }



    }
}