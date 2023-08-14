using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace LeerplatformJH.Models
{
    public enum Goedkeuring
    {
        Toegelaten, In_beraad, Afgewezen
    }
    public class VakInschrijving
    {
        [Key]
        public int VakInschrijvingId { get; set; }
        public String? Titel { get; set; }
        public int StudentId { get; set; }

        public int VakId { get; set; }
        [DisplayFormat(NullDisplayText = "In beraad")]
        public Goedkeuring? Goedkeuring { get; set; }

        public virtual Vak? Vak { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }

    }
}
