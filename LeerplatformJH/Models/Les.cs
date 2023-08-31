using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeerplatformJH.Models
{
    public class Les
    {
        [Key]
        public int LesId { get; set; }
        [Required(ErrorMessage = "Titel is verplicht")]
        [Display(Name = "Titel")]
        [StringLength(50)]
        public string? Titel { get; set; }
        [Required(ErrorMessage = "Omschrijving is verplicht")]
        [Display(Name = "Omschrijving")]
        [StringLength(50)]
        public string? Omschrijving { get; set; }
        [Required(ErrorMessage = "Tijdstip start is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start van de les")]
        public DateTime TijdstipStart { get; set; }
        [Required(ErrorMessage = "Tijdstip einde is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Einde van de les")]
        public DateTime TijdstipEinde { get; set; }
        public int LokaalId { get; set; }
        public int StudentId { get; set; }
        public int DocentId { get; set; }
        public int VakId { get; set; }
        public virtual Vak? Vak { get; set; }
        public virtual Lokaal? Lokaal { get; set; }
        public virtual Docent? Docent { get; set; }
        public ICollection<Student>? Studenten { get; set; }

    }

}
