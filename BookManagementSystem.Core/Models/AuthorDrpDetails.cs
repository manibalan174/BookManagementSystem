using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Core.Models
{
   public class AuthorDrpDetails
    {
        public int AuthorDetailId { get; set; }
        [Required]
        public string AuthourName { get; set; }
    }
}
