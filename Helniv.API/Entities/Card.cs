namespace Helniv.API.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Elemento { get; set; }
        public string Tipo { get; set; }
        public int PoderFogo { get; set; }
        public int PoderAgua { get; set; }
        public int PoderTerra { get; set; }
        public int PoderAr { get; set; }

    }
}
