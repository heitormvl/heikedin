using System.ComponentModel.DataAnnotations;

namespace heikedin.ViewModels
{
    public class FormViewModel
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(50)]
        public string Curso { get; set; } = string.Empty;

        [Required]
        public string Descricao { get; set; } = string.Empty;
    }
}
