using System.ComponentModel.DataAnnotations;
public class Ausencias
{
    [Key]
    public int AusenciaId { get; set; }

    [Required(ErrorMessage = "Favor de ingresar el empleadoId")]
    public int EmpleadoId { get; set; }
    [Required(ErrorMessage = "Favor de ingresar la cantidad de dias en ausencia")]
    public int CantidadDias { get; set; }

    [Required(ErrorMessage = "Favor de ingresar el motivo de la ausencia")]
    public string? MotivoAusencia { get; set; }

    [Required(ErrorMessage = "Favor de ingresar la fecha")]
    public DateTime Fecha {get; set;} = DateTime.Now;
}