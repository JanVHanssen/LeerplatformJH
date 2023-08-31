using System.ComponentModel.DataAnnotations;

namespace LeerplatformJH.Models.ViewModels
{
    public class StudentLessen
    {    
        public int Id { get; set; }
        public Student Student { get; set; }
        public IEnumerable<Les> Lessen { get; set; }
    }
}
