using GenrenciadorDeLivros.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GenrenciadorDeLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private static List<Livros> Livro = new List<Livros>
        {
            new Livros { id = 1, Titulo = "Livro 1", autor = "Autor1", genero = "Terror", preco = 19.99m, estoque = 10 }
        };

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Livros>), StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<Livros>> GetLivros()
        {
            return Ok(Livro);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Livros> GetLivro(int id)
        {
            var livro = Livro.FirstOrDefault(x => x.id == id);
            if(livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Livros> Create([FromBody] Livros novoLivro)
        {
            if (novoLivro == null) return BadRequest();
            novoLivro.id = Livro.Any() ? Livro.Max(x => x.id) + 1 : 1;
            Livro.Add(novoLivro);
            return CreatedAtAction(nameof(GetLivro), new {id = novoLivro.id}, novoLivro);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateLivro(int id, [FromBody] Livros livroAtualizado)
        {
            if(livroAtualizado == null) return BadRequest();

            var livro = Livro.FirstOrDefault(x => x.id == id);
            if (livro == null) return NotFound();
            livro.Titulo = livroAtualizado.Titulo;
            livro.autor = livroAtualizado.autor;
            livro.genero = livroAtualizado.genero;
            livro.preco = livroAtualizado.preco;
            livro.estoque = livroAtualizado.estoque;

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult DeleteLivro(int id)
        {
            var livro = Livro.FirstOrDefault(x =>x.id == id);
            if(livro == null) return NotFound();

            Livro.Remove(livro);
            return NoContent();
        }

    }
}
