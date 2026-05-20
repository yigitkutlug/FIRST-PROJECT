using FirstProjectApi.Data;
using FirstProjectApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Book>>> GetAll()
    {
        var books = await context.Books.AsNoTracking().ToListAsync();
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Book>> GetById(int id)
    {
        var book = await context.Books.FindAsync(id);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Book>> Create(Book book)
    {
        // Ignore client-sent id values and let SQL Server identity generate it.
        book.Id = 0;

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest("Route id and payload id must match.");
        }

        var exists = await context.Books.AnyAsync(existingBook => existingBook.Id == id);
        if (!exists)
        {
            return NotFound();
        }

        context.Entry(book).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book is null)
        {
            return NotFound();
        }

        context.Books.Remove(book);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
