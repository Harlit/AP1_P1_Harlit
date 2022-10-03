using System.ComponentModel.DataAnnotations;
public class Registros
{
    [Key]
    public int RegistroId{ get; set; }

    public string? Detalle { get; set;}

}

