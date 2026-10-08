using HouseholdTasks.Interfaces;
using HouseholdTasks.Models;
using HouseholdTasks.ViewModels;
using HouseholdTasks.ViewModels.Tarefas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

[Controller]
public class TarefaController : Controller
{
    private readonly ITarefaRepository _repository;
    private readonly IResponsavelRepository _responsavelRepository;

    public TarefaController(ITarefaRepository repository, IResponsavelRepository responsavelRepository)
    {
        _repository = repository;
        _responsavelRepository = responsavelRepository;
    }

    public async Task<IActionResult> Index()
    {
        var tarefas = await _repository.ObterTodas();

        return View(tarefas.Select(t => new VisualizarTarefasViewModel(
            t.Id,
            t.Titulo,
            t.Responsavel.Nome,
            (StatusViewModel)t.Status)));
    }

    [Route("Tarefas/Detalhes/{id:guid}")]
    public async Task<IActionResult> Details(Guid id)
    {
        var tarefa = await _repository.ObterPorId(id);

        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada.");
        }

        return View(new VisualizarDetalhesTarefaViewModel(
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Descricao,
            tarefa.DataCriacao,
            tarefa.DataConclusao,
            (StatusViewModel)tarefa.Status,
            tarefa.Observacoes,
            new ResponsavelViewModel
            {
                Id = tarefa.Responsavel.Id,
                Nome = tarefa.Responsavel.Nome
            },
            (ImportanciaViewModel)tarefa.Importancia
        ));
    }

    public async Task<IActionResult> Create()
    {
        var responsaveis = await _responsavelRepository.ObterTodos();

        var tarefaViewModel = new CriarTarefaViewModel
        {
            Responsaveis = responsaveis.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Nome
            }).ToList()
        };

        return View(tarefaViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CriarTarefaViewModel tarefaViewmodel)
    {
        if (!ModelState.IsValid)
        {
            var responsaveis = await _responsavelRepository.ObterTodos();
            tarefaViewmodel.Responsaveis = responsaveis.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Nome
            }).ToList();

            return View(tarefaViewmodel);
        }
        
        var responsavel = await _responsavelRepository.ObterPorId(tarefaViewmodel.ResponsavelId);

        var tarefa = new Tarefa
        {
            Id = Guid.NewGuid(),
            Titulo = tarefaViewmodel.Titulo,
            Descricao = tarefaViewmodel.Descricao,
            Observacoes = tarefaViewmodel.Observacoes,
            Responsavel = responsavel,
            Importancia = (Importancia)tarefaViewmodel.Importancia,
            Status = Status.Nova
        };

        try
        {
            _repository.Adicionar(tarefa);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Ocorreu um erro ao criar a tarefa: {ex.Message}");
            return View(tarefaViewmodel);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var tarefa = await _repository.ObterPorId(id);
        var responsaveis = await _responsavelRepository.ObterTodos();

        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada.");
        }

        return View(new AtualizarTarefaViewModel(
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Descricao,
            tarefa.Observacoes,
            tarefa.ResponsavelId,
            responsaveis.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Nome
            }).ToList(),
            (ImportanciaViewModel)tarefa.Importancia
        ));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, AtualizarTarefaViewModel tarefaViewmodel)
    {
        if (!ModelState.IsValid)
        {
            var responsaveis = await _responsavelRepository.ObterTodos();
            tarefaViewmodel.Responsaveis = responsaveis.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Nome
            }).ToList();

            return View(tarefaViewmodel);
        }
        
        if (id != tarefaViewmodel.Id)
        {
            return NotFound("Tarefa não encontrada para atualização.");
        }

        try
        {
            var tarefa = await _repository.ObterPorId(id);
            tarefa.Titulo = tarefaViewmodel.Titulo;
            tarefa.Descricao = tarefaViewmodel.Descricao;
            tarefa.Observacoes = tarefaViewmodel.Observacoes;
            tarefa.ResponsavelId = tarefaViewmodel.ResponsavelId;
            tarefa.Importancia = (Importancia)tarefaViewmodel.Importancia;

            _repository.Atualizar(tarefa);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            if (!await CriarTarefaViewModelExists(tarefaViewmodel.Id))
            {
                return NotFound(ex.InnerException?.Message ?? ex.Message);
            }
            else
            {
                throw;
            }
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var tarefa = await _repository.ObterPorId(id);

        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada.");
        }

        return View(new VisualizarDetalhesTarefaViewModel(
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Descricao,
            tarefa.DataCriacao,
            tarefa.DataConclusao,
            (StatusViewModel)tarefa.Status,
            tarefa.Observacoes,
            new ResponsavelViewModel
            {
                Id = tarefa.Responsavel.Id,
                Nome = tarefa.Responsavel.Nome
            },
            (ImportanciaViewModel)tarefa.Importancia
        ));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var tarefa = await _repository.ObterPorId(id);

        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada.");
        }

        try
        {
            _repository.Remover(tarefa);
        }
        catch (Exception ex)
        {
            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> CriarTarefaViewModelExists(Guid id)
    {
        var tarefa = await _repository.ObterPorId(id);
        return tarefa != null;
    }
}
