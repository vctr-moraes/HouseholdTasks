using System.ComponentModel.DataAnnotations;

namespace HouseholdTasks.ViewModels.Responsaveis
{
    public class CadastrarAtualizarResponsavelViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }
    }
}
