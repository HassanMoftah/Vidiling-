using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidiling.Models;
namespace Vidiling.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}