using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zainalds_Book_Store.Model;

namespace Zainalds_Book_Store.Pages.Book
{
    public class UpdateModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpdateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Zainalds_Book_Store.Model.Book Books { get; set; }

        public async Task OnGet(int Id)
        {
            Books = await _db.Books.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Books.FindAsync(Books.Id);

                BookFromDb.Name = Books.Name;
                BookFromDb.ISBN = Books.ISBN;
                BookFromDb.Author = Books.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
