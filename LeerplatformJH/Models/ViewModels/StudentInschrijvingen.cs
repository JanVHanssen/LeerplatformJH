using System.ComponentModel.DataAnnotations;

namespace LeerplatformJH.Models.ViewModels
{
    public class StudentInschrijvingen
    {
        
        public int Id { get; set; }
        public Student Student { get; set; }
        public IEnumerable<VakInschrijving> VakInschrijvingen { get; set; }
    }
}
