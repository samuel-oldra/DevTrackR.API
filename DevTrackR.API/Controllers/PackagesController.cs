using DevTrackR.API.Entities;
using DevTrackR.API.Models;
using DevTrackR.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DevTrackR.API.Controllers
{
    [ApiController]
    [Route("api/packages")]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageRepository _repository;

        private readonly ISendGridClient _client;

        public PackagesController(IPackageRepository repository, ISendGridClient client)
        {
            _repository = repository;
            _client = client;
        }

        // GET: api/packages
        /// <summary>
        /// Listagem de Pacotes
        /// </summary>
        /// <returns>Lista de Pacotes</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var packages = _repository.GetAll();

            return Ok(packages);
        }

        // GET: api/packages/{code}
        /// <summary>
        /// Detalhes do Pacote
        /// </summary>
        /// <param name="code">Código do Pacote</param>
        /// <returns>Mostra um Pacote</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByCode(string code)
        {
            var package = _repository.GetByCode(code);

            if (package == null) return NotFound();

            return Ok(package);
        }

        // POST: api/packages
        /// <summary>
        /// Cadastro do Pacote
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "title": "Pacote Cartas Colecionáveis",
        ///     "weight": 1.8,
        ///     "senderName": "Samuel",
        ///     "senderEmail": "samuel@teste"
        /// }
        /// </remarks>
        /// <param name="model">Dados do Pacote</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddPackageInputModel model)
        {
            if (model.Title.Length < 10) return BadRequest("Title length must be at least 10 characters long.");

            var package = new Package(model.Title, model.Weight);

            _repository.Add(package);

            var message = new SendGridMessage
            {
                From = new EmailAddress("bayiho6875@akapple.com", "BAYIHO"),
                Subject = "Your package was dispatched.",
                PlainTextContent = $"Your package with code {package.Code} was dispatched."
            };

            message.AddTo(model.SenderEmail, model.SenderName);

            await _client.SendEmailAsync(message);

            return CreatedAtAction(
                "GetByCode",
                new { code = package.Code },
                package
            );
        }

        // POST: api/packages/{code}/updates
        /// <summary>
        /// Atualiza um Pacote
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "Status": "Enviado",
        ///     "Delivered": false
        /// }
        /// </remarks>
        /// <param name="code">Código do Pacote</param>
        /// <param name="model">Dados do Pacote</param>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>
        [HttpPost("{code}/updates")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PostUpdate(string code, AddPackageUpdateInputModel model)
        {
            var package = _repository.GetByCode(code);

            if (package == null) return NotFound();

            package.AddUpdate(model.Status, model.Delivered);

            _repository.Update(package);

            return NoContent();
        }
    }
}