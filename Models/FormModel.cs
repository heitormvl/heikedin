using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace heikedin.Models
{
    public class FormModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar(11)")]
        public string CPF { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Curso { get; set; } = string.Empty;

        [Column(TypeName = "varchar(max)")]
        public string Descricao { get; set; } = string.Empty;
    }
}
