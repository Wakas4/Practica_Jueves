using System.ComponentModel.DataAnnotations;
namespace Models;
public class Persona
{
    [Key]
    public int CI {get; set; }
    public string Nombre {get; set;}
    public string Apellido {get; set;}
}
