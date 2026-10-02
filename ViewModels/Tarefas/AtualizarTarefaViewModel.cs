using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HouseholdTasks.ViewModels.Tarefas
{
    public class AtualizarTarefaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Informe o título")]
        [MaxLength(100, ErrorMessage = "O título não pode ter mais de 100 caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
        public string? Descricao { get; set; }

        [Display(Name = "Observações")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "As observações não podem ter mais de 500 caracteres.")]
        public string? Observacoes { get; set; }

        /*public ResponsavelViewModel Responsavel { get; set; }*/
        
        [Display(Name = "Responsável")]
        [Required(ErrorMessage = "Informe o responsável")]
        public Guid ResponsavelId { get; set; }
        
        public List<SelectListItem> Responsaveis { get; set; }

        [Display(Name = "Importância")]
        [Required(ErrorMessage = "Informe a importância")]
        public ImportanciaViewModel Importancia { get; set; }

        public AtualizarTarefaViewModel() { }

        public AtualizarTarefaViewModel(
            Guid id,
            string titulo,
            string? descricao,
            string? observacoes,
            Guid responsavelId,
            List<SelectListItem> responsaveis,
            ImportanciaViewModel importancia)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Observacoes = observacoes;
            ResponsavelId = responsavelId;
            Responsaveis = responsaveis;
            Importancia = importancia;
        }
    }
}
