using BookManagementSystem.Core.IService;
using BookManagementSystem.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BookManagementDetailsController : ControllerBase
    {
        #region Service Interface Class Declaration
        private readonly IServiceBookManagement _Iservice;
        #endregion


        #region Service Interface Class Injection
        public BookManagementDetailsController(IServiceBookManagement Iservice)
        {
            _Iservice = Iservice;
        }
        #endregion


        #region Login Check 
        [HttpPost]
        public IActionResult LoginCheck(LoginDetails loginDetails)
        {
            var Result = _Iservice.Loginvalidation(loginDetails);
            if (Result == true)
            {
                return RedirectToAction("BookDetailsList");
            }
            return NotFound();
        }
        #endregion


        #region Author Details List Dropdown
        [HttpGet]
        public IActionResult AuthorDetailsList()
        {
            var Authordetails = _Iservice.DrpAuthorList();
            return Ok(Authordetails);
        }
        #endregion


        #region Book Details List
        [HttpGet]
        public IActionResult BookDetailsList()
        {
            var BookDetails = _Iservice.BookDetailsList();
            return Ok(BookDetails);
        }
        #endregion


        #region Book Details Retervie
        [HttpGet]
        public IActionResult BookDetailsRetervie(int BookDetailId)
        {
            var BookDetails = _Iservice.RetervieBookDetail(BookDetailId);
            return Ok(BookDetails);
        }
        #endregion


        #region Book Details Save And Update
        [HttpPost]
        public IActionResult BookDetailsSaveAndUpdate(BooksDetails bookDetails)
        {
            if(bookDetails != null)
            {
                _Iservice.SaveAndUpdateBookDetails(bookDetails);
            }
            return Ok("BookDetailsList");
        }
        #endregion


        #region Book Details Delete
        [HttpDelete]
        public IActionResult DeleteBookDetails(int BookDetailId)
        {
            _Iservice.BookDetailsDelete(BookDetailId);
            return Ok();
        }
        #endregion

    }
}
