namespace SACDS.Modelo.EntityFramework
{
    public class Cita
    {
        public int Id { get; set; }
        public int IdDonador { get; set; }
        public int IdTipoDonacion { get; set; }
        public int IdDonacionUrgente { get; set; }
        public DateTime FechaDonacion { get; set; }
        


        public virtual DonacionUrgente DonacionUrgente { get; set; }
        public virtual Donador Donador { get; set; }
        public virtual TipoDonacion TipoDonacion { get; set; }
    }
}
