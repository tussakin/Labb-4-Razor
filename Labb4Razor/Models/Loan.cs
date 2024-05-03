using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Labb4Razor.Models;

public enum Status
{
    OnLoan,
    Unavailable,
    Returned
    
}
public class Loan
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LoanId { get; set; }
    [ForeignKey("Customer")]
    public int FkCustomerId { get; set; }
    [ForeignKey("Book")]
    public int FkBookId { get; set; }
    public Status LoanStatus { get; set; }
    public Customer Customer { get; set; }
    public Book Book { get; set; }
    
} 