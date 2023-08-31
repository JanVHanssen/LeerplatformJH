namespace LeerplatformJH.Models.ViewModels
{
    public class StudentUitschrijving
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public IEnumerable<Vak> Vakken { get; set; }
        public int SelectedVakId { get; set; }
        public string Titel { get; set; }
    }
}
