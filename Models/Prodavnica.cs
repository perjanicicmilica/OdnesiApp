using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Prodavnica")]
    public class Prodavnica
    {
        [Key]
        public int IdProdavnice { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Naziv { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Adresa { get; set; }

        public List<Kategorija> KategorijeProdavnice {get; set;}
        
    }
}