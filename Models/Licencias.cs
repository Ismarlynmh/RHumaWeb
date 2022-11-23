using System.ComponentModel.DataAnnotations;

public class Licencias
{
    [Key]
    public int LicenciaId { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar El empleadoId")]
    public int EmpleadoId { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar la Fecha de emicion de la licencia")]
    public DateTime FechaEmision { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Favor de Ingresar Fecha de inicio de la licencia")]
    public DateTime FechaInicio { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Favor de Ingresar La cantidad de dias de reposo otorgados en la licencia")]
    public string? DiasReposo { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar el tipo de licencia, ejemplo: maternidad, accidente...")]
    public string? TipoLicencia { get; set; }

    [Required(ErrorMessage = "Favor de ingresar la catacteristica de la licencia")]
    public string? Caracteristica { get; set; }
    [Required(ErrorMessage = "Favor de Ingresar el nombre del medico")]
    public string? NombreMedico { get; set; }
    [Required(ErrorMessage = "Favor de Ingresar el lugar de emicion, ejemplo: Hospital San Vicente de Paul")]
    public string? LugarEmision { get; set; }

}