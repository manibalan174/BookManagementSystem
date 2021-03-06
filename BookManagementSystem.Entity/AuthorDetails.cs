// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookManagementSystem.Entity
{
    public partial class AuthorDetails
    {
        public AuthorDetails()
        {
            BookDetails = new HashSet<BookDetails>();
        }

        [Key]
        public int AuthorDetail_Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Authour_Name { get; set; }
        public bool Is_Delete { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Create_Time_Stamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Update_Time_Stamp { get; set; }

        [InverseProperty("Author")]
        public virtual ICollection<BookDetails> BookDetails { get; set; }
    }
}