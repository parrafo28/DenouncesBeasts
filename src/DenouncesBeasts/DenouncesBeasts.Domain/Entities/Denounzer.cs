namespace DenouncesBeasts.Domain.Entities
{
    public class Denounzer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
         public List<Denounce> Denounces { get; set; }
    }
}
