using System.ComponentModel.DataAnnotations;

namespace CriasApp.Models
{
    public class RegistoSensores
    {

        [Key]
        public int IdSensor { get; set; }

        [Display(Name = "Frecuencia Cardiaca")]
        public string? freCardiaca { get; set; }

        [Display(Name = "Presión Sanguinea")]
        public string? preSanguinea { get; set; }

        [Display(Name = "Frecuencia Respiratoria")]
        public string? freRespiratoria { get; set; }

        [Display(Name = "Temperatura")]
        public int temperatura { get; set; }

              

    }
}
