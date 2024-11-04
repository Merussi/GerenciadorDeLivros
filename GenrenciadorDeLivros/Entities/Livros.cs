namespace GenrenciadorDeLivros.Entities
{
    public class Livros
    {
        public int id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string autor { get; set; } = string.Empty;
        public string genero {  get; set; } = string.Empty;
        public decimal preco {  get; set; } 
        public int estoque { get; set; }
    }
}
