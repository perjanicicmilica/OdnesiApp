using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Odnesi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KategorijeController : ControllerBase
    {       
        public OdnesiContext Context {get; set;}

        public KategorijeController(OdnesiContext context)
        { 
            Context = context;
        }  

        [Route("Kategorija")]
        [HttpGet]

        public async Task<ActionResult> Kategorije()
        {
            var kategorija = Context.Kategorije;
            return Ok(kategorija);
        }

        [Route("KategorijeProizvoda")]
        [HttpGet]
        public async Task<ActionResult> KategorijeProizvoda(int id)
        {
            var kategorija = Context.Kategorije.Where(p => p.IdKategorije == id)
            .Include(p=> p.ProizvodiKategorije);
            return Ok(kategorija);
        }

        [Route("KategorijaPoIDu")]
        [HttpGet]
        public async Task<ActionResult> KategorijaPoIDu(int id)
        {
            var kategorija = Context.Kategorije.Where(p => p.IdKategorije == id);
            return Ok(kategorija);
        }

        [Route("Dodaj Kategoriju")]
        [HttpPost]

        public async Task<ActionResult> DodajKategoriju([FromBody] Kategorija Kategorija)
        {
            if(String.IsNullOrWhiteSpace(Kategorija.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
            try
            {
                Context.Kategorije.Add(Kategorija);
                await Context.SaveChangesAsync();
                return Ok($"Kategorija sa nazivom: {Kategorija.Naziv} je dodata");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Izbrisi")]
        [HttpDelete]
        public async Task<ActionResult> Izbrisi(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Pogresan ID");
            }
            try
            {
                var kategorija = await Context.Kategorije.FindAsync(id);
                var nazivKategorije = kategorija.Naziv;
                Context.Kategorije.Remove(kategorija);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno izbrisana Kategorija: {nazivKategorije}");

            }
            catch(Exception e)
            {

            return BadRequest(e.Message);
            }
        }
      
    }
}
