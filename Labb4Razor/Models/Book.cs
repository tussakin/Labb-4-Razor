using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Labb4Razor.Models;


public class Book
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set;}
    [MinLength(3)]
    public string BookTitle { get; set; }
    [Required]
    public string BookAuthor { get; set; }
    public int BookReleaseYear { get; set; }
    public ICollection<Loan> Loans { get; set; } 

    }