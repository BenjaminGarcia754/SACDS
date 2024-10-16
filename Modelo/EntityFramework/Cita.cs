using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACDS.Modelo.EntityFramework
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdDonador { get; set; }
        [Required]
        public int IdTipoDonacion { get; set; }

        public int IdDonacionUrgente { get; set; }
        [Required]
        public DateTime FechaDonacion { get; set; }
        


        public virtual DonacionUrgente DonacionUrgente { get; set; }
        public virtual Donador Donador { get; set; }
        public virtual TipoDonacion TipoDonacion { get; set; }
    }
}
