using BookManagementSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookManagementSystem.Web.Controllers
{
    public class BookDetailManagementController : Controller
    {

        #region Book Details List view  Page
        [HttpGet]
        public IActionResult BookDetailsList()
        {
            IEnumerable<BooksDetails> Book = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13591/BookManagementDetails/");
                //HTTP GET
                var responseTask = client.GetAsync("BookDetailsList");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BooksDetails>>();
                    readTask.Wait();
                    Book = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Book = Enumerable.Empty<BooksDetails>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Book);
        }
        #endregion


        #region Book Details Add And Edit view  Page
        public IActionResult BookDetailsAddEdit(int BookDetailId = 0)
        {

            //--------------------drpDown Method ----------
            IEnumerable<AuthorDrpDetails> Author = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13591/BookManagementDetails/");
                //HTTP GET
                var responseTask = client.GetAsync("AuthorDetailsList");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AuthorDrpDetails>>();
                    readTask.Wait();
                    Author = readTask.Result;
                }
            }
            ViewBag.Author = new SelectList(Author, "AuthorDetailId", "AuthourName");

           //--------------------------------------------------

            if (BookDetailId == 0)
            {
              
                return View();
            }  // Empty Normal View
           
              else  
                {
                // reterive Method in List page to Edit Page
                BooksDetails Book = null;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:13591/BookManagementDetails/");
                        //HTTP GET
                        var responseTask = client.GetAsync("BookDetailsRetervie?BookDetailId=" + BookDetailId);
                        responseTask.Wait();
                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<BooksDetails>();  // Retervie Book Details
                            readTask.Wait();
                        Book = readTask.Result;
                        }
                    }
                return View(Book);
                }
        }
        #endregion


        #region Book Details Save And Update
        [HttpPost]
        public IActionResult BookDetailsSaveAndUpdate(BooksDetails bookDetails)
        {
            var _result = "";
            
                if (bookDetails.BookDetailId == 0)
                {
                    _result = "Book Details Inserted";
                }
                else
                {
                    _result = "Book Details Updated";
                }
            if (bookDetails != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:13591/BookManagementDetails/BookDetailsSaveAndUpdate");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<BooksDetails>(client.BaseAddress, bookDetails);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Alert"] = _result + " Sucessfully";
                        return RedirectToAction("BookDetailsList");
                    }
                       
                }

            }
            TempData["Alert1"] = _result + "Something Went To Wrong !";
            return RedirectToAction("BookDetailsAddEdit");
        }
        #endregion


        #region Book Details Delete
       // [HttpDelete]
        public IActionResult BookDetailsDelete(int BookDetailId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13591/BookManagementDetails/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DeleteBookDetails?BookDetailId=" + BookDetailId);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("BookDetailsList");
                }
            }
            return RedirectToAction("BookDetailsList");
        }
        #endregion


    }
}
