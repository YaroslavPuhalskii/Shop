using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.WebUI.Models
{
    public class PaginInfo
    {
        public int TotalItems { get; set; }
        public int CerrentPage { get; set; }
        public int ItemsPerPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}