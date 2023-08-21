namespace LeerplatformJH.Models.ViewModels
{
    public class StudentNieuweInschrijving
    {
        public int Id { get; set; }
        public IEnumerable<Vak> Vakken { get; set; }
        public int SelectedVakId { get; set; }
        public string Titel { get; set; }
    }
}
