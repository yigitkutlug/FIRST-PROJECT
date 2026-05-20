using System.ComponentModel.DataAnnotations;

namespace FirstProjectApi.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(80)]
    public string Author { get; set; } = string.Empty;

    [Range(0, 100000)]
    public decimal Price { get; set; }
}