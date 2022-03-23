using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Proizvodi")]
    public class Proizvodi
    {
        [Key]
        public int IdProizvoda { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Naziv { get; set; }

        [Required]
        public int Cena { get; set; }

        public int Popust { get; set; }      
        [JsonIgnore]
        public List<Kategorija> ProizvodiKategorijama {get; set;} 
    }
}