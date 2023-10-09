using Microsoft.AspNetCore.Mvc;
using PWFilmes.API.Context;
using PWFilmes.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PWFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private PWFilmesContext _context;

        public CategoriaController(PWFilmesContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            List<Categoria> categorias = new List<Categoria>();
            categorias.Add(
                new Categoria { Codigo = 1, Descricao = "Terror", Cor = "Vermelho" });

            categorias.Add(
                new Categoria { Codigo = 2, Descricao = "Suspense", Cor = "Azul" });

            return Ok(categorias);
        }

        [HttpGet("obter/{codigo}")]
        public IActionResult Obter(int codigo)
        {
            List<Categoria> categorias = new List<Categoria>();
            categorias.Add(
                new Categoria { Codigo = 1, Descricao = "Terror", Cor = "Vermelho" });

            categorias.Add(
                new Categoria { Codigo = 2, Descricao = "Suspense", Cor = "Azul" });

            Categoria cat = 
                categorias.FirstOrDefault(p => p.Codigo == codigo);

            return Ok(cat);
        }
    }
}
