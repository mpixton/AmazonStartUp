using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonStartUp.Models.ViewModels
{
    /// <summary>
    /// Class to store information related to paging.
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Total number of items to be paginated.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Items per page of pagination.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Current page the user is on.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Returns the total number of pages given the items per page and total items.
        /// </summary>
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);
    }
}
