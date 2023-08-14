using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeerplatformJH.Models
{
    public class Vak
    {
        [Key]
        public int VakId { get; set; }
        [Required(ErrorMessage = "Titel is verplicht")]
        [Display(Name = "Titel")]
        [StringLength(50)]
        public string? Titel { get; set; }
        [Required(ErrorMessage = "Studiepunten is verplicht")]
        [Range(1, 9, ErrorMessage = "Gelieve een getal in te geven tussen 1 en 9")]
        [Display(Name = "Studiepunten")]
        public int Studiepunten { get; set; }
        public int DocentId { get; set; }
        public Docent? Docent { get; set; }
        public ICollection<VakInschrijving>? VakInschrijvingen { get; set; }
        public ICollection<Les>?Lessen { get; set; }
    }
}
