using BookManagementSystem.Core.IRepostories;
using BookManagementSystem.Core.Models;
using BookManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Resource.Repostories
{
   public class BookManagemtRepostories: IRepostoriesBookManagement
    {
        #region Login validation
        public bool Loginvalidation(LoginDetails loginDetails)
        {
            try
            {
                if (loginDetails != null)
                {
                    using (var entites = new BookmanagementsystemContext())
                    {
                        var dbStudentdetails = entites.Login.SingleOrDefault(x => x.User_Name == loginDetails.UserName && x.Password == loginDetails.Password);
                        if (dbStudentdetails != null)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
        #endregion


        #region DropDown Author Details
       public List<AuthorDrpDetails> DrpAuthorList()
        {
            List<AuthorDrpDetails> AuthorlistDetails = new List<AuthorDrpDetails>();   // Create List
            try
            {
                using (var entites = new BookmanagementsystemContext())
                {
                    var dBAuthorDetails =(from Author in entites.AuthorDetails
                                where Author.Is_Delete == false
                                select Author).ToList();
                    if (dBAuthorDetails != null)
                    {
                        foreach(var item in dBAuthorDetails)
                        {
                            AuthorDrpDetails AuthorList = new AuthorDrpDetails();
                            AuthorList.AuthorDetailId = item.AuthorDetail_Id;
                            AuthorList.AuthourName = item.Authour_Name;
                            AuthorlistDetails.Add(AuthorList);
                        }
                      
                    }
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            return AuthorlistDetails;
        }
        #endregion


        #region Save And Update Book Details
        public void SaveAndUpdateBookDetails(BooksDetails bookDetails)
        {
            try
            {
                if (bookDetails != null)
                {
                    if (bookDetails.BookDetailId == 0)
                    {
                        using (var entites = new BookmanagementsystemContext())
                        {
                            BookDetails dBBookDetails = new BookDetails();
                            dBBookDetails.Book_Title = bookDetails.BookTitle;
                            dBBookDetails.Author_Id= bookDetails.AuthorId;
                            dBBookDetails.Price = bookDetails.Price;
                            dBBookDetails.Is_Delete = false;
                            dBBookDetails.Create_Time_Stamp = DateTime.Now;
                            dBBookDetails.Update_Time_Stamp = DateTime.Now;
                            entites.BookDetails.Add(dBBookDetails);
                            entites.SaveChanges();
                        }
                    }
                    else
                    {
                        using (var entites = new BookmanagementsystemContext())
                        {
                            var dBBookDetails = entites.BookDetails.Where(x => x.BookDetail_Id == bookDetails.BookDetailId && x.Is_Delete == false).SingleOrDefault();
                            dBBookDetails.Book_Title = bookDetails.BookTitle;
                            dBBookDetails.Author_Id = bookDetails.AuthorId;
                            dBBookDetails.Price = bookDetails.Price;
                            dBBookDetails.Is_Delete = false;
                            dBBookDetails.Update_Time_Stamp = DateTime.Now;
                            entites.SaveChanges();
                        }
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region Book Details List
        public List<BooksDetails> BookDetailsList()
        {
            List<BooksDetails> BooklistDetails = new List<BooksDetails>();   // Create List
            try
            {
                using (var entites = new BookmanagementsystemContext())
                {
                    var dBBookDetails = (from Book in entites.BookDetails
                                         join Author in entites.AuthorDetails
                                         on Book.Author_Id equals Author.AuthorDetail_Id
                                         where Book.Is_Delete == false && Author.Is_Delete == false
                                         select new
                                         {
                                            BookDetails_Id= Book.BookDetail_Id,
                                            Book_Title = Book.Book_Title,
                                            Author_Name = Author.Authour_Name,
                                            Book_Price= Book.Price
                                         }).ToList();
                    if (dBBookDetails != null)
                    {
                      
                        foreach (var item in dBBookDetails)
                        {
                            BooksDetails BookList = new BooksDetails();
                            BookList.BookDetailId= item.BookDetails_Id;
                            BookList.BookTitle = item.Book_Title;
                            BookList.AuthorName = item.Author_Name;
                            BookList.Price = item.Book_Price;
                            BooklistDetails.Add(BookList);
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return BooklistDetails;
        }
        #endregion


        #region Retervie Book Detail indiduvalRecord
        public BooksDetails RetervieBookDetail(int BookDetailId)
        {
            BooksDetails booklDetails = new BooksDetails();   // Create Modal
            try
            {
                using (var entites = new BookmanagementsystemContext())
                {
                    var dbStudentDetails = (from BookDetail in entites.BookDetails
                                            where BookDetail.BookDetail_Id == BookDetailId && BookDetail.Is_Delete == false
                                            select BookDetail).SingleOrDefault();
                    if (dbStudentDetails != null)
                    {
                        BooksDetails addBookDetails = new BooksDetails();
                        addBookDetails.BookDetailId = dbStudentDetails.BookDetail_Id;
                        addBookDetails.BookTitle = dbStudentDetails.Book_Title;
                        addBookDetails.AuthorId = dbStudentDetails.Author_Id;
                        addBookDetails.Price = dbStudentDetails.Price;
                        booklDetails = addBookDetails;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return booklDetails;
        }
        #endregion


        #region Book Details Delete
        public void BookDetailsDelete(int BookDetailId)
        {
            try
            {
                using (var entites = new BookmanagementsystemContext())
                {
                    var dbStudentDetails = entites.BookDetails.Where(x => x.BookDetail_Id == BookDetailId).SingleOrDefault();
                    if (dbStudentDetails != null)
                    {
                        dbStudentDetails.Is_Delete = true;
                        dbStudentDetails.Update_Time_Stamp = DateTime.Now;
                        entites.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
