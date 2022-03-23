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
    public class ProizvodiController : ControllerBase
    {       
        public OdnesiContext Context {get; set;}

        public ProizvodiController(OdnesiContext context)
        { 
            Context = context;
        }  
        
        [Route("Proizvodi")]
        [HttpGet]

        public async Task<ActionResult> Proizvod()
        {
            var proizvod = Context.Proizvodi
            .Include(p => p.ProizvodiKategorijama);
            return Ok(proizvod);
        }

        [Route("Dodaj Proizvod")]
        [HttpPost]

        public async Task<ActionResult> DodajProizvod([FromBody] Proizvodi Proizvod)
        {
            if(String.IsNullOrWhiteSpace(Proizvod.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
            if(Proizvod.Cena < 0)
            {
                return BadRequest("Unesite Cenu");
            }
            try
            {
                Context.Proizvodi.Add(Proizvod);
                await Context.SaveChangesAsync();
                return Ok($"Proizvod sa nazivom: {Proizvod.Naziv} je dodata");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("Izmeni Proizvod")]
        [HttpPut]

        public async Task<ActionResult> IzmeniProizvod(int IdProizvoda, Proizvodi Proizvod)
        {
             if(String.IsNullOrWhiteSpace(Proizvod.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
             if(Proizvod.Cena < 0)
            {
                return BadRequest("Unesite Cenu");
            }

        try
        {
            var proizvod = Context.Proizvodi.Where( p => p.IdProizvoda == IdProizvoda).FirstOrDefault();
            String stariNaziv = proizvod.Naziv;
            if(Proizvod != null){
                proizvod.Naziv = Proizvod.Naziv;
                proizvod.Cena = Proizvod.Cena;
                proizvod.Popust = Proizvod.Popust;
                await Context.SaveChangesAsync();
                return Ok($"Proizvod sa nazivom: {stariNaziv} je promenjana u { proizvod.Naziv}");
            }
            else
            {
                return BadRequest("Molimo vas unesite proizvod");
            }
        }
        catch (Exception e)
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
                var proizvod = await Context.Proizvodi.FindAsync(id);
                var nazivProizvoda = proizvod.Naziv;
                Context.Proizvodi.Remove(proizvod);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno izbrisana prodavnica: {nazivProizvoda}");

            }
            catch(Exception e)
            {

            return BadRequest(e.Message);
            }
        }
      
    }
}
