using System.ComponentModel.DataAnnotations;
public class Aportes
{
    [Key]
    public int AporteId{ get; set; }

    [Required(ErrorMessage= "La fecha es requerida")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage =" Se requiere Persona")]
    public string? Persona { get; set;}

    [Required(ErrorMessage =" Se requiere Observacion")]
    public string? Observacion { get; set;}

    [Required(ErrorMessage =" Se requiere Monto")]
    public int Monto { get; set;}

}

