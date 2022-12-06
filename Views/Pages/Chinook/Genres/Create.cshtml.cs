using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Views.Entities;

namespace Views.Pages.Demo
{
    public class SearchModel : PageModel
    {
        private readonly ChinookContext context;

        public SearchModel(ChinookContext context)
        {
            this.context = context;
        }
        
        public class InputModel
        {
            [Required]
            public string? Name { get; set; }
        }

        [BindProperty]
        public InputModel? Genre { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Genre != null)
            {
                context.Genres.Add(new Genre{Name = Genre.Name});
            }
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
