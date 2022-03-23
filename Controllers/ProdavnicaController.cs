using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdavnicaController : ControllerBase
    {       
        public OdnesiContext Context {get; set;}

        public ProdavnicaController(OdnesiContext context)
        { 
            Context = context;
        }  
        
        [Route("SveProdavnice")]
        [HttpGet]

        public async Task<ActionResult> SveProdavnice()
        {
            return Ok(Context.Prodavnice);
        }

        [Route("ProdavnicaPoIdu")]
        [HttpGet]

        public async Task<ActionResult> ProdavnicaPoIdu(int id)
        {
            var prodavnica = Context.Prodavnice.Where( p => p.IdProdavnice == id);
            return Ok(prodavnica);
        }

        [Route("ProdavnicePoKategorijama")]
        [HttpGet]

        public async Task<ActionResult> ProdavnicePoKategorijama(int index)
        {
            var prodavnice = Context.Prodavnice.Where(p => p.IdProdavnice == index)
            .Include( p=> p.KategorijeProdavnice);
            return Ok(prodavnice);
        }

        [Route("Dodaj Prodavnicu")]
        [HttpPost]

        public async Task<ActionResult> DodajProdavnicu([FromBody] Prodavnica Prodavnica)
        {
            if(String.IsNullOrWhiteSpace(Prodavnica.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
            if(String.IsNullOrWhiteSpace(Prodavnica.Adresa))
            {
                return BadRequest("Unesite Naziv");
            }
            try
            {
                Context.Prodavnice.Add(Prodavnica);
                await Context.SaveChangesAsync();
                return Ok($"Prodavnica sa nazivom: {Prodavnica.Naziv} je dodata");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("Izmeni Prodavnicu")]
        [HttpPut]

        public async Task<ActionResult> IzmeniProdavnicu(int IdProdavnice, Prodavnica Prodavnica)
        {
             if(String.IsNullOrWhiteSpace(Prodavnica.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
            if(String.IsNullOrWhiteSpace(Prodavnica.Adresa))
            {
                return BadRequest("Unesite Naziv");
            }

        try
        {
            var prodavnica = Context.Prodavnice.Where( p => p.IdProdavnice == IdProdavnice).FirstOrDefault();
            String stariNaziv = prodavnica.Naziv;
            if(Prodavnica != null){
                prodavnica.Naziv = Prodavnica.Naziv;
                prodavnica.Adresa = Prodavnica.Adresa;
                await Context.SaveChangesAsync();
                return Ok($"Prodavnica je sa nazivom: {stariNaziv} je promenjana u {Prodavnica.Naziv}");
            }
            else
            {
                return BadRequest("Molimo vas unesite prodavnicu");
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
                var prodavnica = await Context.Prodavnice.FindAsync(id);
                var nazivProdavnice = prodavnica.Naziv;
                Context.Prodavnice.Remove(prodavnica);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno izbrisana prodavnica: {nazivProdavnice}");

            }
            catch(Exception e)
            {

            return BadRequest(e.Message);
            }
        }
      
    }
}
