using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Views.Entities;

namespace Views.Pages.Chinook.Genres
{
    public class IndexModel : PageModel
    {
        private readonly ChinookContext context;

        public IndexModel(ChinookContext context)
        {
            this.context = context;
        }

        public async Task OnGetAsync()
        {
            this.Genres = await context.Genres.ToListAsync();
        }

        public List<Genre> Genres { get; private set; } = new List<Genre>();
    }
}
