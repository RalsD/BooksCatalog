using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksCatalog.Data;
using BooksCatalog.Models;

namespace BooksCatalog.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BooksCatalog.Data.ApplicationDbContext _context;

        public CreateModel(BooksCatalog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

    }
}
