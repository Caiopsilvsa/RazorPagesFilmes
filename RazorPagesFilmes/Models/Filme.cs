using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesFilmes.Models
{
    public class Filme
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(30)]
        [Display(Name = "Título")]
        public string Titulo { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Gênero")]
        [StringLength (30)]
        public string Genero { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType (DataType.Currency)]
        public decimal Preco { get; set; }


    }
}
