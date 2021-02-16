using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        [Column(TypeName="decimal(6,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// First Name of the Author of the Book.
        /// </summary>
        // TODO Turn Author into separate model.
        [Required]
        public string AuthFirstName { get; set; }

        /// <summary>
        /// Middle Name of the Author of the Book (if applicable).
        /// </summary>
        public string? AuthMidName { get; set; }

        /// <summary>
        /// Last Name of the Author of the Book.
        /// </summary>
        [Required]
        public string AuthLastName { get; set; }

        /// <summary>
        /// Publisher of the Book.
        /// </summary>
        // TODO Turn Publisher into separate model.
        [Required]
        public string Publisher { get; set; }

        /// <summary>
        /// Classification of the Book. Enum.
        /// </summary>
        // TODO Turn Classification into Static Class.
        [Required]
        public string Classification { get; set; }

        /// <summary>
        /// Category of the Book within the Classification. Enum.
        /// </summary>
        // TODO Turn Category into Static Class.
        [Required]
        public string Category { get; set; }
    }
}
