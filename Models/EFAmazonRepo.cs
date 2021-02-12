using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonStartUp.Models
{
    public class EFAmazonRepo : IAmazonRepo
    {
        private AmazonDBContext _context;

        public EFAmazonRepo(AmazonDBContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
