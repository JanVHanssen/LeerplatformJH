using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LeerplatformJH.Models
{
    public class Gebruiker : IdentityUser
    {
        [Key]
        public int GebruikerId { get; set; }
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
        public string UNummer { get; set; }
        public virtual ICollection<VakInschrijving>? Vakinschrijvingen { get; set; }
    }
}
