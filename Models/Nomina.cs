using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Nomina
{
    [Key]
    public int NominaId {get; set;}

    [Required(ErrorMessage = "Favor de Ingresar el pago.")]
    public int? pago { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar la forma de pago")]
    public String? Forma_Pago { get; set; }

    [Required(ErrorMessage = "Favor de EmpleadoId la forma de pago")]
    public int EmpleadoId {get; set;}
}