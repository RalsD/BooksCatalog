using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksCatalog.Data;
using BooksCatalog.Models;

namespace BooksCatalog.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BooksCatalog.Data.ApplicationDbContext _context;

        public IndexModel(BooksCatalog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books.ToListAsync();
        }
    }
}
