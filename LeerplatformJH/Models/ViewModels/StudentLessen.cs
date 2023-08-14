using System.ComponentModel.DataAnnotations;

namespace LeerplatformJH.Models.ViewModels
{
    public class StudentLessen
    {
        [Key]
        public int Id { get; set; }
        public Student LesStudent { get; set; }
        public IEnumerable<Les> Lessen { get; set; }


    }
}
