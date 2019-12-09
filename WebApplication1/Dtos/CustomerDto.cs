using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidiling.Models;

using System.ComponentModel.DataAnnotations;
namespace Vidiling.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        //DataAnnotations
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }


        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        //[Min18Customer]
        public DateTime? Birthday { get; set; }
    }
}