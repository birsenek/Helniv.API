using Microsoft.AspNetCore.Mvc;

namespace Helniv.API.Models
{
    public class CreateCardRequestModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Elemento { get; set; }
        public string Tipo { get; set; }
        public int PoderFogo { get; set; }
        public int PoderAgua { get; set; }
        public int PoderTerra { get; set; }
        public int PoderAr { get; set; }
        public string? Local { get; set; }

        [FromForm(Name = "ImageFile")]
        public List<IFormFile> ImageFile { get; set; }
    }
}
