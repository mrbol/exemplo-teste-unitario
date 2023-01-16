using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteApp.Application.Interfaces;
using TesteApp.Domain.Entities;


namespace TesteApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _produtoService;

        public ProductController(IProductService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _produtoService.Get(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Create(Product product)
        {
            var errorNotification = await _produtoService.Create(product);
            if (errorNotification.Exists())
            {
                return MessageErroResult(errorNotification.GetAll());
            }
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Update(int id, Product product)
        {
            var errorNotification = await _produtoService.Update(id, product);
            if (errorNotification.Exists())
            {
                return MessageErroResult(errorNotification.GetAll());
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _produtoService.Delete(id);
            if (!result)
            {
                return MessageErroResult(new List<ItemNotification>() {
                    new ItemNotification() {
                        Name = "Produto",
                        Description = "Ação Delete provocou uma ocorrencia inesperada"
                    }
                });
            }
            return Ok();
        }

        private IActionResult MessageErroResult(List<ItemNotification> errorNotification)
        {
            return BadRequest(new
            {
                type = "Notificação",
                title = "Um ou mais erros ocorridos",
                status = 400,
                errors = errorNotification
            });
        }


    }
}
