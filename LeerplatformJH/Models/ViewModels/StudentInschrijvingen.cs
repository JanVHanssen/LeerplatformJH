using System.ComponentModel.DataAnnotations;

namespace LeerplatformJH.Models.ViewModels
{
    public class StudentInschrijvingen
    {
        [Key]
        public int Id { get; set; }
        public Student InschrijvingStudent { get; set; }
        public IEnumerable<VakInschrijving> VakInschrijvingen { get; set; }
    }
}
