using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeerplatformJH.Models
{
    public class Lokaal
    {
        [Key]
        public int LokaalId { get; set; }
        [Required(ErrorMessage = "Titel is verplicht")]
        [Display(Name = "Titel")]
        [StringLength(50)]
        public string? Titel { get; set; }
        [Required(ErrorMessage = "Omschrijving is verplicht")]
        [Display(Name = "Omschrijving")]
        [StringLength(50)]
        public string? Omschrijving { get; set; }
        [Required(ErrorMessage = "Capaciteit is verplicht")]
        [Range(1, 999, ErrorMessage = "Gelieve een getal in te geven tussen 1 en 999")]
        [Display(Name = "Capaciteit")]
        public int Capaciteit { get; set; }
        [Display(Name = "Middelen")]
        public string? Middelen { get; set; }

        public ICollection<Les>? Lessen { get; set; }
    }
}
