namespace SACDS.Modelo.DTO
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public int IdDonador { get; set; }
        public int IdTipoDonacion { get; set; }
        public int IdDonacionUrgente { get; set; }
        public DateTime FechaDonacion { get; set; }
    }
}
