using System.ComponentModel.DataAnnotations;

namespace SACDS.Modelo.DTO
{
    public class DonacionUrgenteDTO
    {
        public int Id { get; set; }
        [Required]
        public string NombrePaciente { get; set; }
        [Required]
        public string AreaPaciente { get; set; }
        [Required]
        public string GrupoSanguineoPaciente { get; set; }
    }
}
