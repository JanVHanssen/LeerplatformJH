using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeerplatformJH.Models
{
    public class Student
    {
        
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Achternaam is verplicht")]
        [Display(Name = "Achternaam")]
        [StringLength(50)]
        public string? Achternaam { get; set; }
        [Required(ErrorMessage = "Voornaam is verplicht")]
        [Display(Name = "Voornaam")]
        [StringLength(50)]
        public string? Voornaam { get; set; }
        [Required(ErrorMessage = "Email is verplicht")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mailadres")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Inschrijvingsdatum is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum inschrijving")]
        public DateTime Inschrijvingsdatum { get; set; }
        public ICollection<VakInschrijving>?Vakinschrijvingen { get; set; }
        public ICollection<Les>?Lessen { get; set; }

    }
}
