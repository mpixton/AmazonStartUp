using System.Collections.Generic;
using System.Linq;

namespace AmazonStartUp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Stores a list of Books currently in the cart.
        /// </summary>
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        /// <summary>
        /// Adds a Book to the current user's cart, if not already there, else adds the quantity to the Book already there.
        /// </summary>
        /// <param name="book">Instance of object Book to purchase.</param>
        /// <param name="quantity">Number Books book to purchase.</param>
        public void AddItem(Book book, int quantity)
        {
            // Check if the Book is already in the cart.
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            // If the Book is not in the Cart, then add the Book to the Cart with the given quantity.
            // Else, the Book already is in the Cart, and update the quantity accordingly.
            if (line is null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// Removes the CartLine item associated with "Book" from the Cart.
        /// </summary>
        /// <param name="book"></param>
        public void RemoveLine(Book book) =>
            Lines.RemoveAll(b => b.Book.BookId == book.BookId);

        /// <summary>
        /// Resets the Cart.
        /// </summary>
        public void Clear() => 
            Lines.Clear();

        /// <summary>
        /// Computes the total price of all Books in the Cart.
        /// </summary>
        /// <returns>Total of Book Price times the Quantity.</returns>
        public decimal ComputeTotal() =>
            Lines.Sum(b => b.Book.Price * b.Quantity);

        /// <summary>
        /// Object to store the Book and Quantity desired to purchase for a user. 
        /// </summary>
        public class CartLine
        {
            /// <summary>
            /// PK of the CartLine object.
            /// </summary>
            public int CartLineID { get; set; }

            /// <summary>
            /// Book object that is associated with the CartLine object.
            /// </summary>
            public Book Book { get; set; }

            /// <summary>
            /// Quantity of the Book to purchase.
            /// </summary>
            public int Quantity { get; set; }

        }
    }
}
