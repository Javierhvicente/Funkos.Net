using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funkos.Net.Database;
[Table("Funkos")]
public class FunkoEntity
{
    public const long NewId = 0;
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; } = NewId;
        
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(24)]
    public string Categoria { get; set; }
    
    [Required]
    public Double Precio { get; set; }
    [Required]
    [DefaultValue(false)]
    public bool IsDeleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}