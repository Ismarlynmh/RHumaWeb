using System.ComponentModel.DataAnnotations;

public class Permisos
{
    [Key]
    public int PermisoId { get; set; }

    [Required(ErrorMessage = "Favor de ingresar el Id del empleado")]
    public int EmpleadoId { get; set; }

    [Required(ErrorMessage = "Favor de ingresar la cantidad de dias del permiso")]
    public int CantidadDias { get; set; }

    [Required(ErrorMessage = "Favor de ingresar el motivo del permiso")]
    public string? MotivoPermiso { get; set; }

    [Required(ErrorMessage = "Favor de ingresar la fecha")]
    public DateTime Fecha { get; set; } = DateTime.Now;
}