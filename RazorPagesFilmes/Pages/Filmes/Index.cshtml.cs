using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesFilmes.Data;
using RazorPagesFilmes.Models;

namespace RazorPagesFilmes.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFilmes.Data.RazorPagesFilmesContext _context;

        public IndexModel(RazorPagesFilmes.Data.RazorPagesFilmesContext context)
        {
            _context = context;
        }

        public IList<Filme> Filme { get;set; } = default!;

        [BindProperty(SupportsGet =true)]
        public string FilmeDigitado { get; set; }

        [BindProperty(SupportsGet =true)]
        public string GeneroSelecionado { get; set; }
        
        public SelectList Generos;

        public async Task OnGetAsync()
        {
            var filmes = from f in _context.Filme
                         select f;

            if (!string.IsNullOrWhiteSpace(GeneroSelecionado))
            {
                filmes = filmes.Where(f => f.Genero == GeneroSelecionado);
            }

            if (!string.IsNullOrWhiteSpace(FilmeDigitado))
            {
                filmes = filmes.Where(f => f.Titulo.Contains(FilmeDigitado));
            }

            Generos = new SelectList(await _context.Filme.Select(f => f.Genero).Distinct().ToListAsync());
            Filme = await filmes.ToListAsync(); 
        }
    }
}
