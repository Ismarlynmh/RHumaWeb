using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Empleados
{
    [Key]
    public int EmpleadoId { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar el nombre.")]
    public string? Nombre { get; set; }

    [RegularExpression(@"^\d{3}-\d{7}-\d{1}$")]
    public string? Cedula { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Direccion { get; set; }

    [Remote(action: "VerifyEmail", controller: "Users")]
    [EmailAddress(ErrorMessage = "Ingrese correctamente el Email.")]
    public string? Email { get; set; }

    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
    [Phone(ErrorMessage = "Favor de ingresar correctamente el numero Celular.")]
    public string? Celular { get; set; }

    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
    [Phone(ErrorMessage = "Favor de ingresar correctamente el numero Telefonico.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar El departamento para el que va a trabajar la persona")]
    public string? Departamento { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar el cargo del empleado.")]
    public string? Cargo { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar El sueldo.")]
    [Range(25000, 20000000)]
    public float? Sueldo { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar la forma de pago")]
    public string? FormaPago { get; set; }

    [Required(ErrorMessage = "Favor de Ingresar la fecha de ingreso.")]
    public DateTime FechaIngreso { get; set; } = DateTime.Now;
}