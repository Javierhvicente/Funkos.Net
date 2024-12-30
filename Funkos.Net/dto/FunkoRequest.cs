using System.ComponentModel.DataAnnotations;

public class FunkoRequest
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    [StringLength(50, ErrorMessage = "La categoría no puede superar los 50 caracteres.")]
    public string Categoria { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
    public double Precio { get; set; }
}