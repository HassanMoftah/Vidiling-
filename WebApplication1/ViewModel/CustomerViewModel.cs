using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidiling.Models;
namespace Vidiling.ViewModel
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}