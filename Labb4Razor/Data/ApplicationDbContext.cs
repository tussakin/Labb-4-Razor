using Labb4Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4Razor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Loan>()
                .HasKey(cb => new { cb.FkCustomerId, cb.FkBookId });

            modelBuilder.Entity<Loan>()
                .HasOne(cb => cb.Customer)
                .WithMany(c => c.Loans)
                .HasForeignKey(cb => cb.FkCustomerId);

            modelBuilder.Entity<Loan>()
                .HasOne(cb => cb.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(cb => cb.FkBookId);
        }
        
        
        public void SeedData()
        {
            if (!Books.Any() || !Customers.Any())
            {
                SeedBooks();
                SeedCustomers();
            }

            if (!Loans.Any())
            {
                var book = Books.FirstOrDefault(); 
                var customer = Customers.FirstOrDefault(); 

                if (book != null && customer != null)
                {
                    var loans = new List<Loan>
                    {
                        new Loan { FkBookId = 1, FkCustomerId = 5, LoanStatus = Status.OnLoan },
                        new Loan { FkBookId = 5, FkCustomerId = 1, LoanStatus = Status.Returned},
                        new Loan { FkBookId = 4, FkCustomerId = 3, LoanStatus = Status.Returned},
                        new Loan { FkBookId = 1, FkCustomerId = 1, LoanStatus = Status.Returned},
                        new Loan { FkBookId = 6, FkCustomerId = 5, LoanStatus = Status.Returned},
                        new Loan { FkBookId = 3, FkCustomerId = 2, LoanStatus = Status.Returned}

                    };
                    Loans.AddRange(loans);
                    SaveChanges();
                }
            }
        }
        
        
        
            public void SeedBooks()
            {
            if (!Books.Any())
            {
                Books.AddRange(
                    
                    new Book { BookTitle = "Book 1", BookAuthor = "Author 1", BookReleaseYear = 2022 },
                    new Book { BookTitle = "Book 2", BookAuthor = "Author 2", BookReleaseYear = 2020 },
                    new Book { BookTitle = "Book 3", BookAuthor = "Author 3", BookReleaseYear = 2024 },
                    new Book { BookTitle = "Book 4", BookAuthor = "Author 4", BookReleaseYear = 2002 },
                    new Book { BookTitle = "Book 5", BookAuthor = "Author 5", BookReleaseYear = 2019 },
                    new Book { BookTitle = "Book 6", BookAuthor = "Author 6", BookReleaseYear = 2023 }
                );

            }
            SaveChanges();
            }
            public void SeedCustomers()
            {
            if (!Customers.Any())
            {
                Customers.AddRange(
                    new Customer
                    {
                        CustomerName = "John Doe", CustomerAge = 30,
                        CustomerFavouriteBook = "Sample Book 5 "
                    },
                    new Customer
                    {
                        CustomerName = "Jane Smith", CustomerAge = 25,
                        CustomerFavouriteBook = "Sample Book 2"
                    },
                    new Customer
                    {
                        CustomerName = "Karly Cross", CustomerAge = 22,
                        CustomerFavouriteBook = "Sample Book 4"
                    },
                    new Customer
                    {
                        CustomerName = "Liam Kassanova", CustomerAge = 38,
                        CustomerFavouriteBook = "Sample Book 6"
                    },
                    new Customer
                    {
                        CustomerName = "Mymoa Li", CustomerAge = 87,
                        CustomerFavouriteBook = "Sample Book 1"
                    }

                );
                SaveChanges();
                }
            }
        }
    }


