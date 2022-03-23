using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Kategorije")]
    public class Kategorija
    {
        [Key]
        public int IdKategorije { get; set; }

        [Required]
        [MaxLength(20)]
        public string Naziv { get; set; }
        public List<Proizvodi> ProizvodiKategorije {get; set;}        
        [JsonIgnore]
        public List<Prodavnica> KategorijeProdavnice {get; set;}
    }
}