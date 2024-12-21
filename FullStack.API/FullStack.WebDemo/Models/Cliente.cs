using System.ComponentModel.DataAnnotations;

namespace FullStack.WebDemo.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[0-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage ="Informe celular valido no padrao (31) 9999-111")]
        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }

        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
