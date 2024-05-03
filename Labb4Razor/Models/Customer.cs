using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Labb4Razor.Models;

public class Customer
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }
    [Required]
    public string CustomerName { get; set; }
    
    public int CustomerAge { get; set; }
    [MaxLength(138)]
    public string CustomerFavouriteBook { get; set; }
    public ICollection<Loan>? Loans { get; set; } 

}