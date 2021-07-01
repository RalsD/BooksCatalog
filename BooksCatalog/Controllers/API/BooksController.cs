using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksCatalog.Data;
using BooksCatalog.Models;
using Newtonsoft.Json;

namespace BooksCatalog.Controllers.API
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        //POST: API/Books/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Book book)
        {
            Book newBook = new Book()
            {
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
                RegistrationTimeStamp = book.RegistrationTimeStamp,
                Category = book.Category
            };
            if (ModelState.IsValid)
            {
                _context.Add(newBook);
                await _context.SaveChangesAsync();
                return Ok(newBook.Id);
            }
            return View(book);
        }

        //PUT: API/Books/1/Update
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(book);
            }
            return View(book);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
