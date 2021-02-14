using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public decimal Price { get; set; }
    }
}
