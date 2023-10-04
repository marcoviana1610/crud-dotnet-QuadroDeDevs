using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Model
{
    public class DevModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public SenioridadeEnum Senioridade { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
