using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonStartUp.Models
{
    /// <summary>
    /// Represents a Book. Author, Publisher, Category, and Sub-Category are all related to Book, but stored in their own model.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Primary Key of the Book table.
        /// </summary>
        [Key]
        public int BookId { get; set; }

        /// <summary>
        /// International Standard Book Number of the Book.
        /// </summary>
        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{10}$",
            ErrorMessage = "Format: ###-##########")]
        [MaxLength(14)]
        public string ISBN { get; set; }

        /// <summary>
        /// Title of the Book. 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Price of the Book.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Number of Pages in the Book.
        /// </summary>
        [Required]
        public int Pages { get; set; }

        /// <summary>
        /// First Name of the Author of the Book.
        /// </summary>
        // TODO Turn Author into separate model.
        [Required]
        [MaxLength(50)]
        public string AuthFirstName { get; set; }

        /// <summary>
        /// Middle Name of the Author of the Book (if applicable).
        /// </summary>
        [MaxLength(50)]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? AuthMidName { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        /// <summary>
        /// Last Name of the Author of the Book.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string AuthLastName { get; set; }

        /// <summary>
        /// Publisher of the Book.
        /// </summary>
        // TODO Turn Publisher into separate model.
        [Required]
        [MaxLength(50)]
        public string Publisher { get; set; }

        /// <summary>
        /// Classification of the Book.
        /// </summary>
        // TODO Turn Classification into Static Class.
        [Required]
        [MaxLength(11)]
        public string Classification { get; set; }

        /// <summary>
        /// Category of the Book within the Classification.
        /// </summary>
        // TODO Turn Category into Static Class.
        [Required]
        [MaxLength(20)]
        public string Category { get; set; }
    }
}
