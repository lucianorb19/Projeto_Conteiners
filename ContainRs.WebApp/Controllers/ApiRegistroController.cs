using ContainRs.WebApp.Data;
using ContainRs.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContainRs.WebApp.Controllers
{
    [ApiController] //É UM CONTROLADOR PARA API
    [Route("api/registros")]//ROTA DESSE CONTROLADOR
    public class ApiRegistroController : ControllerBase //HERDA DE CONTROLLER BASE E NÃO Controller
    {

        //ATRIBUTOS
        private readonly AppDbContext context;//CONEXÃO COM BD

        //CONTRUTOR - JÁ COM INJEÇÃO DE DEPENDÊNDIA PARA DbContext
        public ApiRegistroController(AppDbContext context)
        {
            this.context = context;
        }

        //MÉTODO POST PARA CADASTRO DE CLIENTE
        [HttpPost]
        public async Task<IActionResult> CreateAsync(RegistroViewModel request)
        {
            //NÃO PRECISA VALIDAÇÃO DE ESTADO NUM ENDPOINT DE API, PARA CHEGAR NELE
            //JÁ DEVE ESTAR VALIDADO
            //if (!ModelState.IsValid) return View("Index", form);

            //NO VÍDEO, NÃO TEM ESSA PARTE DE VALIDAR A IDADE - ?
            //var idade = DateTime.Today.Year - request.Nascimento.Year;
            //if (idade < 18)
            //{
            //    ModelState.AddModelError("Nascimento", "Obrigatório ter mais de 18 anos.");
            //    return View("Index", request);
            //}

            var cliente = new Cliente(request.Nome, new Email(request.Email), request.CPF)
            {
                Celular = request.Celular,
                CEP = request.CEP,
                Rua = request.Rua,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Bairro = request.Bairro,
                Municipio = request.Municipio,
                Estado = request.Estado
            };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            //return RedirectToAction("Sucesso");
            return Ok();
        }
        
    }
}
