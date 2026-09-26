using HouseholdTasks.Interfaces;
using HouseholdTasks.Models;
using HouseholdTasks.ViewModels.Responsaveis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ResponsavelController : Controller
{
    private readonly IResponsavelRepository _repository;

    public ResponsavelController(IResponsavelRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var responsaveisList = await _repository.ObterTodos();

        var responsaveis = responsaveisList
            .Select(r => new VisualizarResponsaveisViewModel(r.Id, r.Nome))
            .ToList();

        return View(responsaveis);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var responsavel = await _repository.ObterPorId(id);

        if (responsavel == null)
        {
            return NotFound("Responsável não encontrado.");
        }

        return View(new CadastrarAtualizarResponsavelViewModel(responsavel.Id, responsavel.Nome));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nome")] CadastrarAtualizarResponsavelViewModel cadastraratualizarresponsavelviewmodel)
    {
        if (ModelState.IsValid)
        {
            var responsavel = new Responsavel
            {
                Id = Guid.NewGuid(),
                Nome = cadastraratualizarresponsavelviewmodel.Nome
            };

            try
            {
                _repository.Adicionar(responsavel);
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(cadastraratualizarresponsavelviewmodel);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var responsavel = await _repository.ObterPorId(id);

        if (responsavel == null)
        {
            return NotFound("Responsável não encontrado.");
        }

        return View(new CadastrarAtualizarResponsavelViewModel(responsavel.Id, responsavel.Nome));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid? id, [Bind("Id,Nome")] CadastrarAtualizarResponsavelViewModel cadastraratualizarresponsavelviewmodel)
    {
        if (id != cadastraratualizarresponsavelviewmodel.Id)
        {
            return NotFound("Responsável não encontrado para atualização.");
        }

        if (ModelState.IsValid)
        {
            try
            {
                var responsavel = await _repository.ObterPorId(cadastraratualizarresponsavelviewmodel.Id);
                responsavel.Nome = cadastraratualizarresponsavelviewmodel.Nome;

                _repository.Atualizar(responsavel);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await CadastrarAtualizarResponsavelViewModelExists(cadastraratualizarresponsavelviewmodel.Id))
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

        return View(cadastraratualizarresponsavelviewmodel);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var responsavel = await _repository.ObterPorId(id);

        if (responsavel == null)
        {
            return NotFound("Responsável não encontrado.");
        }

        return View(new CadastrarAtualizarResponsavelViewModel(responsavel.Id, responsavel.Nome));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var responsavel = await _repository.ObterPorId(id);

        if (responsavel == null)
        {
            return NotFound("Responsável não encontrado.");
        }

        try
        {
            _repository.Remover(responsavel);
        }
        catch (Exception ex)
        {
            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> CadastrarAtualizarResponsavelViewModelExists(Guid id)
    {
        var responsavel = await _repository.ObterPorId(id);
        return responsavel != null;
    }
}
