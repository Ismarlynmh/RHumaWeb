using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Vacaciones
{
    [Key]
    public int VacacionesId { get; set; } //
    [Required(ErrorMessage = "Favor de Ingresar el Incentivo.")]
    public int Incentivo { get; set; }
    [Required(ErrorMessage = "Favor de Ingresar el dia de inicio.")]
    public DateTime DiasInicio { get; set; }//
    [Required(ErrorMessage = "Favor de Ingresar el dia de fin.")]
    public DateTime DiasFinal { get; set; }//
    [Required(ErrorMessage = "Favor de Ingresar el EmpleadoId.")]

    public int EmpleadoId { get; set; }//
}