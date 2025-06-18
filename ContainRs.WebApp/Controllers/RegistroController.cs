using ContainRs.WebApp.Data;

using ContainRs.WebApp.Models;
using ContainRs.Domain.Models;

//using ContainRs.WebApp.UseCases;
using ContainRs.Application.UseCases;

using Microsoft.AspNetCore.Mvc;
using Azure.Core;


namespace ContainRs.WebApp.Controllers;

public class RegistroController : Controller
{
    private readonly AppDbContext context;

    public RegistroController(AppDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Sucesso() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(RegistroViewModel form)
    {
        if (!ModelState.IsValid) return View("Index", form);

        var idade = DateTime.Today.Year - form.Nascimento.Year;
        if (idade < 18)
        {
            ModelState.AddModelError("Nascimento", "Obrigatório ter mais de 18 anos.");
            return View("Index", form);
        }

        var useCase = new RegistrarCliente(context, form.Nome, new Email(form.Email),
                                           form.CPF, form.Celular, form.CEP,
                                           form.Rua, form.Numero, form.Complemento,
                                           form.Bairro, form.Municipio, UfStringConverter.From(form.Estado));
                                         //form.Bairro, form.Municipio, form.Estado);
        await useCase.ExecutarAsync();

        return RedirectToAction("Sucesso");
    }
}
