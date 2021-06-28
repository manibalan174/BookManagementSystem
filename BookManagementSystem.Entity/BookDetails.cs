﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookManagementSystem.Entity
{
    public partial class BookDetails
    {
        [Key]
        public int BookDetail_Id { get; set; }
        [Required]
        [StringLength(35)]
        public string Book_Title { get; set; }
        public int Author_Id { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public bool Is_Delete { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Create_Time_Stamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Update_Time_Stamp { get; set; }

        [ForeignKey(nameof(Author_Id))]
        [InverseProperty(nameof(AuthorDetails.BookDetails))]
        public virtual AuthorDetails Author { get; set; }
    }
}