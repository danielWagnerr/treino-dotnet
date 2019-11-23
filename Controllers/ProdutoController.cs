using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaAPI.Models;
namespace ProvaAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoContext _context;
        public ProdutoController(ProdutoContext context)
        {
            _context = context;
            if (_context.ProdutoItems.Count() == 0)
            {
                _context.ProdutoItems.Add(new ProdutoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoItem>>> GetProdutoItems()
        {
            return await _context.ProdutoItems.ToListAsync();
        }
        // GET: api/Produto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoItem>> GetProdutoItem(long id)
        {
            var produtoItem = await _context.ProdutoItems.FindAsync(id);
            if (produtoItem == null)
            {
                return NotFound();
            }
            return produtoItem;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoItem>> PostProdutoItem(ProdutoItem item)
        {
            _context.ProdutoItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProdutoItem), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoItem(long id)
        {
            var produtoItem = await _context.ProdutoItems.FindAsync(id);
            if (produtoItem == null)
            {
                return NotFound();
            }
            _context.ProdutoItems.Remove(produtoItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}