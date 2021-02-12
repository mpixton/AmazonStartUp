using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonStartUp.Models
{
    public interface IAmazonRepo
    {
        IQueryable<Book> Books { get; }
    }
}
