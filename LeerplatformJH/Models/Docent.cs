using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeerplatformJH.Models
{
    public class Docent
    {
        
        public int DocentId { get; set; }
        [Required(ErrorMessage = "Achternaam is verplicht")]
        [Display(Name = "Achternaam")]
        [StringLength(50)]
        public string? Achternaam { get; set; }
        [Required(ErrorMessage = "Voornaam is verplicht")]
        [Column("Voornaam")]
        [Display(Name = "Voornaam")]
        [StringLength(50)]
        public string? Voornaam { get; set; }
        [Required(ErrorMessage = "Email is verplicht")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mailadres")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Indiensttreding is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Indiensttreding")]
        public DateTime? Indiensttreding { get; set; }
        public virtual ICollection<Les>? Lessen { get; set; }
        public virtual ICollection<Vak>? Vakken { get; set; }
    }
}
