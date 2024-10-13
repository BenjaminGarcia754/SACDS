using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SACDS.Modelo.EntityFramework
{
    public class DonacionUrgente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NombrePaciente { get; set; }
        [Required]
        public string AreaPaciente { get; set; }
        [Required]
        public string GrupoSanguineoPaciente { get; set; }
    }
}
