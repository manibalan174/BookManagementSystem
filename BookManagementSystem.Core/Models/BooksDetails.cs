using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Core.Models
{
   public class BooksDetails
    {
        [Key]
        public int BookDetailId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
