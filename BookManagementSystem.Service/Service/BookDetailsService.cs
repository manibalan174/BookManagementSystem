using BookManagementSystem.Core.IRepostories;
using BookManagementSystem.Core.IService;
using BookManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Service.Service
{
   public class BookDetailsService: IServiceBookManagement
    {
        private readonly IRepostoriesBookManagement _Irespostories;
        public  BookDetailsService(IRepostoriesBookManagement Irespostories)
        {
            _Irespostories = Irespostories;
        }

        #region MyRegion
        public bool Loginvalidation(LoginDetails loginDetails)
        {
            return _Irespostories.Loginvalidation(loginDetails);
        }
        #endregion

        #region DropDown Author Details
        public List<AuthorDrpDetails> DrpAuthorList()
        {
            return _Irespostories.DrpAuthorList();
        }
        #endregion

        #region MyRegion
       public void SaveAndUpdateBookDetails(BooksDetails bookDetails)
        {
            _Irespostories.SaveAndUpdateBookDetails(bookDetails);
        }
        #endregion

        #region Book Details List
        public List<BooksDetails> BookDetailsList()
        {
            return _Irespostories.BookDetailsList();
        }
        #endregion

        #region Retervie Book Detail
        public BooksDetails RetervieBookDetail(int BookDetailId)
        {
            return _Irespostories.RetervieBookDetail(BookDetailId);
        }
        #endregion

        #region Book Details Delete
        public void BookDetailsDelete(int BookDetailId)
        {
            _Irespostories.BookDetailsDelete(BookDetailId);
        }
        #endregion
    }
}
