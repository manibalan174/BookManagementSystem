using BookManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Core.IRepostories
{
   public interface IRepostoriesBookManagement
    {
        #region Login validation
        bool Loginvalidation(LoginDetails loginDetails);
        #endregion

        #region DropDown Author Details
        List<AuthorDrpDetails> DrpAuthorList();
        #endregion

        #region Save And Update Book Details
        void SaveAndUpdateBookDetails(BooksDetails bookDetails);
        #endregion

        #region Book Details List
        List<BooksDetails> BookDetailsList();
        #endregion

        #region Retervie Book Detail
        BooksDetails RetervieBookDetail(int BookDetailId);
        #endregion

        #region Book Details Delete
        void BookDetailsDelete(int BookDetailId);
        #endregion
    }
}
